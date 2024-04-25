using System.Security.Cryptography.X509Certificates;

namespace TextGame
{
    internal class MainScene
    {
        static void Main(string[] args)
        {
            StartScene startScene = new StartScene();
            startScene.Print();
        }
    }
}