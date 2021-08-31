using System.Drawing;

namespace Ex05.FourInARow.Logic
{
    public class GameManager
    {
        private enum eGameRules
        {
            PlayerVsPc = 1,
            PlayerVsPlayer = 2,
            MinNumOfRowOrCol = 4,
            MaxNumOfRowOrCol = 8
        }

        private const char k_FirstPlayerSign = 'X';
        private const char k_SecondPlayerSign = 'O';
        private const int k_PlayerOne = 1;
        private const int k_PlayerTwo = 2;

        private readonly Board m_Board;
        private readonly Player m_Player1;
        private readonly Player m_Player2;
        private int m_CurrentPlayer = 1;

        public Board GameBoard
        {
            get { return m_Board; }
        }

        public Player Player1
        {
            get { return m_Player1; }
        }

        public Player Player2
        {
            get { return m_Player2; }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer == k_PlayerOne ? m_Player1 : m_Player2;
            }
        }

        public void SwitchCurrentPlayer()
        {
            m_CurrentPlayer = m_CurrentPlayer == k_PlayerOne ? k_PlayerTwo : k_PlayerOne;
        }

        public GameManager(int i_RowsForBoard, int i_ColumnsForBoard, int i_GameMode)
        {
            bool gameVsBot = i_GameMode == (int)eGameRules.PlayerVsPc;
            m_Board = new Board(i_RowsForBoard, i_ColumnsForBoard);
            m_Player1 = new Player(k_FirstPlayerSign, k_PlayerOne, (int)eGameRules.PlayerVsPlayer);
            m_Player2 = new Player(k_SecondPlayerSign, k_PlayerTwo, i_GameMode);
        }

        public void AddPoint(int i_PlayerNumber)
        {
            if (i_PlayerNumber == m_Player1.Number)
            {
                m_Player1.Points++;
            }
            else
            {
                m_Player2.Points++;
            }
        }

        public int GetPoint(int i_PlayerNumber)
        {
            int points = 0;

            if (i_PlayerNumber == m_Player1.Number)
            {
                points = m_Player1.Points;
            }
            else
            {
                points = m_Player2.Points;
            }

            return points;
        }

        public Point AddShapeToBoard(Player i_PlayigPlayer, int i_ChosenColumn)
        {
            return m_Board.InsertSignToBoard(i_PlayigPlayer.Sign, i_ChosenColumn);
        }

        public void ResetBoard()
        {
            m_Board.InitializeBoard();
        }
    }
}