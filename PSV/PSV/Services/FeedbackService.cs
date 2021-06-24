using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Services
{
    public class FeedbackService
    {
        public Feedback Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    return unitOfWork.Feedbacks.Get(id);
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return null;
        }

        public IEnumerable<Feedback> GetAll()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    return unitOfWork.Feedbacks.GetAll();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Add(Feedback feed)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    Feedback newFeed = new Feedback();

                    newFeed.Feed= feed.Feed;

                    unitOfWork.Feedbacks.Add(newFeed);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Edit(int id, Feedback feed)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    Feedback feedDB = Get(id);

                    unitOfWork.Feedbacks.Update(feedDB);

                    feedDB.Feed = feed.Feed;
                    
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    Feedback feeds = Get(id);

                    unitOfWork.Feedbacks.Remove(feeds);


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
