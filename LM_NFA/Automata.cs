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

            states.Add(
                new State()
                {
                    stateName = "qbeg",
                    transitions = new Dictionary<string, string>
                    {
                        ["0"] = "qbeg", ["0"] = "q0",
                        ["1"] = "qbeg", ["1"] = "q1",
                        ["2"] = "qbeg", ["2"] = "q2",
                        ["3"] = "qbeg", ["3"] = "q3",
                        ["4"] = "qbeg", ["4"] = "q4",
                        ["a"] = "qbeg", ["a"] = "qa",
                        ["b"] = "qbeg", ["b"] = "qb",
                        ["c"] = "qbeg", ["c"] = "qc",
                        ["e"] = "qbeg", ["e"] = "qe",
                        ["f"] = "qbeg", ["f"] = "qf"
                    },
                }
            );

            states.Add(new State() { stateName = "q0", transitions = new Dictionary<string, string>() { ["0"] = "qacc" } });
            states.Add(new State() { stateName = "q1", transitions = new Dictionary<string, string>() { ["1"] = "qacc" } });
            states.Add(new State() { stateName = "q2", transitions = new Dictionary<string, string>() { ["2"] = "qacc" } });
            states.Add(new State() { stateName = "q3", transitions = new Dictionary<string, string>() { ["3"] = "qacc" } });
            states.Add(new State() { stateName = "q4", transitions = new Dictionary<string, string>() { ["4"] = "qacc" } });
            states.Add(new State() { stateName = "qa", transitions = new Dictionary<string, string>() { ["a"] = "qacc" } });
            states.Add(new State() { stateName = "qb", transitions = new Dictionary<string, string>() { ["b"] = "qacc" } });
            states.Add(new State() { stateName = "qc", transitions = new Dictionary<string, string>() { ["c"] = "qacc" } });
            states.Add(new State() { stateName = "qe", transitions = new Dictionary<string, string>() { ["e"] = "qacc" } });
            states.Add(new State() { stateName = "qf", transitions = new Dictionary<string, string>() { ["f"] = "qacc" } });

            states.Add(
                new State()
                {
                    stateName = "qACC",
                    transitions = new Dictionary<string, string> {
                        ["0"] = "qacc",
                        ["1"] = "qacc",
                        ["2"] = "qacc",
                        ["3"] = "qacc",
                        ["4"] = "qacc",
                        ["a"] = "qacc",
                        ["b"] = "qacc",
                        ["c"] = "qacc",
                        ["e"] = "qacc",
                        ["f"] = "qacc",
                    },
                    isAccept = true
                }
            );

            // ustawienie automatu na stan poczatkowy

            currentStates.Add(
                states
                .Where(q => q.stateName == "q0")
                .First()
            );
        }

        // jesli zostal wprowadzony symbol spoza alfabetu
        // to maszyna pozostaje w tym samym stanie
        // jest to widoczne w historii przejsc
        public void Transition(string simbol)
        {
            var newStateName = currentState
                .transitions
                .Where(q => q.Key == simbol)
                .FirstOrDefault()
                .Value;

            foreach (var state in states)
            {
                if(state.stateName == newStateName)
                {
                    currentState = state;

                    break;
                }
            }

            return;
        }
    }
}
