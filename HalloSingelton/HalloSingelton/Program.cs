namespace HalloSingelton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            for (int i = 0; i < 20; i++)
            {
                Task.Run(() => Logger.Instance.Info("Starte App"));
            }

            Logger.Instance.Info("App läuft");
        }
    }
}