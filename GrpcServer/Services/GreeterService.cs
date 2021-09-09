using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NAudio;

namespace GrpcServer
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            const string soundsFolder = "D:\\Documents\\Stream\\sounds\\";
            string fullSoundPath = $"{soundsFolder}{request.Name}";
            Console.WriteLine(fullSoundPath);
            PlayLocalSound.PlayAll(fullSoundPath);
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
