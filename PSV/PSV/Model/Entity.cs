using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class Entity
    {
        public Entity() { }

        public Entity(int newId, bool del)
        {
            id = newId;
            deleted = del;
        }

        private int id;

        private bool deleted;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }

    }
}
