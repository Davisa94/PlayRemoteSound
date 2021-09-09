using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string songName = "";
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"Args at {i} is: ");
                Console.WriteLine(args[i]);
                Console.WriteLine(args.Length);
            }
            if (args.Length >= 1)
            {
                songName = args[0];
            }
            else
            {
                songName = "beans.mp3";
            }

            var input = new HelloRequest { Name = songName };
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(input);

            Console.WriteLine(reply.Message);

            //Console.ReadLine();
        }
    }
}
