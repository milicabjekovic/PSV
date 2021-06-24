using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class PageModel
    {

        private int page = 0;
        private int perPage = 30;
        private string search = string.Empty;

        public PageModel() 
        { 
        
        }

        public PageModel(int page, int perPage, string search) 
        {
            this.page = page;
            this.perPage = perPage;
            this.search = search == null ? string.Empty : search;
        }

        public int Page
        {
            get { return page; }
            set { page = value; }
        }

        public string Search 
        {
            get { return search; }
            set { search = value;  }
        }
    }
}
