namespace AkkaPersistenceMongoDbNetCoreExample
{
    using Akka.Event;
    using Akka.Persistence;

    public class ExampleActor : ReceivePersistentActor
    {
        public override string PersistenceId => "ExampleActor";

        private ILoggingAdapter logger = Context.GetLogger();

        public ExampleActor()
        {
            this.Command<string>(msg => this.Persist(msg, _ => this.logger.Info(msg)));
            this.Recover<string>(msg => this.logger.Info($"Recovered: {msg}"));
        }
    }
}
