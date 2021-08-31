namespace Ex05.FourInARow.Logic
{
    public class Player
    {
        private enum ePlayerSettings
        {
            PcPlayer = 1,
            HumanPlayer = 2,
        }

        private readonly char m_Sign;
        private readonly int m_PlayerNumber;
        private readonly bool m_IsBot;
        private int m_Points = 0;

        public Player(char i_Sign, int i_PlayerNumber, int i_GameMode)
        {
            m_Sign = i_Sign;
            m_PlayerNumber = i_PlayerNumber;
            m_IsBot = i_GameMode == (int)ePlayerSettings.PcPlayer;
        }

        internal int Points
        {
            get { return m_Points; }
            set { m_Points = value; }
        }

        public int Number
        {
            get { return m_PlayerNumber; }
        }

        public bool IsBot
        {
            get { return m_IsBot; }
        }

        public char Sign
        {
            get { return m_Sign; }
        }
    }
}