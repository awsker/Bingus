﻿using System.Drawing;

namespace BingusCommon
{
    public enum MatchStatus
    {
        NotRunning,
        Starting,
        Preparation,
        Running,
        Finished
    }

    public class Match
    {
        public Match()
        {
            MatchStatus = MatchStatus.NotRunning;
            ServerTimer = 0;
            updateMatchStatus();
        }

        public event EventHandler? MatchStatusChanged;

        public BingoBoard? Board { get; set; }

        public bool Paused { get; private set; }

        public void Pause()
        {
            if (Paused)
                return;

            ForceTimer(MatchMilliseconds);
            Paused = true;
        }

        public void Unpause()
        {
            if (!Paused)
                return;

            ForceTimer(MatchMilliseconds);
            Paused = false;
        }

        public void ForceTimer(int timer)
        {
            ServerTimer = timer;
            StatusChangedLocalDateTime = DateTime.Now;
        }

        public int MatchMilliseconds
        {
            get
            {
                return ServerTimer + (Running && !Paused ? Convert.ToInt32((DateTime.Now - StatusChangedLocalDateTime).TotalMilliseconds) : 0);
            }
        }

        public int MatchSeconds
        {
            get
            {
                return Convert.ToInt32(Math.Floor(MatchMilliseconds / 1000d));
            }
        }

        public MatchStatus MatchStatus { get; private set; }
        public bool Running => MatchStatus == MatchStatus.Starting || MatchStatus == MatchStatus.Preparation || MatchStatus == MatchStatus.Running;
        public int ServerTimer { get; private set; }
        public DateTime StatusChangedLocalDateTime { get; private set; }
        
        public string TimerString
        {
            get
            {
                var seconds = MatchSeconds;
                bool negative = seconds < 0;
                if (negative)
                {
                    seconds = -seconds;
                }
                var hours = seconds / 3600;
                seconds %= 3600;
                var minutes = seconds / 60;
                seconds %= 60;
                return $"{(negative ? "-" : string.Empty)}{hours.ToString("00")}:{minutes.ToString("00")}:{seconds.ToString("00")}";
            }
        }

        public static string MatchStatusToString(MatchStatus status, bool paused, out Color color)
        {
            if (paused)
            {
                color = Color.Orange;
                return "Paused";
            }
            switch (status)
            {
                case MatchStatus.NotRunning:
                    color = Color.CadetBlue;
                    return "Not Running";

                case MatchStatus.Starting:
                    color = Color.Orange;
                    return "Starting...";
                
                case MatchStatus.Preparation:
                    color = Color.BlueViolet;
                    return "Preparation";

                case MatchStatus.Running:
                    color = Color.Green;
                    return "Running";

                case MatchStatus.Finished:
                    color = Color.CadetBlue;
                    return "Match Finished";
            }
            color = Color.White;
            return string.Empty;
        }

        public void UpdateMatchStatus(MatchStatus status, int timer, BingoBoard? board = null)
        {
            ServerTimer = timer;
            StatusChangedLocalDateTime = DateTime.Now;
            MatchStatus = status;
            if (board != null)
                Board = board;
            onMatchStatusChanged();
        }

        public void UpdateMatchStatus(MatchStatus status, bool paused, int timer, BingoBoard? board = null)
        {
            ServerTimer = timer;
            StatusChangedLocalDateTime = DateTime.Now;
            MatchStatus = status;
            Paused = paused;
            if (board != null)
                Board = board;
            onMatchStatusChanged();
        }

        private void onMatchStatusChanged()
        {
            MatchStatusChanged?.Invoke(this, EventArgs.Empty);
        }

        private void updateMatchStatus()
        {
            UpdateMatchStatus(MatchStatus, Paused, ServerTimer, Board);
        }
    }
}