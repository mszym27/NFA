using System;
using System.IO;
using System.Collections.Generic;

namespace LM_NFA
{
    class Program
    {
        private const char SEPARATOR_CHAR = ',';

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

            var input = inputFile.ReadLine().Split(SEPARATOR_CHAR);
            
            foreach (var inputString in input)
                Console.WriteLine(inputString);

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
