using Client.Services;
using Client.Entities;


namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IClient client = new Entities.Client();
            client.SendRequest(args);
        }
    }
}