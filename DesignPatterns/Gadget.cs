using System.Collections.Generic;

namespace DesignPatterns
{
    internal class Shop
    {
        // Builder uses a complex series of steps
        public void Construct(GadgetBuilder gadgetBuilder)
        {
            gadgetBuilder.BuildScreen();
            gadgetBuilder.BuildCasing();
            gadgetBuilder.BuildMotherboard();
        }
    }


    ///     The 'Builder' abstract class
    internal abstract class GadgetBuilder
    {
        protected Device device;

        // Gets device instance

        public Device Device => device;

        // Abstract build methods

        public abstract void BuildScreen();
        public abstract void BuildCasing();
        public abstract void BuildMotherboard();
    }

    ///     The 'ConcreteBuilder1' class
    internal class WatchBuilder : GadgetBuilder

    {
        public WatchBuilder()
        {
            device = new Device("Watch");
        }

        public override void BuildScreen()
        {
            device["screen"] = "218 x 218 pixels";
        }

        public override void BuildCasing()
        {
            device["casing"] = "Stainless steel";
        }

        public override void BuildMotherboard()
        {
            device["motherboard"] = "Small";
        }
    }


    ///     The 'ConcreteBuilder2' class
    internal class PhoneBuilder : GadgetBuilder

    {
        public PhoneBuilder()
        {
            device = new Device("Phone");
        }

        public override void BuildScreen()
        {
            device["screen"] = "1080 x 1920 pixels";
        }

        public override void BuildCasing()
        {
            device["casing"] = "Glass";
        }

        public override void BuildMotherboard()
        {
            device["motherboard"] = "Medium";
        }
    }

    ///     The 'ConcreteBuilder3' class
    internal class LaptopBuilder : GadgetBuilder

    {
        public LaptopBuilder()
        {
            device = new Device("Laptop");
        }

        public override void BuildScreen()
        {
            device["screen"] = "1920 x 1080 pixels";
        }

        public override void BuildCasing()
        {
            device["casing"] = "Plastic";
        }

        public override void BuildMotherboard()
        {
            device["motherboard"] = "Large";
        }
    }

    ///     The 'Product' class
    internal class Device

    {
        private readonly string _deviceType;

        private readonly Dictionary<string, string> _parts =
            new Dictionary<string, string>();

        // Constructor

        public Device(string deviceType)
        {
            _deviceType = deviceType;
        }

        // Indexer

        public string this[string key]
        {
            get => _parts[key];
            set => _parts[key] = value;
        }

        public void Show()
        {
            System.Console.WriteLine("Device Type: {0}", _deviceType);
            System.Console.WriteLine(" Screen resolution : {0}", _parts["screen"]);
            System.Console.WriteLine(" casing material : {0}", _parts["casing"]);
            System.Console.WriteLine(" motherboard size: {0}", _parts["motherboard"]);
            System.Console.WriteLine("\n");
        }
    }
}