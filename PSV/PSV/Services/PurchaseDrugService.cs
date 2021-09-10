using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Services
{
    public class PurchaseDrugService
    {

        public PurchaseDrugService() { }

        public bool Add(PurchaseDrug purDrug)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    PurchaseDrug drug = new PurchaseDrug();

                    //drug.Amount = 0 ;
                    drug.DrugId = purDrug.DrugId;
                    drug.PharmacyId = purDrug.PharmacyId;
                    drug.DrugName = purDrug.DrugName;
                    drug.Amount = purDrug.Amount;
                     
                    unitOfWork.PurchaseDrugs.Add(drug);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

    }
}
