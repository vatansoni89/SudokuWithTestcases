using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SudokuGrid
    {

        private int?[,] vals = new int?[9, 9];
        public int? this[int row, int column]
        {
            get { return vals[row - 1, column - 1]; }
            set
            {
                vals[row - 1, column - 1] = value;
            }
        }

        public override string ToString()
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine();

            for (int row = 1; row <= 9; row++)
            {

                for (int column = 1; column <= 9; column++)
                {

                    sb.Append(this[row, column] + " ");

                }

                sb.AppendLine();

            }

            return sb.ToString();

        }

        public void Solve()
        {

            for (int column = 1; column <= 9; column++)
            {

                for (int row = 1; row <= 9; row++)
                {

                    if (TrySolving(row, column))

                    {

                        Console.Clear();

                        Console.WriteLine(this.ToString());

                        System.Threading.Thread.Sleep(200);


                    }

                }

            }

        }

        private bool TrySolving(int row, int column)
        {

            List<RowColumnValue> possibleValuesFound = new List<RowColumnValue>();

            if (this[row, column] == null)
            {

                for (int possiblevalues = 1; possiblevalues <= 9; possiblevalues++)
                {

                    if (!DoesRowContainValue(possiblevalues, row, column))
                    {

                        if (!DoesColumnContainValue(possiblevalues, row, column))

                        {

                            if (!DoesSquareContainValue(possiblevalues, row, column))
                            {

                                possibleValuesFound.Add(new RowColumnValue(row, column, possiblevalues));

                            }

                        }

                    }

                }



                if (possibleValuesFound.Count == 1)
                {

                    this[possibleValuesFound[0].Row, possibleValuesFound[0].Column] = possibleValuesFound[0].Value;

                    return true;

                }
            }

            return false;

        }

        private bool DoesRowContainValue(int value, int row, int column)
        {

            for (int columnindex = 1; columnindex <= 9; columnindex++)

            {

                if ((this[row, columnindex] == value) & column != columnindex)

                {

                    return true;

                }

            }

            return false;

        }

        private bool DoesColumnContainValue(int value, int row, int column)
        {

            for (int rowindex = 1; rowindex <= 9; rowindex++)

            {

                if ((this[rowindex, column] == value) & row != rowindex)

                {

                    return true;

                }

            }

            return false;

        }

        private bool DoesSquareContainValue(int value, int row, int column)
        {

            //identify square
            //As end of section is definite so we calculate end first and based on that we define start.

            int rowStart = ((row - 1) / 3) + 1;

            int columnStart = ((column - 1) / 3) + 1;



            int rowIndexEnd = rowStart * 3;



            int rowIndexStart = rowIndexEnd - 2;



            int columnIndexEnd = columnStart * 3;



            int columnIndexStart = columnIndexEnd - 2;



            for (int rowIndex = rowIndexStart; rowIndex <= rowIndexEnd; rowIndex++)

            {

                for (int columnIndex = columnIndexStart; columnIndex <= columnIndexEnd; columnIndex++)

                {

                    if ((this[rowIndex, columnIndex] == value) & (columnIndex != column) & (rowIndex != row))

                    {

                        return true;

                    }

                }

            }

            return false;

        }

        public void PopulateGrid(int? [] arr)
        {

            //    {
            //4,3,5,2,6,9,7,8,1,
            //6,8,2,5,7,1,4,9,3,
            //1,9,7,8,3,4,5,6,2,
            //8,2,6,1,9,5,3,4,7,
            //3,7,4,6,8,2,9,1,5,
            //9,5,1,7,4,3,6,2,8,
            //5,1,9,3,2,6,8,7,4,
            //2,4,8,9,5,7,1,3,6,
            //7,6,3,4,1,8,2,5,9
            //};

           

            int i = 0;
            for (int row = 1; row <= 9; row++)
            {
                for (int column = 1; column <= 9; column++)
                {
                    this[row, column] = arr[i++];
                }

            }
        }
    }

    internal class RowColumnValue
    {

        private int row;



        internal int Row

        {

            get { return row; }

        }



        private int column;



        internal int Column

        {

            get { return column; }

        }



        private int value;



        internal int Value

        {

            get { return value; }

        }



        internal RowColumnValue(int r, int c, int v)
        {

            row = r;

            column = c;

            value = v;

        }
    }

    class Program
    {
        //public SudokuGrid grid = new SudokuGrid();
        static void Main(string[] args)
        {
            int?[] arr =
               {
            4,3,5,2,6,9,7,8,1,
            6,8,2,5,7,1,4,9,3,
            1,9,7,8,3,4,5,6,null,
            8,2,6,1,9,5,3,4,7,
            3,7,4,6,8,2,9,1,5,
            9,5,1,7,4,3,6,2,8,
            5,1,9,3,2,6,8,7,4,
            2,4,8,9,5,7,1,3,6,
            7,6,3,4,1,8,2,5,null
            };

            SudokuGrid grid = new SudokuGrid();
            grid.PopulateGrid(arr);
            Console.WriteLine(grid.ToString());
            Console.WriteLine("Hit Enter to Begin Solving!!");
            Console.Read();
            // Start Solving.
            grid.Solve();
            Console.WriteLine("Done !!!");
            Console.WriteLine(grid.ToString());
            Console.ReadLine();
            Console.ReadKey();
        }


    }
}