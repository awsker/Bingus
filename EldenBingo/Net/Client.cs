﻿using EldenBingo.Net;
using EldenBingoCommon;
using Neto.Client;
using Neto.Shared;
using System.Reflection;

namespace EldenBingo
{
    public class Client : NetoClient
    {
        private Room? _room;

        public Client()
        {
            RegisterAssembly(Assembly.GetAssembly(typeof(BingoBoard)));
            registerHandlers();
        }

        internal event EventHandler? OnUsersChanged;

        internal event EventHandler<RoomChangedEventArgs>? OnRoomChanged;

        public UserInRoom? LocalUser { get; private set; }
        public BingoBoard? BingoBoard => Room?.Match.Board;

        internal Room? Room
        {
            get
            {
                return _room;
            }
            set
            {
                if (_room != value)
                {
                    var oldRoom = _room;
                    _room = value;
                    if (_room == null)
                        LocalUser = null;
                    fireOnRoomChanged(oldRoom);
                }
            }
        }

        public override string GetConnectionStatusString()
        {
            if (!IsConnected)
                return "Not connected";
            if (CancelToken.IsCancellationRequested)
                return "Stopping...";
            if (Room == null)
                return "Connected - Not in a lobby";
            else
                return "Connected - Lobby: " + Room.Name;
        }

        public async Task RequestRoomName()
        {
            var req = new Packet(new ClientRequestRoomName());
            await SendPacketToServer(req);
        }

        public async Task CreateRoom(string roomName, string adminPass, string nickname, int team)
        {
            var request = new ClientRequestCreateRoom(roomName, adminPass, nickname, team);
            await SendPacketToServer(new Packet(request));
        }

        public async Task JoinRoom(string roomName, string adminPass, string nickname, int team)
        {
            var request = new ClientRequestJoinRoom(roomName, adminPass, nickname, team);
            await SendPacketToServer(new Packet(request));
        }

        public async Task LeaveRoom()
        {
            Room = null;
            FireOnStatus("Left lobby");
            await SendPacketToServer(new Packet(new ClientRequestLeaveRoom()));
        }

        private void registerHandlers()
        {
            AddListener<ServerUserJoinedRoom>(userJoinedRoom);
            AddListener<ServerUserLeftRoom>(userLeftRoom);
            AddListener<ServerCreateRoomDenied>(createRoomDenied);
            AddListener<ServerJoinRoomDenied>(joinRoomDenied);
            AddListener<ServerJoinRoomAccepted>(joinRoomAccepted);
            AddListener<ServerMatchStatusUpdate>(matchStatusUpdate);
        }

        private void userJoinedRoom(ClientModel? _, ServerUserJoinedRoom userJoined)
        {
            if (Room != null)
            {
                Room.AddUser(userJoined.User);
                fireOnUsersChanged();
            }
        }

        private void userLeftRoom(ClientModel? _, ServerUserLeftRoom userLeft)
        {
            if (Room != null)
            {
                Room.RemoveUser(userLeft.User);
                fireOnUsersChanged();
            }
        }

        private void createRoomDenied(ClientModel? _, ServerCreateRoomDenied createRoomDenied)
        {
            Room = null;
            FireOnStatus($"Create lobby failed: {createRoomDenied.Reason}");
        }

        private void joinRoomDenied(ClientModel? _, ServerJoinRoomDenied joinDenied)
        {
            Room = null;
            FireOnStatus($"Join lobby failed: {joinDenied.Reason}");
        }

        private void joinRoomAccepted(ClientModel? _, ServerJoinRoomAccepted joinAccepted)
        {
            var sameRoomAsBefore = Room != null && Room.Name == joinAccepted.RoomName;

            if (!sameRoomAsBefore)
                FireOnStatus($"Joined lobby '{joinAccepted.RoomName}'");
            var room = new Room(joinAccepted.RoomName);
            foreach (var user in joinAccepted.Users)
                room.AddUser(user);

            //Store a reference to my own User
            LocalUser = room.GetUser(ClientGuid);

            //Set the new current room (which fires the RoomChanged event)
            Room = room;
        }

        private void matchStatusUpdate(ClientModel? _, ServerMatchStatusUpdate matchStatus)
        {
            if (Room != null)
            {
                Room.Match.UpdateMatchStatus(matchStatus.MatchStatus, matchStatus.Timer);
            }
        }

        private void fireOnRoomChanged(Room? oldRoom)
        {
            OnRoomChanged?.Invoke(this, new RoomChangedEventArgs(oldRoom, Room));
        }

        private void fireOnUsersChanged()
        {
            OnUsersChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}