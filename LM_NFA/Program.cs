using System;
using System.IO;
using System.Collections.Generic;

namespace LM_NFA
{
    class Program
    {
        private const char SEPARATOR_CHAR = '#';

        static void Main(string[] args)
        {
            //    Console.WriteLine("Proszę rozpocząć wprowadzanie monet");

            //    while(NFA.currentState.isAccept == false)
            //    {
            //        pastStateNames.Add(NFA.currentState.stateName);

            //        var input = Console.ReadLine();

            //        NFA.Transition(input);

            //        Console.WriteLine(NFA.currentState.stateName + ":");

            //        Console.WriteLine(NFA.currentState.output);
            //    }

            var inputFile = new StreamReader("input.csv");

            var input = inputFile.ReadLine().Split(SEPARATOR_CHAR);

            var NFA = new Automata();

            Console.WriteLine("Lingwistyka matematyczna - laboratoria drugie, NFA");

            foreach (var inputString in input)
            {
                Console.WriteLine("--------------------------------------------------");

                Console.WriteLine("Przetwarzany jest wyraz: " + inputString);

                var pastStateNames = new List<String>();

                foreach (var symbol in inputString)
                {
                    NFA.Transition(symbol);

                    pastStateNames.Add(NFA.GetCurrentStateNamesConcatenated());
                }

                Console.WriteLine("Koniec w stanie\\ach: " + NFA.GetCurrentStateNamesConcatenated());

                Console.WriteLine("Po drodze przebyto");

                foreach (var name in pastStateNames)
                {
                    Console.Write("-> " + name);
                }

                Console.WriteLine("");

                if (NFA.IsCurrentStateAccept())
                    Console.WriteLine(NFA.GetAcceptStateOutput());
                else
                    Console.WriteLine("Wyraz nie został zaakceptowany");
            }

            // dla uproszczenia programu
            // oraz by zredukowac czas dzialania
            // petla jest przerywana natychmiast gdy zostanie napotkany stan akceptujacy
            // sam automat kontynuowalby wtedy prace

            // powinno byc inaczej - petla konczy sie 
            // w momencie wczytania separatora - kiedy dojdziemy
            // do konca danego stringa
            // wtedy badany jest stan automatu
            // jesli lista aktualnych stanow zawiera stan akceptujacy
            // wtedy wczytane slowo jest poprawne

            //pauzuje program
            Console.ReadLine();
        }
    }
}