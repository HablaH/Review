﻿using System;
using System.Collections.Generic;
using System.Text;
using SimpleChess;

namespace SjakkBrett
{
    class Bishop:Piece
    {
        public Bishop() : base("LPR")
        {
        }

        public override bool Move(string fromPosition, string toPosition)
        {
            var diffCol = fromPosition[0] - toPosition[0];
            var diffRow = fromPosition[1] - toPosition[1];
            return Math.Abs(diffRow) == Math.Abs(diffCol);
        }
    }
}
