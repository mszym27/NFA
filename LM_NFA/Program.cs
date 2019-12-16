using System;
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

            // niestety słowniki w ten sposób nie działają. Nie wspierają kilku takich samych kluczy, w tym wypadku zwracają po prostu ostatni
            // potrzebuję listy Stanów

            var tempDict = new Dictionary<char, string>() { ['0'] = "111" , ['0'] = "999" };

            var newStates = new List<string>();

            newStates
                    .AddRange(tempDict
                        .Where(q => q.Key == '0')
                        .Select(q => q.Value)
                    );

            var partDict = tempDict
                        .Where(q => q.Key == '0');

            //pauzuje program
            Console.ReadLine();
        }
    }
}