using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Project
{
    class DrugType
    {
        public int Unical_id { get; }
        public string TypeName { get;}
        public static int Id = 0;

        public DrugType(string typename)
        {
            Unical_id = Id;
            TypeName = typename;
            Id++;            
        }

        public override string ToString()
        {
            return TypeName;
        }
    }
}
