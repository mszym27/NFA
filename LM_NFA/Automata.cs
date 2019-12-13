using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_NFA
{
    class Automata
    {
        public List<State> states;

        public List<State> currentStates;

        public Automata ()
        {
            states = new List<State>();

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
                    stateName = "qaccn",
                    isAccept = true,
                    output = "Wykryto powtorzenie w wartosciach numerycznych"
                }
            );

            // q accept characters
            states.Add(
                new State()
                {
                    stateName = "qaccc",
                    isAccept = true,
                    output = "Wykryto powtorzenie w literach"
                }
            );

            states.Add(new State() { stateName = "q0", transitions = new Dictionary<char, State>() { ['0'] = "qaccn" } });
            states.Add(new State() { stateName = "q1", transitions = new Dictionary<char, State>() { ['1'] = "qaccn" } });
            states.Add(new State() { stateName = "q2", transitions = new Dictionary<char, State>() { ['2'] = "qaccn" } });
            states.Add(new State() { stateName = "q3", transitions = new Dictionary<char, State>() { ['3'] = "qaccn" } });
            states.Add(new State() { stateName = "q4", transitions = new Dictionary<char, State>() { ['4'] = "qaccn" } });
            states.Add(new State() { stateName = "qa", transitions = new Dictionary<char, State>() { ['a'] = "qaccc" } });
            states.Add(new State() { stateName = "qb", transitions = new Dictionary<char, State>() { ['b'] = "qaccc" } });
            states.Add(new State() { stateName = "qc", transitions = new Dictionary<char, State>() { ['c'] = "qaccc" } });
            states.Add(new State() { stateName = "qd", transitions = new Dictionary<char, State>() { ['d'] = "qaccc" } });
            states.Add(new State() { stateName = "qe", transitions = new Dictionary<char, State>() { ['e'] = "qaccc" } });

            states
                .Where(q => q.stateName == "qaccn")
                .First().transitions = new Dictionary<char, State>
                {
                    ['0'] = "qaccn",
                    ['1'] = "qaccn",
                    ['2'] = "qaccn",
                    ['3'] = "qaccn",
                    ['4'] = "qaccn",
                };

            states
                .Where(q => q.stateName == "qaccc")
                .First().transitions = new Dictionary<char, State>
                {
                    ['a'] = "qaccc",
                    ['b'] = "qaccc",
                    ['c'] = "qaccc",
                    ['d'] = "qaccc",
                    ['e'] = "qaccc",
                };

            states
                .Where(q => q.stateName == "qbeg")
                .First().transitions = new Dictionary<char, State>
                {
                    ['0'] = "qbeg", ['0'] = "q0",
                    ['1'] = "qbeg", ['1'] = "q1",
                    ['2'] = "qbeg", ['2'] = "q2",
                    ['3'] = "qbeg", ['3'] = "q3",
                    ['4'] = "qbeg", ['4'] = "q4",
                    ['a'] = "qbeg", ['a'] = "qa",
                    ['b'] = "qbeg", ['b'] = "qb",
                    ['c'] = "qbeg", ['c'] = "qc",
                    ['d'] = "qbeg", ['d'] = "qd",
                    ['e'] = "qbeg", ['e'] = "qe",
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
        public void Transition(string simbol)
        {
            //var newStateName = currentState
            //    .transitions
            //    .Where(q => q.Key == simbol)
            //    .FirstOrDefault()
            //    .Value;

            //foreach (var state in states)
            //{
            //    if(state.stateName == newStateName)
            //    {
            //        currentState = state;

            //        break;
            //    }
            //}

            //currentStates = currentStates.Select(q => q.transitions);

            return;
        }
    }
}
