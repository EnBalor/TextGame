using System.Security.Cryptography.X509Certificates;

namespace TextGame
{
    internal class MainScene
    {
        public static List<object> itemList = new List<object>();

        static void Main(string[] args)
        {
            StartScene startScene = new StartScene();
            startScene.Print();
        }

        
    }
}