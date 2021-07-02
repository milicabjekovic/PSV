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

                    IEnumerable<Feedback> list = unitOfWork.Feedbacks.GetAllPublished();

                    return list;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<Feedback> GetAllAdminFeedback()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    return unitOfWork.Feedbacks.GetAllAdmin();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }



        public bool Add(Feedback feed, User user)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    Feedback newFeed = new Feedback();

                    newFeed.Feed= feed.Feed;
                    newFeed.PatientEmail = user.Email;
                    newFeed.IsPublish = false;

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

        public bool addPublishFeedback(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    Feedback feed = unitOfWork.Feedbacks.Get(id);

                    unitOfWork.Feedbacks.Update(feed);
                    feed.IsPublish = true;
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

        public List<Feedback> getAllPatinetFeedbacks(User user)
        {
            List<Feedback> list = new List<Feedback>();
            IEnumerable<Feedback> listFeedbacks = GetAll();

            foreach (Feedback feed in listFeedbacks)
            {

                if (feed.PatientEmail == user.Email)
                {
                    list.Add(feed);
                }
            }

            return list;
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    Feedback feeds = Get(id);

                    unitOfWork.Feedbacks.Update(feeds);
                    feeds.Deleted = true;
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
