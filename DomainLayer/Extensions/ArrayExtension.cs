using HW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Extensions
{
    public static class ArrayExtension
    {
        public static bool Contains(this object[,] chessBoards,int x,int y)
        {
            try
            {
                if(chessBoards[x,y] == null)
                    return false;
            }
            catch 
            { 
                return false; 
            }

            return true;
        }
    }
}
