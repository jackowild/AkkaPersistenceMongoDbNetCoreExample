namespace AkkaPersistenceMongoDbNetCoreExample
{
    using Akka.Actor;
    using Akka.Configuration;
    using Akka.Persistence.MongoDb;

    public class ExampleActorSystem
    {
        public static ActorSystem ExampleSystem { get; private set; }

        public static IActorRef ExampleActor { get; private set; }

        public static void Start()
        {
            var config = ConfigurationFactory.ParseString(@"
                akka.persistence {
                    journal {
                        plugin = ""akka.persistence.journal.mongodb""
                        mongodb {
                            connection-string = ""mongodb://127.0.0.1:27017/example""
                        }
                    }
                }");

            ExampleSystem = ActorSystem.Create("ExampleSystem", config);

            MongoDbPersistence.Get(ExampleSystem);

            ExampleActor = ExampleSystem.ActorOf<ExampleActor>();
        }

        public static void Stop()
        {
            ExampleSystem.Terminate().Wait();
        }
    }
}
