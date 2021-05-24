//https://www.dofactory.com/net/design-patterns

using System;
using System.ComponentModel;
using System.Threading.Tasks;
using DesignPatterns;
using Singleton;

namespace Console.App
{
    public class Program
    {
        public Program(ILogger logger)
        {
        }
        public static async Task Main(string[] args)
        {
            //Register DI here

            //Run program
            var program = new Program(Logger.GetLogger());
            await program.Run(args);
        }

        /* Alternative Main method

        public static void Main(string[] args)
        {
            //registerDi
            var program = new Program(new Logger());
            var task = program.Run(args);
            task.Wait();
        }
        */

        public async Task Run(string[] args)
        {
            //Singleton 

            Logger.GetLogger().Log("Test message", LogVerbosity.Warn);
            Logger.Instance.Log("Test message", LogVerbosity.Warn);

            System.Console.WriteLine("---------------------------\n");

            //Builder pattern

            SpeciesFactory dog = new DogFactory();
            AnimalWorld world = new AnimalWorld(dog);
            world.RunFoodChain();

            SpeciesFactory cat = new CatFactory();
            world = new AnimalWorld(cat);
            world.RunFoodChain();

            System.Console.WriteLine("---------------------------\n");

            //Abstract factory

            GadgetBuilder builder;
            Shop shop = new Shop();

            builder = new LaptopBuilder();
            shop.Construct(builder);
            builder.Device.Show();

            builder = new PhoneBuilder();
            shop.Construct(builder);
            builder.Device.Show();

            builder = new WatchBuilder();
            shop.Construct(builder);
            builder.Device.Show();

            System.Console.WriteLine("---------------------------\n");

            //End program
            System.Console.WriteLine("Program finished");
            System.Console.ReadLine();
        }
    }

    /*
     * SINGLETON METHODS
     */

    //public sealed class Logger : ILogger
    //{
    //    private static Logger _logger;
    //    private static readonly Logger _logger3 = new Logger();
    //    private static readonly object _syncLock = new object(); //Static - use access

    //    private Logger() {}

    //    // Explicit static constructor to tell C# compiler
    //    // not to mark type as beforefieldinit
    //    static Logger()
    //    {
    //    }

    //    public void Log(string message, LogVerbosity verbosity)
    //    {
    //        var logMessage = $"[{verbosity}] - {DateTimeOffset.UtcNow:R} - {message}";
    //        System.Console.WriteLine(logMessage);
    //        if (verbosity == LogVerbosity.Critical)
    //        {
    //            throw new Exception(logMessage);
    //        }
    //    }

    //    /*
    //     * Singleton 1
    //     * Simple - Not Thread safe
    //     */
    //    public static Logger GetLogger()
    //    {
    //        if (_logger == null)
    //        {
    //            _logger = new Logger();
    //        }

    //        return _logger;
    //    }

    //    //rather
    //    public static Logger Instance {
    //        get
    //        {
    //            if (_logger == null)
    //            {
    //                _logger = new Logger();
    //            }

    //            return _logger;
    //        }

    //    }

    //    /*
    //     * Singleton 2
    //     * Double Check Lock - Thread Safe
    //     */
    //    public static Logger GetLogger2()
    //    {
    //        if (_logger == null) //Don't go into lock every time - to prevent dead locking
    //        {
    //            lock (_syncLock)
    //            {
    //                if (_logger == null)
    //                {
    //                    _logger = new Logger();
    //                }
    //            }
    //       }

    //        return _logger;
    //    }

    //    /*
    //     * Singleton 3
    //     * Static Initialisation - Must Hav Static Constructor - probably most performant
    //     */
    //    public static Logger GetLogger3()
    //    {
    //        return _logger3;
    //    }

    //    /*
    //     * Singleton 4
    //     * Lazy Version
    //     */
    //    private static readonly Lazy<Logger> _lazy = new Lazy<Logger>(() => new Logger());
    //    public static Logger Instance4 => _lazy.Value;

    //    //public static Logger Instance4
    //    //{
    //    //    get { return _lazy.Value; }
    //    //}
    //    #endregion

    //}
    //public interface ILogger
    //{
    //    void Log(string message, LogVerbosity verbosity);
    //}
    //public enum LogVerbosity
    //{
    //    Trace,
    //    Debug,
    //    Info,
    //    Warn,
    //    Error,
    //    Critical
    //}
}
