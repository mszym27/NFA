using System;
using System.IO;
using System.Collections.Generic;

namespace LM_NFA
{
    class Program
    {
        private const char SPLIT_CHAR = ',';

        static void Main(string[] args)
        {
            //    var pastStateNames = new List<String>();

            //    var NFA = new Automata();

            //    Console.WriteLine("Lingwistyka matematyczna - laboratoria pierwsze, NFA");

            //    Console.WriteLine("Proszę rozpocząć wprowadzanie monet");

            //    while(NFA.currentState.isAccept == false)
            //    {
            //        pastStateNames.Add(NFA.currentState.stateName);

            //        var input = Console.ReadLine();

            //        NFA.Transition(input);

            //        Console.WriteLine(NFA.currentState.stateName + ":");

            //        Console.WriteLine(NFA.currentState.output);
            //    }

            //    Console.WriteLine("KONIEC");

            //    Console.WriteLine("Koniec w stanie: " + NFA.currentState.stateName);

            //    Console.WriteLine("Po drodze do niego przebyto");

            //    foreach (var name in pastStateNames) {
            //        Console.Write("->" + name);
            //    }

            var inputFile = new StreamReader("input.csv");

            var input = inputFile.ReadLine().Split(SPLIT_CHAR);
            
            foreach (var inputString in input)
                Console.WriteLine(inputString);

            //pauzuje program
            Console.ReadLine();
        }
    }
}
