using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class PurchaseDrug : Entity
    {

        private int idD;

        private int idP;

        private string drugName;

        private int amount;

        public PurchaseDrug(int idD, int idP, string drugName, int amount)
        {
            this.idD = idD;
            this.idP = idP;
            this.drugName = drugName;
            this.amount = amount;
        }

        public PurchaseDrug() { }


        public int DrugId
        {
            get { return idD; }
            set { idD = value; }
        }

        public int PharmacyId
        {
            get { return idP; }
            set { idP = value; }
        }

        public string DrugName
        {
            get { return drugName; }
            set { drugName = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

    }
}
