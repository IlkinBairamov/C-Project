using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Project
{
    class Helper
    {
        public static void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void Print(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(text);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                
            }           
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static IEnumerable<string> GetMenyu()
        {
            foreach (var item in Enum.GetValues(typeof(Menu)))
            {
                yield return $"{(int)item}-{item}";
            }
        }

        public enum SaleDrug
        {
            ThisDrugNotFound=1,
            LessDrugCount,
            LessBalance,
            Successfully
        }
         
        public enum Menu
        {
            AddPharmacy=1,
            AddDrug,
            InfoDrug,
            ShowDrugItem,
            SaleDrug,
            Quit
        }
    }
    
}
