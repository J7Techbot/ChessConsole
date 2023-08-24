using HW2.Enums;
using HW2.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Models.Pieces
{
    /// <summary>
    /// Base class for all chess pieces.
    /// </summary>
    public abstract class ChessPiece
    {
        protected Position currentPosition;
        protected ChessPieceType chessPieceType;
        protected Color color;

        public ChessPiece(Position defaultPosition, Color color)
        {
            this.currentPosition = defaultPosition;
            this.color = color;
        }

        public Position GetCurrentPosition()
        {
            return currentPosition;
        }

        public ChessPieceType GetPieceType()
        {
            return chessPieceType;
        }
        public abstract void Move(Position nextPosition);

        public override string ToString()
        {
            return $"{color.GetDescription()}{chessPieceType.GetDescription()}";
        }
    }
}
