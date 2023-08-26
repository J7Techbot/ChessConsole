using DomainLayer.Helpers;
using HW2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Models.Pieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(Position defaultPosition, Color color) : base(defaultPosition, color)
        {
            chessPieceType = ChessPieceType.PAWN;
        }

        public override bool ValidateMove(Position nextPosition)
        {
            List<Position> allVerticals = PositionHelper.GetVerticals(currentPosition, distance: 1);
            List<Position> allDiagonals = PositionHelper.GetDiagonals(currentPosition, distance: 1);

            if(color == Color.WHITE)
            {
                allVerticals.RemoveAll(position => position.X > currentPosition.X);
                allDiagonals.RemoveAll(position => position.X > currentPosition.X);
            }
            else
            {
                allVerticals.RemoveAll(position => position.X < currentPosition.X);
                allDiagonals.RemoveAll(position => position.X < currentPosition.X);
            }

            if (allVerticals.Contains(nextPosition) || allDiagonals.Contains(nextPosition))
                return true;

            return false;
        }
    }
}
