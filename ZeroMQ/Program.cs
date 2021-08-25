using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;

namespace ZeroMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread( ()=> {

                // implementing publisher
                Console.WriteLine("Publisher is starting...");
                Random rnd = new Random();
                using (var pubSocket = new PublisherSocket())
                {
                    // bind publisher to TCP socket
                    pubSocket.Bind("tcp://*:12345");
                    for (int i = 0; i < 100; i++)
                    {
                        string topic = rnd.NextDouble() > 0.5 ? "topicA" : "topicB";
                        string msg = $"{topic} - {i}";
                        pubSocket.SendMoreFrame(topic).SendFrame(msg);
                        Console.WriteLine($"PUBLISHER: {msg}");
                        Thread.Sleep(1000);
                    }
                }

            } ).Start();

            using (var subSocket = new SubscriberSocket())
            {
                subSocket.Connect("tcp://localhost:12345"); //connecting to publisher
                //subSocket.Subscribe("topicA"); // how to subscribe messages from desired topic
                subSocket.SubscribeToAnyTopic(); // subSocket.Subscribe("");
                Console.WriteLine("Receiving messages...");
                while (true)
                {
                    string topic = subSocket.ReceiveFrameString(); // receiving topic
                    string msg = subSocket.ReceiveFrameString();
                    Console.WriteLine($"RECEIVED: {topic} - {msg}");
                }
            }

            Console.ReadKey();

        }
    }
}
