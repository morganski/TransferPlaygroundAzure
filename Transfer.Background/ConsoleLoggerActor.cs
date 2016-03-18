using Akka.Actor;
using Akka.Event;
using System.Diagnostics;

namespace Transfer.Background
{
    public class ConsoleLoggerActor : ReceiveActor
    {
        public ConsoleLoggerActor()
        {
            Receive<InitializeLogger>(msg => OnInitialized(msg));
            Receive<LogEvent>(msg => OnLogEvent(msg));
        }

        private void OnInitialized(InitializeLogger msg)
        {
            Trace.WriteLine("Logging started");
            Sender.Tell(new LoggerInitialized());
        }

        private void OnLogEvent(LogEvent @event)
        {
            Trace.WriteLine(@event);
        }
    }
}
