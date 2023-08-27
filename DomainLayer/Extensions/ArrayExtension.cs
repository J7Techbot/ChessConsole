namespace HW2.Extensions
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
