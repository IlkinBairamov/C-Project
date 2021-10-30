using System;
using System.Collections.Generic;
using System.Threading;
using static Csharp_Project.Helper;

namespace Csharp_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pharmacy> pharmacys = new List<Pharmacy>();

            while (true)
            {
                foreach (var item in Helper.GetMenyu())
                {
                    Helper.Print(item, ConsoleColor.Yellow);
                }
                Console.WriteLine();
                Helper.Print("Choose any method:", ConsoleColor.Blue);
                
                

                string result = Console.ReadLine();
                bool isInt = int.TryParse(result, out int menu);
                if (isInt && (menu >= 1 && menu <= 6))
                {
                    if (menu == 6)
                        break;
                    Menu newMenu = (Menu)menu;                    
                    switch (newMenu)
                    {
                        #region AddPharmacy

                        
                        case Menu.AddPharmacy:                            
                            Helper.Print("Add new phermacy:", ConsoleColor.Yellow);
                            string PhermacyName = Console.ReadLine();

                            if (pharmacys.Exists(x=>x.Name.ToLower()== PhermacyName.ToLower()))   
                            {
                                Helper.Print("This pharmacy available.Please create new pharmacy");
                                goto case Menu.AddPharmacy;
                            }

                            Pharmacy pharmacyy = new Pharmacy(PhermacyName);
                            pharmacys.Add(pharmacyy);
                            Helper.Print($"Successfully! {PhermacyName} is created",ConsoleColor.Green);
                            Helper.Print("Please wait for select new methot", ConsoleColor.Blue);
                            Thread.Sleep(4000);
                            Console.Clear();
                            break;
                        #endregion
                        #region AddDrug
                        case Menu.AddDrug:
                            if (pharmacys.Count == 0)
                            {
                                Helper.Print(" Pharmacy not found");
                                goto case Menu.AddPharmacy;
                            }

                            Helper.Print("Input drug's name", ConsoleColor.Yellow);
                            string drugname = Console.ReadLine();

                            Drugcount:
                            Helper.Print("Input drug's count", ConsoleColor.Yellow);
                            string countdrugs = Console.ReadLine();
                            isInt = int.TryParse(countdrugs, out int count);
                            if (!isInt)
                            {
                                Helper.Print("Enter correct number");
                                goto Drugcount;
                            }

                            drugPrice:
                            Helper.Print("Input drug's price", ConsoleColor.Yellow);
                            string pricedrugs = Console.ReadLine();
                            isInt = int.TryParse(pricedrugs, out int price);
                            if (!isInt)
                            {
                                Helper.Print("Enter correct Price");
                                goto drugPrice;
                            }


                            Helper.Print("Input drug's type", ConsoleColor.Yellow);
                            string type = Console.ReadLine();
                            DrugType drugType = new DrugType(type);
                            Console.WriteLine();

                            Pharmacy:
                            Helper.Print("Available pharmacies", ConsoleColor.Yellow);
                            foreach (var item in pharmacys)
                            {
                                Helper.Print(item.ToString(), ConsoleColor.Green);
                            }

                            Helper.Print("Input pharmacy name for select", ConsoleColor.Yellow);
                            PhermacyName = Console.ReadLine();
                            Pharmacy ExsistPharmacy = pharmacys.Find(x => x.Name.ToLower() == PhermacyName.ToLower());
                            if (ExsistPharmacy==null)
                            {
                                Helper.Print("Select available pharmacy");
                                goto Pharmacy;
                            }
                            Drug drug = new Drug(drugname, price, count, drugType);
                            if (!ExsistPharmacy.AddDrug(drug))
                            {
                                Helper.Print("Drug allready exist", ConsoleColor.Red);
                                Helper.Print($"The amount of {drug.Name} has increased {drug.Count} count",ConsoleColor.Green);
                                Helper.Print("Go to select new method", ConsoleColor.Blue);
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                            }
                            Helper.Print($"{drug.Name} is added {ExsistPharmacy.Name} pharmacy",ConsoleColor.Green);
                            Helper.Print("Go to select new method", ConsoleColor.Blue);
                            Thread.Sleep(4000);
                            Console.Clear();
                            break;
                        #endregion
                        #region ShowDrugItem                        
                        case Menu.ShowDrugItem:
                            if (pharmacys.Count==0)
                            {
                                Helper.Print("Pharmacy not found.Please Create Pharmacy");
                                goto case Menu.AddPharmacy;
                            }                           
                          
                            foreach (var item in pharmacys)
                            {                               
                                Helper.Print(item.Name, ConsoleColor.Green);   

                                foreach (var item1 in item.ShowDrugItems())
                                {                                   
                                   Helper.Print(item1.ToString(), ConsoleColor.Green);
                                }
                            }
                            break;

                        case Menu.InfoDrug:
                            if (pharmacys.Count == 0)
                            {
                                Helper.Print("Pharmacy not found.Please Create Pharmacy");
                                goto case Menu.AddPharmacy;
                            }
                            Helper.Print("List of Pharmacy's", ConsoleColor.Yellow);
                            foreach (var item in pharmacys)
                            {
                                Helper.Print(item.ToString(), ConsoleColor.Green);
                            }

                            pharmacyname:
                            Helper.Print("Input pharmacy name", ConsoleColor.Yellow);
                            PhermacyName = Console.ReadLine();
                            ExsistPharmacy = pharmacys.Find(x => x.Name.ToLower() == PhermacyName.ToLower());
                            if (ExsistPharmacy == null) 
                            {                                
                                Helper.Print("Choose correct  pharmacy name");
                                goto pharmacyname;
                            }
                            Helper.Print("Input name of drug", ConsoleColor.Yellow);
                        drugname:
                            drugname = Console.ReadLine();                           
                            if (ExsistPharmacy.InfoDrug(drugname)==null)
                            {
                                Helper.Print("This drug doesn't exist");
                                goto drugname;
                            }
                            Helper.Print("This drug has been found:", ConsoleColor.Blue);
                            drug = ExsistPharmacy.InfoDrug(drugname);
                            Helper.Print($"{drug}", ConsoleColor.Green);
                            Helper.Print("Go to select new method", ConsoleColor.Blue);
                            Thread.Sleep(4000);
                            Console.Clear();
                            break;
                        #endregion
                        #region SaleDrug                       
                        case Menu.SaleDrug:
                            if (pharmacys.Count == 0)
                            {
                                Helper.Print("Pharmacy not found.Please Create Pharmacy");
                                goto case Menu.AddPharmacy;
                            }

                            Helper.Print("List of Pharmacy's", ConsoleColor.Yellow);
                            foreach (var item in pharmacys)
                            {
                                Helper.Print(item.ToString(), ConsoleColor.Green);
                            }
                            inputparmacyname:
                            Helper.Print("Input pharmacy name", ConsoleColor.Yellow);
                            PhermacyName = Console.ReadLine();
                            ExsistPharmacy = pharmacys.Find(x => x.Name.ToLower() == PhermacyName.ToLower());
                            if (ExsistPharmacy == null)
                            {
                                Helper.Print("Choose correct  pharmacy name");
                                goto inputparmacyname;
                            }                            
                            if (ExsistPharmacy.DrugCount()==0)
                            {
                                Helper.Print($"There is no any drug in {ExsistPharmacy.Name}.Please add drug ", ConsoleColor.Red);
                                goto case Menu.AddDrug;
                            }
                            drugnamee:
                            Helper.Print("Input drug's name", ConsoleColor.Yellow);                           
                            drugname = Console.ReadLine();
                           
                            if (ExsistPharmacy.InfoDrug(drugname) == null)
                            {
                                Helper.Print("This drug doesn't exist");
                                goto drugnamee;
                            }
                        Drugcountt:
                            Helper.Print("Input drug's count", ConsoleColor.Yellow);
                             countdrugs = Console.ReadLine();
                            isInt = int.TryParse(countdrugs, out count);
                            if (!isInt)
                            {
                                Helper.Print("Enter correct number");
                                goto Drugcountt;
                            }
                            custombalance:
                            Helper.Print("Input custom balance", ConsoleColor.Yellow);
                            string custombalance = Console.ReadLine();
                            isInt = int.TryParse(custombalance, out int customerbalancee);
                            if (!isInt)
                            {
                                Helper.Print("Enter correct balance");
                                goto custombalance;
                            }
                           SaleDrug result1= ExsistPharmacy.SaleDrug(drugname, count, customerbalancee);
                            
                            if (result1==SaleDrug.LessDrugCount)
                            {
                                Helper.Print("Drug count not enough for sale");
                               Helper.Print($"{ ExsistPharmacy.InfoDrug(drugname)}",ConsoleColor.Green);
                                goto Drugcountt;
                            }
                            if (result1==SaleDrug.LessBalance)
                            {
                                Helper.Print("Your balance not enough for buy");
                                goto custombalance;
                            }
                            Helper.Print("Sale Successfully!", ConsoleColor.Green);
                            break;
                        #endregion
                        default:
                            break;
                    }
                }
                else
                {
                    Helper.Print("please choose from the numbers shown:");
                    Console.WriteLine();
                }
            }
        }
    }
}
