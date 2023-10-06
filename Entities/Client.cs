using Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Entities
{
    public class Client : IClient
    {
        const int lengthForGet = 2;
        const int lengthForSet = 3;
        const string get = "get";
        const string set = "set";
        
        public Client() { }
        public void SendRequest(string[] args)
        {
            HttpClient client = new HttpClient();
            IHttpMethods httpMethods = new HttpMethods(client);
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case get:
                        if (args.Length >= lengthForGet)
                        {
                            httpMethods.GetAsync(args[1]);
                        }
                        else
                        {
                            Console.WriteLine("Unreal args for get method");
                        }

                        break;
                    case set:
                        if (args.Length == lengthForSet)
                        {
                            httpMethods.PutAsync(args[1], args[2]);
                        }
                        break;
                    default:
                        Console.WriteLine("Unreal args or comand");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Unreal args for any commands!");
            }
        }
    }
}
