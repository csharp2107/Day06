using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;

namespace ZeroMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // implementing publisher
            Random rnd = new Random();
            using (var pubSocket = new PublisherSocket())
            {
                // bind publisher to TCP socket
                pubSocket.Bind("tcp://*:12345");
                for (int i = 0; i < 100; i++)
                {
                    string topic = "topicA";
                    if (rnd.NextDouble() > 0.5)
                        topic = "topicB";
                    string msg = $"{topic} - {i}";
                    pubSocket.SendMoreFrame(topic).SendFrame(msg);
                    Console.WriteLine($"PUBLISHER: {msg}");
                }
            }

        }
    }
}
