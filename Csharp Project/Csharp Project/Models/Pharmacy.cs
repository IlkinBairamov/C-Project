using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Project
{
    partial class Pharmacy
    {
        public string Name { get; }
        public int Unical_id { get; }       

        private static int Count = 0;       

        private List<Drug> _drugs;

        public Pharmacy(string name)
        {
            Name = name;                     
            Count++;
            Unical_id = Count;
            _drugs = new List<Drug>();
        }

    }
}
