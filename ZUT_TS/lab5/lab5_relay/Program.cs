using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_relay
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 3)
            {
                Console.WriteLine("USAGE:");
                Console.WriteLine("./relay.exe <isExitNode:true|false> <port>");
                //return;

                Random random = new Random();
                for (int i = 0; true; i++)
                {
                    Console.WriteLine(i);
                    System.Threading.Thread.Sleep(random.Next(500, 5000));
                }
            }

            int port = int.Parse(args[2]);
            bool isExitNode = bool.Parse(args[1]);

            new TorRelay(isExitNode, port).start();
        }
    }
}
