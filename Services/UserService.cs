﻿using CrudApiTemplate.Services;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class UserService : ServiceCrud<User>
{
    public UserService(IWebUow work) : base(work.Users, work)
    {

    }

}