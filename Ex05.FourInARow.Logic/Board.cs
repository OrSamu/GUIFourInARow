using System.Drawing;

namespace Ex05.FourInARow.Logic
{
    public class Board
    {
        private const char k_EmptyColumn = ' ';
        private const int k_FirstCol = 0;
        private const int k_FirstRow = 0;
        private const int k_InARow = 4;

        private readonly int r_Rows;
        private readonly int r_Columns;
        private readonly char[,] r_Board;

        public Board(int i_RowsFromUser, int i_ColsFromUser)
        {
            r_Rows = i_RowsFromUser;
            r_Columns = i_ColsFromUser;
            r_Board = new char[r_Rows, r_Columns];
            InitializeBoard();
        }

        public char[,] GameBoard => r_Board;

        public int Rows => r_Rows;

        public int Cols => r_Columns;

        internal void InitializeBoard()
        {
            for (int i = 0; i < r_Rows; i++)
            {
                for (int j = 0; j < r_Columns; j++)
                {
                    r_Board[i, j] = k_EmptyColumn;
                }
            }
        }

        public bool IsColumnFull(int i_Column)
        {
            bool isFull = false;

            isFull = r_Board[k_FirstRow, i_Column] != k_EmptyColumn;

            return isFull;
        }

        public bool IsBoardFull()
        {
            bool isBoardFull = true;

            for (int i = 0; i < r_Columns; i++)
            {
                if (!IsColumnFull(i))
                {
                    isBoardFull = false;
                    break;
                }
            }

            return isBoardFull;
        }

        public Point InsertSignToBoard(char i_Sign, int i_Col)
        {
            Point insertedObj = new Point(-1, -1);
            if (!IsColumnFull(i_Col))
            {
                int rowToInsert = 0;

                for (int i = 0; i < r_Rows - 1; i++)
                {
                    if ((r_Board[i + 1, i_Col] != k_EmptyColumn))
                    {
                        rowToInsert = i;
                        break;
                    }
                    else if (i + 1 == r_Rows - 1)
                    {
                        rowToInsert = i + 1;
                        break;
                    }
                }

                updateBoard(i_Sign, rowToInsert, i_Col);
                insertedObj = new Point(i_Col, rowToInsert);
            }

            return insertedObj;
        }

        private void updateBoard(char i_Sign, int i_Row, int i_Column)
        {
            r_Board[i_Row, i_Column] = i_Sign;
        }

        public bool IsFourInARow(char i_Sign, int i_CurrentRow, int i_CurrentCol)
        {
            bool isFourInArow = false;
            bool verticalLine = isVerticalLine(i_Sign, i_CurrentRow, i_CurrentCol);
            bool balancedLine = isBalancedLine(i_Sign, i_CurrentRow, i_CurrentCol);
            bool diagonalLine = isDiagonalLine(i_Sign, i_CurrentRow, i_CurrentCol);
            bool inverterDiagonalLine = isInvertedDiagonalLine(i_Sign, i_CurrentRow, i_CurrentCol);

            if (balancedLine || verticalLine || diagonalLine || inverterDiagonalLine)
            {
                isFourInArow = true;
            }

            return isFourInArow;
        }

        public bool DidPlayerMakeFourInARow(Player i_PlayingPlayer, int i_ChosenCol)
        {
            bool result;
            int rowPlace;

            rowPlace = getTopRow(i_ChosenCol);
            result = IsFourInARow(i_PlayingPlayer.Sign, rowPlace, i_ChosenCol);

            return result;
        }

        private int getTopRow(int i_CheckedCol)
        {
            int topRow = 0;
            for (int i = 0; i < r_Rows; i++)
            {
                if (r_Board[i, i_CheckedCol] != k_EmptyColumn)
                {
                    topRow = i;
                    break;
                }
            }

            return topRow;
        }

        private bool isBalancedLine(char i_Sign, int i_CurrentRow, int i_CurrentCol)
        {
            bool isFourInArow = false;
            int leftCount = getLeftCount(i_Sign, i_CurrentRow, i_CurrentCol - 1);
            int rightCount = getRightCount(i_Sign, i_CurrentRow, i_CurrentCol + 1);
            if (1 + leftCount + rightCount >= k_InARow)
            {
                isFourInArow = true;
            }

            return isFourInArow;
        }

        private int getLeftCount(char i_Sign, int i_CurrentRow, int i_CurrentCol)
        {
            int signCount = 0;
            for (int i = 0; i < k_InARow - 1; i++)
            {
                if (i_CurrentCol - i >= k_FirstCol)
                {
                    if (r_Board[i_CurrentRow, i_CurrentCol - i] == i_Sign)
                    {
                        signCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return signCount;
        }

        private int getRightCount(char i_Sign, int i_CurrentRow, int i_CurrentCol)
        {
            int signCount = 0;
            for (int i = 0; i < k_InARow - 1; i++)
            {
                if (i_CurrentCol + i <= r_Columns - 1)
                {
                    if (r_Board[i_CurrentRow, i_CurrentCol + i] == i_Sign)
                    {
                        signCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return signCount;
        }

        private bool isVerticalLine(char i_Sign, int i_CurrentRow, int i_CurrentCol)
        {
            bool isArow = false;
            int signCount = 1;
            for (int i = 1; i < k_InARow; i++)
            {
                if (i_CurrentRow + i <= r_Rows - 1)
                {
                    if (r_Board[i_CurrentRow + i, i_CurrentCol] == i_Sign)
                    {
                        signCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            if (signCount == k_InARow)
            {
                isArow = true;
            }

            return isArow;
        }

        private bool isDiagonalLine(char i_Sign, int i_CurrentRow, int i_CurrentCol)
        {
            bool diagonalLine = false;
            int leftDownCount = getLeftDownCount(i_Sign, i_CurrentRow + 1, i_CurrentCol - 1);
            int upRightCount = getupRightCount(i_Sign, i_CurrentRow - 1, i_CurrentCol + 1);
            if (1 + leftDownCount + upRightCount >= k_InARow)
            {
                diagonalLine = true;
            }

            return diagonalLine;
        }

        private int getLeftDownCount(char i_Sign, int i_CurrentRow, int i_CurrentCol)
        {
            int signCount = 0;
            for (int i = 0; i < k_InARow - 1; i++)
            {
                if ((i_CurrentCol - i >= k_FirstCol) && (i_CurrentRow + i <= r_Rows - 1))
                {
                    if (r_Board[i_CurrentRow + i, i_CurrentCol - i] == i_Sign)
                    {
                        signCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return signCount;
        }

        private int getupRightCount(char i_Sign, int i_CurrentRow, int i_CurrentCol)
        {
            int signCount = 0;
            for (int i = 0; i < k_InARow - 1; i++)
            {
                if ((i_CurrentCol + i <= r_Columns - 1) && (i_CurrentRow - i >= k_FirstRow))
                {
                    if (r_Board[i_CurrentRow - i, i_CurrentCol + i] == i_Sign)
                    {
                        signCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return signCount;
        }

        private int getRightDownCount(char i_Sign, int i_CurrentRow, int i_CurrentCol)
        {
            int signCount = 0;
            for (int i = 0; i < k_InARow - 1; i++)
            {
                if ((i_CurrentCol + i <= r_Columns - 1) && (i_CurrentRow + i <= r_Rows - 1))
                {
                    if (r_Board[i_CurrentRow + i, i_CurrentCol + i] == i_Sign)
                    {
                        signCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return signCount;
        }

        private int getLeftUpCount(char i_Sign, int i_CurrentRow, int i_CurrentCol)
        {
            int signCount = 0;
            for (int i = 0; i < k_InARow - 1; i++)
            {
                if ((i_CurrentCol - i >= k_FirstCol) && (i_CurrentRow - i >= k_FirstRow))
                {
                    if (r_Board[i_CurrentRow - i, i_CurrentCol - i] == i_Sign)
                    {
                        signCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return signCount;
        }

        private bool isInvertedDiagonalLine(char i_Sign, int i_CurrentRow, int i_CurrentCol)
        {
            bool invertedDiagonalLine = false;
            int rightDownCount = getRightDownCount(i_Sign, i_CurrentRow + 1, i_CurrentCol + 1);
            int upRightCount = getLeftUpCount(i_Sign, i_CurrentRow - 1, i_CurrentCol - 1);
            if (1 + rightDownCount + upRightCount >= k_InARow)
            {
                invertedDiagonalLine = true;
            }

            return invertedDiagonalLine;
        }
    }
}