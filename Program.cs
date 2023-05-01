using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace algo1
{
    internal class Program
    {
        private static HashSet<int> attacedRows = new HashSet<int>();
        private static HashSet<int> attacedCouls = new HashSet<int>();
        private static HashSet<int> attacedLeftDiagonal = new HashSet<int>();
        private static HashSet<int> attacedRightDiagonal = new HashSet<int>();
        static void Main(string[] args)
        {
           
            /*  sum
              var nums = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToArray();

              Console.WriteLine(Sum(nums,0));
            */

            /* draw \ fact
            int x= Convert.ToInt32(Console.ReadLine());

              // Console.WriteLine(Facturiel(x));
              // DrawFig(x);
                  */


            /*  the path in matrix
           int rows = int.Parse(Console.ReadLine());
           int couls = int.Parse(Console.ReadLine());

            var lab = new char[rows,couls];

            for (int r = 0; r < rows; r++) 
            {
                var colElements = Console.ReadLine();
                for (int c = 0; c < couls; c++) 
                {
                    lab[r, c] = colElements[c];
                }
            }
            FindPaths(lab, 0, 0, new List<string>(), string.Empty);
           */
           
            /* 8 Queens
            var board = new bool[8, 8];
            PutQueens(board, 0);
            */
        }
        // 8 Queend  *****************************************************************************
        static void PutQueens(bool[,] board, int row)
        {
            if(row >= board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }
            for (int col = 0; col < board.GetLength(1); col++) 
            {
                if (CanPlaceQuenn(row,col))
                {
                    attacedRows.Add(row);
                    attacedCouls.Add(col);
                    attacedLeftDiagonal.Add(row - col);
                    attacedRightDiagonal.Add(row + col);
                    board[row,col] = true;

                    PutQueens(board, row + 1);

                    attacedRows.Remove(row);
                    attacedCouls.Remove(col);
                    attacedLeftDiagonal.Remove(row - col);
                    attacedRightDiagonal.Remove(row + col);
                    board[row,col] = false;
                }
            }
        }
        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row,col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        private static bool CanPlaceQuenn(int row, int col)
        {
            return !attacedRows.Contains(row) && !attacedCouls.Contains(col) &&
                   !attacedLeftDiagonal.Contains(row - col) && !attacedRightDiagonal.Contains(row + col);
        }
        // ***************************************************************************************

        static int Sum(int[] array,int index)
        {
            if(index == array.Length -1)
                return array[index];

            return array[index] + Sum(array, index+1);
        }
        // Finds the facturiel of the input (3!)
        static int Facturiel(int x)
        {
            if (x == 0) 
                return 1;
           
            return x * Facturiel(x-1);
        }
        // Draws howrglass with * by the input number
        static void DrawFig(int row)
        {
            if (row == 0)  { return; }
           
           Console.WriteLine(new string('*',row));
            DrawFig(row-1);
           Console.WriteLine(new string('#',row));

        }
        // Finds all paths in Matrix
        static void FindPaths(char[,] lab, int row, int coul, List<string> directions, string direction)
        {
            // Validate row & coul
            if (row < 0 || row >= lab.GetLength(0) || coul < 0 || coul >= lab.GetLength(1)) 
            {
                return;
            }
            // Check for walls
            if (lab[row,coul] == '*' || lab[row,coul] == 'v')
            {
                return;
            }
            directions.Add(direction);
            // Check for exit
            if (lab[row, coul] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            lab[row, coul] = 'v';

            FindPaths(lab, row - 1, coul, directions, "U");
            FindPaths(lab, row + 1, coul, directions, "D");
            FindPaths(lab, row, coul - 1, directions, "L");
            FindPaths(lab, row, coul + 1, directions, "R");

            lab[row, coul] = '-';
            directions.RemoveAt(directions.Count - 1);
        }
    }
}
