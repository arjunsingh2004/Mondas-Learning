using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Mondas.Contracts.Services;
using Mondas.Contracts.Views;
using Mondas.Models;
using Mondas.Services;
using Mondas.Views;

namespace Mondas
{
    internal static class Program
    {
        public static IHost _host;

        public static T GetService<T>()
            where T : class
            => _host.Services.GetService(typeof(T)) as T;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //Register Syncfusion license https://help.syncfusion.com/common/essential-studio/licensing/how-to-generate
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JGaF5cXGpCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdlWX1fdXVQRmReUExzV0BWYEs=");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var baseDir = AppContext.BaseDirectory;

            SQLitePCL.Batteries_V2.Init();

            var init = new Mondas.Services.SqliteDatabaseInitializer (Path.Combine(baseDir, "mondas.db"), Path.Combine(baseDir, "Resources", "questions.json"));

            init.Initialize();

            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            Application.Run(new Start());
        }
    }
}