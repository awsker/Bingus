﻿namespace EldenBingoCommon
{
    public class BingoBoard
    {
        public BingoBoardSquare[] Squares { get; init; }
        
        public BingoBoard(string[] squareTexts, string[] tooltips)
        {
            if (squareTexts.Length != 25)
                throw new ArgumentException("Needs exactly 25 strings");
            if (tooltips.Length != 25)
                throw new ArgumentException("Needs exactly 25 tooltips");

            Squares = new BingoBoardSquare[25];
            for(int i = 0; i < squareTexts.Length; ++i)
            {
                Squares[i] = new BingoBoardSquare(squareTexts[i], tooltips[i]);
            }
        }

        public BingoBoard(byte[] buffer, ref int offset)
        {
            Squares = new BingoBoardSquare[25];

            for (int i = 0; i < 25; ++i)
            {
                Squares[i] = new BingoBoardSquare(buffer, ref offset);
            }
        }
        
        public virtual byte[] GetBytes(UserInRoom user)
        {
            return PacketHelper.ConcatBytes(Squares.Select(s => s.GetBytes()));
        }

        public virtual byte[] GetStatusBytes(UserInRoom user)
        {
            return PacketHelper.ConcatBytes(Squares.Select(s => s.GetStatusBytes()));
        }
    }

    public class BingoBoardSquare : INetSerializable
    {
        public bool Checked => Team.HasValue;
        public string Text { get; init; }
        public string Tooltip { get; init; }
        public int? Team
        {
            get
            {
                return _checkOwner == 0 ? null : _checkOwner - 1;
            }
            set
            {
                _checkOwner = value == null ?  0 : value.Value + 1;
            }
        }
        private int _checkOwner;
        public bool Marked { get; set; }
        public TeamCounter[] Counters { get; set; }

        public BingoBoardSquare(string text, string tooltip)
        {
            Text = text;
            Tooltip = tooltip;
            Counters = new TeamCounter[0];
        }

        public BingoBoardSquare(byte[] buffer, ref int offset)
        {
            Text = PacketHelper.ReadString(buffer, ref offset);
            Tooltip = PacketHelper.ReadString(buffer, ref offset);
            UpdateFromStatusBytes(buffer, ref offset);
        }

        public byte[] GetBytes()
        {
            return PacketHelper.ConcatBytes(
                PacketHelper.GetStringBytes(Text),
                PacketHelper.GetStringBytes(Tooltip),
                BitConverter.GetBytes(_checkOwner),
                BitConverter.GetBytes(Marked), 
                BitConverter.GetBytes(Counters.Length),
                PacketHelper.ConcatBytes(Counters.Select(c => c.GetBytes()))
            );
        }

        public byte[] GetStatusBytes()
        {
            return PacketHelper.ConcatBytes(
               BitConverter.GetBytes(_checkOwner),
               BitConverter.GetBytes(Marked),
               BitConverter.GetBytes(Counters.Length),
               PacketHelper.ConcatBytes(Counters.Select(c => c.GetBytes()))
           );
        }

        public void UpdateFromStatusBytes(byte[] buffer, ref int offset)
        {
            _checkOwner = PacketHelper.ReadInt(buffer, ref offset);
            Marked = PacketHelper.ReadBoolean(buffer, ref offset);
            int c = PacketHelper.ReadInt(buffer, ref offset);
            Counters = new TeamCounter[c];
            for (int i = 0; i < c; ++i)
                Counters[i] = new TeamCounter(buffer, ref offset);
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
