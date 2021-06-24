﻿using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Core
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByEmail(string email);
    }
}
