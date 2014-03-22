using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestSharp.GW2DotNET.Sample
{
    /// <summary>
    /// https://gist.github.com/StevenLiekens/6714739
    /// </summary>
    internal class Pen : IDisposable
    {
        private readonly ConsoleColor original = Console.ForegroundColor;

        public Pen(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void Dispose()
        {
            Console.ForegroundColor = this.original;
        }
    }
}
