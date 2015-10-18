using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homunculus.Core.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AppBanner.PrintBanner();
            System.Console.ReadLine();
        }
    }

    public static class AppBanner
    {
        public static void PrintBanner()
        {
            System.Console.WriteLine("                                              _                        _   ");
            System.Console.WriteLine("  /\\  /\\___  _ __ ___  _   _ _ __   ___ _   _| |_   _ ___   _ __   ___| |_ ");
            System.Console.WriteLine(" / /_/ / _ \\| '_ ` _ \\| | | | '_ \\ / __| | | | | | | / __| | '_ \\ / _ \\ __|");
            System.Console.WriteLine("/ __  / (_) | | | | | | |_| | | | | (__| |_| | | |_| \\__ \\_| | | |  __/ |_ ");
            System.Console.WriteLine("\\/ /_/ \\___/|_| |_| |_|\\__,_|_| |_|\\___|\\__,_|_|\\__,_|___(_)_| |_|\\___|\\__|");
            System.Console.WriteLine("        (c) 2015 The Wizard & The Wyrd, LLC - v0.0.1-alpha");
            System.Console.WriteLine();
        }
    }
}
