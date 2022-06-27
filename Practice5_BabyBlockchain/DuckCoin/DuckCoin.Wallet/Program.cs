using Autofac;
using Microsoft.Extensions.Configuration;
using DuckCoin.DataAccess.Mongo;
using System.Reflection;
using DuckCoin.Wallet.DomainModels;
using DuckCoin.Cryptography.Encryption;
using DuckCoin.Cryptography.Hashing;
using DuckCoin.Wallet.HttpClients;

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
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            Container = Configure();
            Application.Run(Container.Resolve<MainForm>());
        }

        static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces();
            builder.RegisterType<RSAEncryptor>().As<IEncryptor>().SingleInstance();
            builder.RegisterType<SHA1Hash>().As<IHashFunction>().SingleInstance();
            builder.AddMongo(Configuration);
            builder.RegisterType<FullNodeHttpClient>().As<IFullNodeHttpClient>().SingleInstance();
            builder.AddMongoRepository<Account>("Accounts");
            builder.AddMongoRepository<Transaction>("Transactions");
            builder.RegisterType<MainForm>().SingleInstance();
            return builder.Build();
        }
    }
}