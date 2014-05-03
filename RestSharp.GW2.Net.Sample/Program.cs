// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET.Sample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using global::GW2DotNET.V1;
    using global::GW2DotNET.V1.Colors;
    using global::GW2DotNET.V1.Common;
    using global::GW2DotNET.V1.DynamicEvents.Contracts;
    using global::GW2DotNET.V1.Errors;

    using Ninject;

    /// <summary>The program.</summary>
    internal class Program
    {
        /// <summary>main.</summary>
        private static void Main()
        {
            Console.BufferWidth = 200;
            Console.BufferHeight = 2000;

            var serviceManager = GetServiceManager();

            // run the actual program
            try
            {
                PrintBanner(serviceManager);
                new Program().Main(serviceManager);
            }
            catch (ServiceException exception)
            {
                Console.WriteLine();
                using (new Pen(ConsoleColor.Red))
                {
                    Console.WriteLine(exception.Details.Text);
                }
            }
        }

        private static ServiceManager GetServiceManager()
        {
            // create a default Ninject kernel
            var kernel = new StandardKernel();

            // load all custom Ninject modules in the sample's assembly
            kernel.Load(Assembly.GetExecutingAssembly());

            // create a service manager whose dependencies were configured in the custom Ninject modules
            return kernel.Get<ServiceManager>();
        }

        private static void PrintBanner(ServiceManager serviceManager)
        {
            Console.WriteLine(@"+--------------------------------------------+");
            Console.WriteLine(@"| Welcome to the GW2.NET sample application! |");
            Console.WriteLine(@"+--------------------------------------------+");
            Console.WriteLine();
            Console.Write(@" Today is... ");
            Console.WriteLine(DateTime.Now.ToShortDateString());
            Console.WriteLine();
            Console.WriteLine(@"+--------------------------------------------+");
            Console.WriteLine();
            Console.Write(@" The current game build is... ");
            var build = serviceManager.GetBuild();
            using (new Pen(ConsoleColor.Cyan))
            {
                Console.WriteLine(build.BuildId);
            }
            Console.WriteLine();
            Console.WriteLine(@"+--------------------------------------------+");
        }

        private int? GetInt(string prompt = null)
        {
            string rawInput = default(string);
            int input;
            do
            {
                Console.Write(prompt);
                if (rawInput == string.Empty)
                {
                    return null;
                }
            }
            while (!int.TryParse(rawInput = Console.ReadLine(), out input));

            return input;
        }

        private void Main(ServiceManager serviceManager)
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine(@"[1] colors.json");
                Console.WriteLine(@"[2] files.json");
                Console.WriteLine(@"[3] world_names.json");
                Console.WriteLine(@"[4] map_names.json");
                Console.WriteLine(@"[5] event_names.json");
                Console.WriteLine(@"[6] events.json");
                Console.WriteLine();
                Console.WriteLine(@"[Q] exit");

                Console.Write(@"Choose an endpoint []: ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine();

                try
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:
                            this.PrintColors(serviceManager);
                            break;

                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            this.PrintFiles(serviceManager);
                            break;

                        case ConsoleKey.NumPad3:
                        case ConsoleKey.D3:
                            this.PrintWorldNames(serviceManager);
                            break;

                        case ConsoleKey.NumPad4:
                        case ConsoleKey.D4:
                            this.PrintMapNames(serviceManager);
                            break;

                        case ConsoleKey.NumPad5:
                        case ConsoleKey.D5:
                            this.PrintEventNames(serviceManager);
                            break;

                        case ConsoleKey.NumPad6:
                        case ConsoleKey.D6:
                            this.PrintEvents(serviceManager);
                            break;

                        case ConsoleKey.Q:
                            return;

                        default:
                            Console.WriteLine();
                            break;
                    }
                }
                catch (ServiceException exception)
                {
                    using (new Pen(ConsoleColor.DarkRed))
                    {
                        this.PrintError(exception.Details);
                    }
                }
            }
            while (true);
        }

        private void PrintColors(IColorService service)
        {
            var table = new ConsoleTable("ID", "Name", "Color");

            foreach (var color in service.GetColors().OrderByDescending(x => x))
            {
                table.AddRow(color.ColorId, color.Name, color.Cloth.Rgb);
            }

            table.Write();

            Console.WriteLine();
        }

        private void PrintError(ErrorResult errorResult)
        {
            var table = new ConsoleTable("Error", "Message");

            table.AddRow(errorResult.Error, errorResult.Text);

            table.Write();

            Console.WriteLine();
        }

        private void PrintEventNames(ServiceManager serviceManager)
        {
            var table = new ConsoleTable("ID", "Event ID", "Name");

            var collection = serviceManager.GetDynamicEventNames().ToList();

            for (int i = 0; i < collection.Count(); i++)
            {
                table.AddRow(i, collection[i].Id, collection[i].Name);
            }

            table.Write();

            Console.WriteLine();
        }

        private void PrintEvents(ServiceManager serviceManager)
        {
            var table = new ConsoleTable("Name", "ID", "State");

            this.PrintMapNames(serviceManager);

            int? mapId = this.GetInt("Pick a map ID []: ");

            this.PrintWorldNames(serviceManager);

            int? worldId = this.GetInt("Pick a world ID []: ");

            IEnumerable<DynamicEvent> collection;

            if (mapId.HasValue)
            {
                collection = worldId.HasValue
                                 ? serviceManager.GetDynamicEventsByMap(mapId.Value, worldId.Value)
                                 : serviceManager.GetDynamicEventsByMap(mapId.Value);
            }
            else
            {
                collection = worldId.HasValue ? serviceManager.GetDynamicEventsByWorld(worldId.Value) : serviceManager.GetDynamicEvents();
            }

            var dynamicEventNames = serviceManager.GetDynamicEventNames().ToList();

            foreach (var dynamicEvent in collection)
            {
                table.AddRow(dynamicEventNames.Single(x => x.Id == dynamicEvent.EventId).Name, dynamicEvent.EventId, dynamicEvent.State);
            }

            table.Write();

            Console.WriteLine();
        }

        private void PrintFiles(ServiceManager serviceManager)
        {
            var table = new ConsoleTable("Name", "ID", "Signature");

            foreach (var file in serviceManager.GetFiles())
            {
                table.AddRow(file.FileName, file.FileId, file.FileSignature);
            }

            table.Write();

            Console.WriteLine();
        }

        private void PrintMapNames(ServiceManager serviceManager)
        {
            var table = new ConsoleTable("ID", "Map");

            foreach (var map in serviceManager.GetMapNames())
            {
                table.AddRow(map.Id, map.Name);
            }

            table.Write();

            Console.WriteLine();
        }

        private void PrintWorldNames(ServiceManager serviceManager)
        {
            var table = new ConsoleTable("ID", "World");

            foreach (var world in serviceManager.GetWorldNames())
            {
                table.AddRow(world.Id, world.Name);
            }

            table.Write();

            Console.WriteLine();
        }
    }
}