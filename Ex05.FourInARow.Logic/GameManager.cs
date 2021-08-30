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

        internal Board GameBoard
        {
            get { return m_Board; }
        }

        internal Player Player1
        {
            get { return m_Player1; }
        }

        internal Player Player2
        {
            get { return m_Player2; }
        }

        public GameManager(int i_RowsForBoard, int i_ColumnsForBoard, int i_GameMode)
        {
            bool gameVsBot = i_GameMode == (int)eGameRules.PlayerVsPc;
            m_Board = new Board(i_RowsForBoard, i_ColumnsForBoard);
            m_Player1 = new Player(k_FirstPlayerSign, k_PlayerOne, (int)eGameRules.PlayerVsPlayer);
            m_Player2 = new Player(k_SecondPlayerSign, k_PlayerTwo, i_GameMode);
        }

        public void AddPoint(int playerNumber)
        {
            if (playerNumber == m_Player1.Number)
            {
                m_Player1.Points++;
            }
            else
            {
                m_Player2.Points++;
            }
        }

        public void AddShapeToBoard(Player i_PlayigPlayer, int i_ChosenColumn)
        {
            m_Board.InsertSignToBoard(i_PlayigPlayer.Sign, i_ChosenColumn);
        }

        public bool ShouldContinue(Player i_PlayigPlayer)
        {
            return true;
        }
    }
}