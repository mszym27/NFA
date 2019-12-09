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

        // co zostanie wypisane po dojsciu do danego stanu
        public string output;

        // przejscia - mapuje alfabet na zbior stanow
        public Dictionary<string, string> transitions;

        // identyfikuje stany akceptujace
        public bool isAccept;
    }
}
