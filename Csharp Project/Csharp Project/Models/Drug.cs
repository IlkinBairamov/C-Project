using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Project
{
    partial class Drug
    {
        public string Name { get; }
        public int Unical_id { get; }
        public int Price { get; }
        public int Count { get; set; }
        public  DrugType Type { get; }
        static int _Counter = 0;

        public Drug(string name,int price,int count,DrugType type)
        {
            Name = name;           
            Price = price;
            Count = count;
            Type = type;
            _Counter++;
            Unical_id = _Counter;
        }
        public override string ToString()
        {
            return Unical_id + "-" + Name + " " + Price + "$ " + " " + Count + " piece";
        }
    }
}
