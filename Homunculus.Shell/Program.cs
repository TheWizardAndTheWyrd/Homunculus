﻿using System;
using System.Text;

namespace Homunculus.Shell
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppBanner.PrintBanner();

            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                AppPrompt.PrintPrompt();
            }
        }
    }

    public static class AppBanner
    {
        private static readonly string VersionNumber = "v0.0.1-alpha";
        private static readonly string CurrentYear = DateTime.Now.Year.ToString();

        public static void PrintBanner()
        {
            System.Console.WriteLine("                                              _                        _   ");
            System.Console.WriteLine("  /\\  /\\___  _ __ ___  _   _ _ __   ___ _   _| |_   _ ___   _ __   ___| |_ ");
            System.Console.WriteLine(" / /_/ / _ \\| '_ ` _ \\| | | | '_ \\ / __| | | | | | | / __| | '_ \\ / _ \\ __|");
            System.Console.WriteLine("/ __  / (_) | | | | | | |_| | | | | (__| |_| | | |_| \\__ \\_| | | |  __/ |_ ");
            System.Console.WriteLine("\\/ /_/ \\___/|_| |_| |_|\\__,_|_| |_|\\___|\\__,_|_|\\__,_|___(_)_| |_|\\___|\\__|");
            System.Console.WriteLine($"        (c) 2015 - {CurrentYear} The Wizard & The Wyrd, LLC - {VersionNumber}");
            System.Console.WriteLine();
        }
    }

    public static class AppPrompt
    {
        private static readonly string ShellPrompt = "\u03c8> ";

        public static void PrintPrompt()
        {
            System.Console.Write($"{ShellPrompt} ");
            System.Console.ReadLine();
        }
    }
}
