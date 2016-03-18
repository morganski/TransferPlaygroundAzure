using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceRuntime;
using Autofac;

namespace Transfer.Background
{
    public class WorkerRole : RoleEntryPoint
    {

        public override void Run()
        {
            Trace.TraceInformation("Transfer.Background is running");

            try
            {
                this.RunAsync(_cancellationTokenSource.Token).Wait();
            }
            finally
            {
                _runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            _container = DependencyConfig.Configure();
            _bootstrapper = _container.Resolve<Bootstrapper>();
            _bootstrapper.Start();

            bool result = base.OnStart();

            Trace.TraceInformation("Transfer.Background has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("Transfer.Background is stopping");

            _cancellationTokenSource.Cancel();
            _runCompleteEvent.WaitOne();

            _bootstrapper.Stop();

            base.OnStop();

            Trace.TraceInformation("Transfer.Background has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
            }
        }

        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent _runCompleteEvent = new ManualResetEvent(false);
        private IContainer _container;
        private Bootstrapper _bootstrapper;
    }
}
