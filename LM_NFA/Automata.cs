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

            states.Add(new State() { stateName = "q0", transitions = new Dictionary<char, State>() { ['0'] = GetStateByName("qan") } });
            states.Add(new State() { stateName = "q1", transitions = new Dictionary<char, State>() { ['1'] = GetStateByName("qan") } });
            states.Add(new State() { stateName = "q2", transitions = new Dictionary<char, State>() { ['2'] = GetStateByName("qan") } });
            states.Add(new State() { stateName = "q3", transitions = new Dictionary<char, State>() { ['3'] = GetStateByName("qan") } });
            states.Add(new State() { stateName = "q4", transitions = new Dictionary<char, State>() { ['4'] = GetStateByName("qan") } });
            states.Add(new State() { stateName = "qa", transitions = new Dictionary<char, State>() { ['a'] = GetStateByName("qac") } });
            states.Add(new State() { stateName = "qb", transitions = new Dictionary<char, State>() { ['b'] = GetStateByName("qac") } });
            states.Add(new State() { stateName = "qc", transitions = new Dictionary<char, State>() { ['c'] = GetStateByName("qac") } });
            states.Add(new State() { stateName = "qd", transitions = new Dictionary<char, State>() { ['d'] = GetStateByName("qac") } });
            states.Add(new State() { stateName = "qe", transitions = new Dictionary<char, State>() { ['e'] = GetStateByName("qac") } });

            states
                .Where(q => q.stateName == "qan")
                .First().transitions = new Dictionary<char, State>
                {
                    ['0'] = GetStateByName("qan"),
                    ['1'] = GetStateByName("qan"),
                    ['2'] = GetStateByName("qan"),
                    ['3'] = GetStateByName("qan"),
                    ['4'] = GetStateByName("qan"),
                };

            states
                .Where(q => q.stateName == "qac")
                .First().transitions = new Dictionary<char, State>
                {
                    ['a'] = GetStateByName("qac"),
                    ['b'] = GetStateByName("qac"),
                    ['c'] = GetStateByName("qac"),
                    ['d'] = GetStateByName("qac"),
                    ['e'] = GetStateByName("qac"),
                };

            states
                .Where(q => q.stateName == "qbeg")
                .First().transitions = new Dictionary<char, State>
                {
                    ['0'] = GetStateByName("qbeg"), ['0'] = GetStateByName("q0"),
                    ['1'] = GetStateByName("qbeg"), ['1'] = GetStateByName("q1"),
                    ['2'] = GetStateByName("qbeg"), ['2'] = GetStateByName("q2"),
                    ['3'] = GetStateByName("qbeg"), ['3'] = GetStateByName("q3"),
                    ['4'] = GetStateByName("qbeg"), ['4'] = GetStateByName("q4"),
                    ['a'] = GetStateByName("qbeg"), ['a'] = GetStateByName("qa"),
                    ['b'] = GetStateByName("qbeg"), ['b'] = GetStateByName("qb"),
                    ['c'] = GetStateByName("qbeg"), ['c'] = GetStateByName("qc"),
                    ['d'] = GetStateByName("qbeg"), ['d'] = GetStateByName("qd"),
                    ['e'] = GetStateByName("qbeg"), ['e'] = GetStateByName("qe"),
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
                newStates
                    .AddRange(state
                        .transitions
                        .Where(q => q.Key == symbol)
                        .Select(q => q.Value)
                    );
            }

            currentStates = newStates;

            return;
        }

        public string GetCurrentStateNamesConcatenated()
        {
            return String.Join(",", currentStates);
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
    }
}
