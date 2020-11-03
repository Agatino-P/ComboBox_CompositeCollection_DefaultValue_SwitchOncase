using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositeCollectionApp
{
    public class ClassNome
    {
        public string Nome { get; set; }
        public string DisplayName => Nome;
        public ClassNome(string nome)
        {
            Nome = nome;
        }
    }
}
