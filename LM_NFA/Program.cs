﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LM_NFA
{
    class Program
    {
        private const char SEPARATOR_CHAR = '#';

        static void Main(string[] args)
        {
            var inputFile = new StreamReader("input.csv");

            var input = inputFile.ReadLine().Split(SEPARATOR_CHAR);

            Console.WriteLine("Lingwistyka matematyczna - laboratoria drugie, NFA");

            foreach (var inputString in input)
            {
                var NFA = new Automata();

                Console.WriteLine("--------------------------------------------------");

                Console.WriteLine("Przetwarzany jest wyraz: " + inputString);

                var pastStateNames = new List<String>();

                foreach (var symbol in inputString)
                {
                    pastStateNames.Add(NFA.GetCurrentStateNamesConcatenated());

                    NFA.Transition(symbol);
                }

                Console.WriteLine("Koniec w stanie\\ach: " + NFA.GetCurrentStateNamesConcatenated());

                Console.WriteLine("Po drodze przebyto");

                foreach (var name in pastStateNames)
                {
                    Console.Write("->" + name);
                }

                Console.WriteLine("");

                if (NFA.IsCurrentStateAccept())
                    Console.WriteLine(NFA.GetAcceptStateOutput());
                else
                    Console.WriteLine("Wyraz nie został zaakceptowany");
            }

            //pauzuje program
            Console.ReadLine();
        }
    }
}