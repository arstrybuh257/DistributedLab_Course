using Autofac;
using Microsoft.Extensions.Configuration;
using DuckCoin.DataAccess.Mongo;

namespace DuckCoin.Wallet
{
    internal static class Program
    {
        public static IContainer Container;
        public static IConfiguration Configuration;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();

            Container = Configure();
            Application.Run(new MainForm());
        }

        static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.AddMongo();
            builder.RegisterType<MainForm>();
            return builder.Build();
        }
    }
}