using System.Windows.Forms;

namespace Ex05.FourInARow.UserInterface
{
    public class Program
    {
        public static void Main()
        {
            UIManager fourInARowUIManager = new UIManager();
            fourInARowUIManager.StartGame();
        }
    }
}