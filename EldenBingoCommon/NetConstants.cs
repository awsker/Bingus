﻿using System.Drawing;

namespace EldenBingoCommon
{
    public static class NetConstants
    {
        public const string ServerRegisterString = "eldenbingo-server";
        public const string UserRegisterString = "hello";
        public const int DefaultPort = 4501;

        public enum PacketTypes
        {
            ClientRegister, //string
            ClientRequestRoomName, //string
            ClientRequestCreateRoom, //string, string, string, int, int, bool
            ClientRequestJoinRoom, //string, string, string, int, int, bool
            ClientRequestLeaveRoom, //(none)
            ClientChat, //string
            ClientCoordinates, //MapCoordinates
            ClientBingoJson, //string (json)
            ClientRandomizeBoard, //(none)
            ClientChangeMatchStatus, //byte
            ClientTryCheck, //byte, Guid
            ClientTryMark, //byte
            ClientSetCounter, //byte, int, Guid
            ClientDisconnect, //(none)
            
            ServerRegisterAccepted, //string, Guid
            ServerAvailableRoomName, //string
            ServerUserJoinedRoom, //UserInRoom
            ServerUserLeftRoom, //Guid
            ServerJoinRoomDenied, //string
            ServerJoinAcceptedRoomData, //string, int, UserInRoom [...], Match
            ServerUserChat, //UserInRoom, string
            ServerUserCoordinates, //UserInRoom, MapCoordinates
            ServerToAdminStatusMessage, //int(color), string,
            ServerMatchStatusChanged, //Match
            ServerBingoBoardCheckChanged, //UserGuid, int
            ServerBingoBoardMarkChanged, //UserGuid, int
            ServerBingoBoardCountChanged, //UserGuid, int
            ServerUserConnectionClosed, //(none)
            ServerShutdown, //(none)
        }

        public static readonly ColorName[] DefaultPlayerColors = new[]
        {
            new ColorName(Color.FromArgb(180, 10, 0), "Red"),
            new ColorName(Color.FromArgb(0, 86, 179), "Blue"),
            new ColorName(Color.FromArgb(40, 179, 16), "Green"),
            new ColorName(Color.FromArgb(204, 104, 0), "Orange"),
            new ColorName(Color.FromArgb(135, 35, 208), "Purple"),
            new ColorName(Color.FromArgb(78, 204, 204), "Cyan"),
            new ColorName(Color.FromArgb(237, 115, 216), "Pink"),
            new ColorName(Color.FromArgb(112, 79, 41), "Brown"),
            new ColorName(Color.FromArgb(206, 199, 0), "Yellow")
        };

        public static string GetTeamName(int team)
        {
            if (team <= 0 || team > DefaultPlayerColors.Length)
                return "";

            return DefaultPlayerColors[team - 1].Name + " Team";
        }

        public static Color AdminSpectatorColor = Color.White;
        public static Color SpectatorColor = Color.LightGray;
    }

    public struct ColorName
    {
        public Color Color { get; init; }
        public string Name { get; init; }
        public ColorName(Color color, string name)
        {
            Color = color;
            Name = name;
        }
           
    }
}