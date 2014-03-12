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
    using System.Linq;

    using global::GW2DotNET.V1;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.DynamicEventsInformation.Status;

    using global::GW2DotNET.V1.Core.ErrorInformation;

    /// <summary>The program.</summary>
    internal class Program
    {
        /// <summary>main.</summary>
        private static void Main()
        {
            Console.BufferWidth = Console.BufferHeight = short.MaxValue - 1;

            var serviceManager = new ServiceManager();
            var serviceProvider = new ServiceProvider(serviceManager);

            PrintBanner(serviceProvider);

            new Program().Main(serviceProvider);
        }

        /// <summary>TODO The print banner.</summary>
        /// <param name="serviceProvider">TODO The service provider.</param>
        private static void PrintBanner(ServiceProvider serviceProvider)
        {
            Console.WriteLine(@"+--------------------------------------------+");
            Console.WriteLine(@"| Welcome to the GW2.NET sample application! |");
            Console.WriteLine(@"+--------------------------------------------+");
            Console.WriteLine();
            Console.Write(@" Today is...");
            Console.WriteLine(DateTime.Now.ToShortDateString());
            Console.WriteLine();
            Console.WriteLine(@"+--------------------------------------------+");
            Console.WriteLine();
            Console.Write(@" The current game build is... ");
            var build = serviceProvider.GetBuild();
            Console.WriteLine(build.BuildId);
            Console.WriteLine();
            Console.WriteLine(@"+--------------------------------------------+");
        }

        /// <summary>TODO The get int.</summary>
        /// <param name="prompt">TODO The prompt.</param>
        /// <returns>The <see cref="int"/>.</returns>
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

        /// <summary>TODO The main.</summary>
        /// <param name="serviceProvider">TODO The service provider.</param>
        private void Main(ServiceProvider serviceProvider)
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine(@"[1] colors.json");
                Console.WriteLine(@"[2]. files.json");
                Console.WriteLine(@"[3]. world_names.json");
                Console.WriteLine(@"[4]. map_names.json");
                Console.WriteLine(@"[5]. event_names.json");
                Console.WriteLine(@"[6]. events.json");
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
                            this.PrintColors(serviceProvider);
                            break;
                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            this.PrintFiles(serviceProvider);
                            break;
                        case ConsoleKey.NumPad3:
                        case ConsoleKey.D3:
                            this.PrintWorldNames(serviceProvider);
                            break;
                        case ConsoleKey.NumPad4:
                        case ConsoleKey.D4:
                            this.PrintMapNames(serviceProvider);
                            break;
                        case ConsoleKey.NumPad5:
                        case ConsoleKey.D5:
                            this.PrintEventNames(serviceProvider);
                            break;
                        case ConsoleKey.NumPad6:
                        case ConsoleKey.D6:
                            this.PrintEvents(serviceProvider);
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
                    this.PrintError(exception.Details);
                }
            }
            while (true);
        }

        /// <summary>TODO The print colors.</summary>
        /// <param name="serviceProvider">TODO The service provider.</param>
        private void PrintColors(ServiceProvider serviceProvider)
        {
            var table = new ConsoleTable("ID", "Name", "Color");

            foreach (var color in serviceProvider.GetColors().Values.OrderByDescending(x => x))
            {
                table.AddRow(color.ColorId, color.Name, color.Cloth.Rgb);
            }

            table.Write();

            Console.WriteLine();
        }

        /// <summary>TODO The print error.</summary>
        /// <param name="errorResult">TODO The error result.</param>
        private void PrintError(ErrorResult errorResult)
        {
            var table = new ConsoleTable("Error", "Message");

            table.AddRow(errorResult.Error, errorResult.Text);

            table.Write();

            Console.WriteLine();
        }

        /// <summary>TODO The print event names.</summary>
        /// <param name="serviceProvider">TODO The service provider.</param>
        private void PrintEventNames(ServiceProvider serviceProvider)
        {
            var table = new ConsoleTable("ID", "Event ID", "Name");

            var collection = serviceProvider.GetDynamicEventNames();

            for (int i = 0; i < collection.Count; i++)
            {
                table.AddRow(i, collection[i].Id, collection[i].Name);
            }

            table.Write();

            Console.WriteLine();
        }

        /// <summary>TODO The print events.</summary>
        /// <param name="serviceProvider">TODO The service provider.</param>
        private void PrintEvents(ServiceProvider serviceProvider)
        {
            var table = new ConsoleTable("Name", "ID", "State");

            this.PrintMapNames(serviceProvider);

            int? mapId = this.GetInt("Pick a map ID []: ");

            this.PrintWorldNames(serviceProvider);

            int? worldId = this.GetInt("Pick a world ID []: ");

            DynamicEventCollection collection;

            if (mapId.HasValue)
            {
                collection = worldId.HasValue
                                 ? serviceProvider.GetDynamicEventsByMap(mapId.Value, worldId.Value)
                                 : serviceProvider.GetDynamicEventsByMap(mapId.Value);
            }
            else
            {
                collection = worldId.HasValue ? serviceProvider.GetDynamicEventsByWorld(worldId.Value) : serviceProvider.GetDynamicEvents();
            }

            var dynamicEventNames = serviceProvider.GetDynamicEventNames();

            foreach (var dynamicEvent in collection)
            {
                table.AddRow(dynamicEventNames.Single(x => x.Id == dynamicEvent.EventId).Name, dynamicEvent.EventId, dynamicEvent.State);
            }

            table.Write();

            Console.WriteLine();
        }

        /// <summary>TODO The print files.</summary>
        /// <param name="serviceProvider">TODO The service provider.</param>
        private void PrintFiles(ServiceProvider serviceProvider)
        {
            var table = new ConsoleTable("Name", "ID", "Signature");

            foreach (var file in serviceProvider.GetFiles().Values)
            {
                table.AddRow(file.FileName, file.FileId, file.Signature);
            }

            table.Write();

            Console.WriteLine();
        }

        /// <summary>TODO The print map names.</summary>
        /// <param name="serviceProvider">TODO The service provider.</param>
        private void PrintMapNames(ServiceProvider serviceProvider)
        {
            var table = new ConsoleTable("ID", "Map");

            foreach (var map in serviceProvider.GetMapNames())
            {
                table.AddRow(map.Id, map.Name);
            }

            table.Write();

            Console.WriteLine();
        }

        /// <summary>TODO The print world names.</summary>
        /// <param name="serviceProvider">TODO The service provider.</param>
        private void PrintWorldNames(ServiceProvider serviceProvider)
        {
            var table = new ConsoleTable("ID", "World");

            foreach (var world in serviceProvider.GetWorldNames())
            {
                table.AddRow(world.Id, world.Name);
            }

            table.Write();

            Console.WriteLine();
        }
    }
}