using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Homunculus.Core.Extensions;

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

                Debug.WriteLine($"[{DateTime.Now}] Last Command: {AppPrompt.CommandHistory[AppPrompt.CommandHistoryIndex - 1]}");

                CommandInterpreter.ProcessCommand(AppPrompt.CommandHistoryIndex, AppPrompt.CommandHistory);
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
        private static readonly string ShellPrompt = $"\u03c8> ";
        public static Dictionary<int, string> CommandHistory = new Dictionary<int, string>();
        public static int CommandHistoryIndex = 0;

        public static void PrintPrompt()
        {
            Console.Write($"{ShellPrompt} ");
            string s = Console.ReadLine();
            CommandHistory[CommandHistoryIndex] = s;
            CommandHistoryIndex++;
        }
    }

    public static class CommandInterpreter
    {
        public static void ProcessCommand(int commandHistoryIndex, Dictionary<int, string> commandHistory)
        {
            int lastCommandIndex = commandHistoryIndex - 1;
            var lastCommandString = commandHistory[commandHistoryIndex - 1];

            Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] {lastCommandIndex}> {lastCommandString}");

            var tokens = TokenizeCommandString(lastCommandString);
        }

        /// <summary>
        /// Returns a jagged array of strings representing command tokens.
        /// Words in a sentence are separated by spaces.  
        /// New lines are separated by semicolons; i.e., "hello world;false"
        /// would be tokenized as:
        /// result[0][0] = "hello";
        /// result[0][1] = "world";
        /// result[1][0] = "false";
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns></returns>
        public static string[][] TokenizeCommandString(string commandString)
        {
            Debug.WriteLine($"[{DateTime.Now}] Tokenizing: {commandString}");

            // Step 0: Declare our result data structure:
            //var result = new string[,] { {}, {} };
            //var tempResult = new string[,] { {}, {} };
            var tempResult = new string[100, 100];

            // Step 1: Split on semicolons:
            string[] sentences = commandString.Split(';');

            // Step 2: Split on spaces:
            for (int x = 0; x < sentences.Count(); x++)
            {
                string[] words = sentences[x].Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);

                // Step 3: Assemble the temp 2d string array:
                for (int y = 0; y < words.Count(); y++)
                {
                    tempResult[x,y] = words[y];
                }
            }

            Debug.WriteLine($"[{DateTime.Now}] Resulting tokens: {JsonConvert.SerializeObject(tempResult)}");


            // Step 4: Clean up array:
            // TODO: create new string[][] without the null values in tempResult[,]

            var result = tempResult.ToJaggedArray();

            Debug.WriteLine($"[{DateTime.Now}] Resulting jagged array: {JsonConvert.SerializeObject(result)}");

            return result;
            //return new string[][] {};
        }
    }
}
