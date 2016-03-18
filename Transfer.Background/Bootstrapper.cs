using Akka.Actor;
using System.Collections.Generic;
using System.Linq;
using Transfer.Background.Interfaces;

namespace Transfer.Background
{
    public class Bootstrapper
    {
        public Bootstrapper(IEnumerable<IStartup> startups, ActorSystem system)
        {
            _startups = startups.ToList();
            _system = system;
        }

        public void Start()
        {
            _startups.ForEach(s => s.Start());
        }

        public void Stop()
        {
            var shutdownTask = _system.Terminate();
            shutdownTask.Wait();
        }

        private readonly List<IStartup> _startups;
        private readonly ActorSystem _system;
    }
}
