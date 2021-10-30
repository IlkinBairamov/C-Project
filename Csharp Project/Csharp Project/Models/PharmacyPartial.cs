using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Csharp_Project.Helper;

namespace Csharp_Project
{
    partial class Pharmacy
    {
        public override string ToString()
        {
            return Unical_id + "-" + Name ;
        }
        public bool AddDrug(Drug drug)
        {
            Drug findDrug = _drugs.Find(x => x.Name.ToLower() == drug.Name.ToLower());
            if (findDrug!=null)
            {
                findDrug.Count += drug.Count;
                return false;
            }
            _drugs.Add(drug);
            return true;
        }
        public Drug InfoDrug(string name)
        {
           
            var drug = _drugs.Find(x=>x.Name.ToLower()== name.ToLower());
            if (drug!=null)
            {
                return drug;
            }
            return null;

        }
        public IEnumerable<Drug> ShowDrugItems()
        {
            if (_drugs.Count==0)
            {
                yield break;
            }
            foreach (Drug drug in _drugs)
            {
                yield return drug;
            }
        }


        public SaleDrug SaleDrug(string name,int countDrug,int money)
        {
            var drug = _drugs.Find(x=>x.Name.ToLower()==name.ToLower());
            if (drug==null)
            {
                return Helper.SaleDrug.ThisDrugNotFound ;
            }
            else if (drug.Count < countDrug)
            {
                return Helper.SaleDrug.LessDrugCount;
            }
            else if (money < drug.Price*countDrug)
            {
                return Helper.SaleDrug.LessBalance;
            }
            drug.Count -= countDrug;
            return Helper.SaleDrug.Successfully;
        }
        public int DrugCount()
        {
            return _drugs.Count;
        }
    }
}


