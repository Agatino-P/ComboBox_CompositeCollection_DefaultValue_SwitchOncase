using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositeCollectionApp
{
    public class ClassCognome
    {
        public string Cognome { get; set; }
        public string DisplayName => Cognome;
        public ClassCognome(string cognome)
        {
            Cognome = cognome;
        }
    }
}
