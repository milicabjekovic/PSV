using PSV.Core;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PSVContext context;

        public IUserRepository Users { get; private set; }
        public IExaminationRepository Examinations { get; private set; }
        public IFeedbackRepository Feedbacks { get; private set; }
        public IBusinessHours BusinessHours { get; private set; }
        public IInstructionRepository Instructions{ get; private set; }
        public IPurchaseDrugRepository PurchaseDrugs { get; private set; }

        public UnitOfWork(PSVContext context) 
        {
            this.context = context;
            Users = new UserRepository(this.context);
            Examinations = new ExaminationRepository(this.context);
            Feedbacks = new FeedbackRepository(this.context);
            BusinessHours = new BusinessHoursRepository(this.context);
            Instructions = new InstructionRepository(this.context);
            PurchaseDrugs = new PurchaseDrugRepository(this.context);
    }

        public PSVContext Context
        {
            get { return context; }
        }

        public int Complete() {
            return context.SaveChanges();
        }

        public void Dispose() {
            context.Dispose();
        }
    }
}
