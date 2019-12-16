using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_NFA
{
    class Automata
    {
        private List<State> states;

        private List<State> currentStates;

        public Automata()
        {
            states = new List<State>();
            currentStates = new List<State>();

            // inicjalizacja automatu - tablica przejść

            // q beginning
            states.Add(
                new State()
                {
                    stateName = "qbeg"
                }
            );


            // q accept numbers
            states.Add(
                new State()
                {
                    stateName = "qan",
                    isAccept = true,
                    output = "Wykryto powtorzenie w wartosciach numerycznych"
                }
            );

            // q accept characters
            states.Add(
                new State()
                {
                    stateName = "qac",
                    isAccept = true,
                    output = "Wykryto powtorzenie w literach"
                }
            );

            states.Add(new State() { stateName = "q0", transitions = new Dictionary<char, List<State>>() { ['0'] = GetStateByNameAsList("qan") } });
            states.Add(new State() { stateName = "q1", transitions = new Dictionary<char, List<State>>() { ['1'] = GetStateByNameAsList("qan") } });
            states.Add(new State() { stateName = "q2", transitions = new Dictionary<char, List<State>>() { ['2'] = GetStateByNameAsList("qan") } });
            states.Add(new State() { stateName = "q3", transitions = new Dictionary<char, List<State>>() { ['3'] = GetStateByNameAsList("qan") } });
            states.Add(new State() { stateName = "q4", transitions = new Dictionary<char, List<State>>() { ['4'] = GetStateByNameAsList("qan") } });
            states.Add(new State() { stateName = "qa", transitions = new Dictionary<char, List<State>>() { ['a'] = GetStateByNameAsList("qac") } });
            states.Add(new State() { stateName = "qb", transitions = new Dictionary<char, List<State>>() { ['b'] = GetStateByNameAsList("qac") } });
            states.Add(new State() { stateName = "qc", transitions = new Dictionary<char, List<State>>() { ['c'] = GetStateByNameAsList("qac") } });
            states.Add(new State() { stateName = "qd", transitions = new Dictionary<char, List<State>>() { ['d'] = GetStateByNameAsList("qac") } });
            states.Add(new State() { stateName = "qe", transitions = new Dictionary<char, List<State>>() { ['e'] = GetStateByNameAsList("qac") } });

            states
                .Where(q => q.stateName == "qan")
                .First().transitions = new Dictionary<char, List<State>>
                {
                    ['0'] = GetStateByNameAsList("qan"),
                    ['1'] = GetStateByNameAsList("qan"),
                    ['2'] = GetStateByNameAsList("qan"),
                    ['3'] = GetStateByNameAsList("qan"),
                    ['4'] = GetStateByNameAsList("qan"),
                };

            states
                .Where(q => q.stateName == "qac")
                .First().transitions = new Dictionary<char, List<State>>
                {
                    ['a'] = GetStateByNameAsList("qac"),
                    ['b'] = GetStateByNameAsList("qac"),
                    ['c'] = GetStateByNameAsList("qac"),
                    ['d'] = GetStateByNameAsList("qac"),
                    ['e'] = GetStateByNameAsList("qac"),
                };

            states
                .Where(q => q.stateName == "qbeg")
                .First().transitions = new Dictionary<char, List<State>>
                {
                    ['0'] = new List<State>() { GetStateByName("qbeg"), GetStateByName("q0") },
                    ['1'] = new List<State>() { GetStateByName("qbeg"), GetStateByName("q1") },
                    ['2'] = new List<State>() { GetStateByName("qbeg"), GetStateByName("q2") },
                    ['3'] = new List<State>() { GetStateByName("qbeg"), GetStateByName("q3") },
                    ['4'] = new List<State>() { GetStateByName("qbeg"), GetStateByName("q4") },
                    ['a'] = new List<State>() { GetStateByName("qbeg"), GetStateByName("qa") },
                    ['b'] = new List<State>() { GetStateByName("qbeg"), GetStateByName("qb") },
                    ['c'] = new List<State>() { GetStateByName("qbeg"), GetStateByName("qc") },
                    ['d'] = new List<State>() { GetStateByName("qbeg"), GetStateByName("qd") },
                    ['e'] = new List<State>() { GetStateByName("qbeg"), GetStateByName("qe") },
                };

            // ustawienie automatu na stan poczatkowy

            currentStates.Add(
                states
                .Where(q => q.stateName == "qbeg")
                .First()
            );
        }

        // jesli zostal wprowadzony symbol spoza alfabetu
        // to maszyna pozostaje w tym samym stanie
        // jest to widoczne w historii przejsc
        public void Transition(char symbol)
        {
            var newStates = new List<State>();

            foreach (var state in currentStates)
            {
                //var transitionStates = state.transitions[symbol]; // nie dziala dla symboli spoza slownika
                //// czyli sie nie sprawdza dla NFA

                var transitionStates = state
                    .transitions
                    .Where(q => q.Key == symbol)
                    .FirstOrDefault()
                    .Value;

                //(List<State>) state
                //    .transitions
                //    .Where(q => q.Key == symbol)
                //    .Select(q => q.Value);

                if(transitionStates != null)
                    newStates.AddRange(transitionStates);
            }

            currentStates = newStates;

            return;
        }

        public string GetCurrentStateNamesConcatenated()
        {
            return " (" + String.Join(",", currentStates) + ") ";
        }

        public bool IsCurrentStateAccept()
        {
            return currentStates.
                Where(q => q.isAccept).
                Any();
        }

        public string GetAcceptStateOutput()
        {
            var acceptState = currentStates.
                Where(q => q.isAccept).
                FirstOrDefault();

            if (acceptState != null)
            {
                return acceptState.output;
            }

            return "";
        }

        // metoda asystuje przy wyborze stanu
        private State GetStateByName(string name)
        {
            return states
                .Where(q => q.stateName == name)
                .First();
        }

        // wrapper konwertujący dany stan na jednoelementową listę
        private List<State> GetStateByNameAsList(string name)
        {
            var singleStateList = new List<State>();

            singleStateList.Add(GetStateByName(name));

            return singleStateList;
        }
    }
}
