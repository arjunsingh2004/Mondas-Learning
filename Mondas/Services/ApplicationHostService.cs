using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Mondas.Views; // Make sure this using statement points to where your Start.cs is

namespace Mondas.Services
{
    public class ApplicationHostService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public ApplicationHostService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // This is the code that now runs at startup.
            // It gets your "Start" form and shows it.

            var startForm = _serviceProvider.GetRequiredService<Start>();
            startForm.Show();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // This code ensures the application exits cleanly when the host stops.
            Application.Exit();
            return Task.CompletedTask;
        }
    }
}