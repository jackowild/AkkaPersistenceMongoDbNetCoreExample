using Akka.Actor;
using System;

namespace AkkaPersistenceMongoDbNetCoreExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a command");

            ExampleActorSystem.Start();

            string command = string.Empty;
            while (command != "exit")
            {
                command = Console.ReadLine();

                if (command != "exit")
                {
                    ExampleActorSystem.ExampleActor.Tell(command);
                }
            }

            ExampleActorSystem.Stop();
        }
    }
}
