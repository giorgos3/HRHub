﻿using HRHub.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Infrastructure.Repositories
{
    internal sealed class UserRepository : Repository<User> , IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
        
        }
    }
}
