using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Models
{
    public class GameManager
    {
        private ChessBoard chessBoard;
        public GameManager()
        {
            chessBoard = new ChessBoard();

            chessBoard.DrawChessBoard();
        }
    }
}
