using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_NFA
{
    class State
    {
        // identyfikuje dany stan
        public string stateName;

        // przejscia - mapuje alfabet na zbior stanow
        public Dictionary<char, List<State>> transitions; // Dictionary<char, State> transitions;

        // identyfikuje stany akceptujace
        public bool isAccept;

        // przechowuje wartosc wyswietlana uzytkownikowi
        public string output;
        
        public override string ToString() { return stateName; }
    }
}
