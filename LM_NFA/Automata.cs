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

        public State currentState;

        public Automata ()
        {
            states = new List<State>();

            // inicjalizacja automatu - tablica przejść

            states.Add(
                new State()
                {
                    stateName = "q0",
                    transitions = new Dictionary<string, string>() { ["1"] = "q1", ["2"] = "q2", ["5"] = "q5", ["TAK"] = "q0" },
                    output = "Stan wejściowy"
                }
            );

            states.Add(
                new State()
                {
                    stateName = "q1",
                    transitions = new Dictionary<string, string> { ["1"] = "q2", ["2"] = "q3", ["5"] = "q6", ["TAK"] = "q1" },
                    output = "Suma monet: 1"
                }
            );

            states.Add(
                new State()
                {
                    stateName = "q2",
                    transitions = new Dictionary<string, string> { ["1"] = "q3", ["2"] = "q4", ["5"] = "q7", ["TAK"] = "q2" },
                    output = "Suma monet: 2"
                }
            );

            states.Add(
                new State()
                {
                    stateName = "q3",
                    transitions = new Dictionary<string, string> { ["1"] = "q4", ["2"] = "q5", ["5"] = "q8", ["TAK"] = "q3" },
                    output = "Suma monet: 3"
                }
            );

            states.Add(
                new State()
                {
                    stateName = "q4",
                    transitions = new Dictionary<string, string> { ["1"] = "q5", ["2"] = "q6", ["5"] = "q9", ["TAK"] = "q4" },
                    output = "Suma monet: 4"
                }
            );

            states.Add(
                new State()
                {
                    stateName = "q5",
                    transitions = new Dictionary<string, string> { ["1"] = "q6", ["2"] = "q7", ["5"] = "q10", ["TAK"] = "q5" },
                    output = "Suma monet: 5"
                }
            );

            states.Add(
                new State()
                {
                    stateName = "q6",
                    transitions = new Dictionary<string, string> { ["1"] = "q7", ["2"] = "q8", ["5"] = "q11", ["TAK"] = "q6" },
                    output = "Suma monet: 6"
                }
            );

            states.Add(
                new State()
                {
                    stateName = "q7",
                    transitions = new Dictionary<string, string> { ["1"] = "q8", ["2"] = "q9", ["5"] = "q12", ["TAK"] = "q7" },
                    output = "Suma monet: 7"
                }
            );

            states.Add(
                new State()
                {
                    stateName = "q8",
                    transitions = new Dictionary<string, string> { ["1"] = "q9", ["2"] = "q10", ["5"] = "qRET", ["TAK"] = "q8" },
                    output = "Suma monet: 8"
                }
            );

            states.Add(
                new State()
                {
                    stateName = "q9",
                    transitions = new Dictionary<string, string> { ["1"] = "q9", ["2"] = "q9", ["5"] = "q9", ["TAK"] = "q0" },
                    output = "Suma monet: 9, wydano bilet (basen)",
                    isAccept = true
                }
            );

            states.Add(
                new State()
                {
                    stateName = "q10",
                    transitions = new Dictionary<string, string> { ["1"] = "q11", ["2"] = "q12", ["5"] = "qRET", ["TAK"] = "q0" },
                    output = "Suma monet: 10"
                }
            );

            states.Add(
                new State()
                {
                    stateName = "q11",
                    transitions = new Dictionary<string, string> { ["1"] = "q12", ["2"] = "qRET", ["5"] = "qRET", ["TAK"] = "q11" },
                    output = "Suma monet: 11"
                }
            );

            states.Add(
                new State()
                {
                    stateName = "q12",
                    transitions = new Dictionary<string, string> { ["1"] = "q12", ["2"] = "q12", ["5"] = "q12", ["TAK"] = "q0" },
                    output = "Suma monet: 12, wydano bilet (basen i sauna)",
                    isAccept = true
                }
            );

            states.Add(
                new State()
                {
                    stateName = "qRET",
                    transitions = new Dictionary<string, string> { ["1"] = "qRET", ["2"] = "qRET", ["5"] = "qRET", ["TAK"] = "q0" },
                    output = "Przekroczono 12, odbierz monety",
                    isAccept = true
                }
            );

            // ustawienie automatu na stan poczatkowy

            currentState = states
                .Where(q => q.stateName == "q0")
                .First();
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
