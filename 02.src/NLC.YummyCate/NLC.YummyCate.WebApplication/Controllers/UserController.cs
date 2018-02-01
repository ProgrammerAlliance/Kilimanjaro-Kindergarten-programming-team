﻿using NLC.YummyCate.BLL;
using NLC.YummyCate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NLC.YummyCate.WebApplication.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public OperationResult<Boolean> UserLogin(string username, string password)
        {
            UserBLL userBLL = new UserBLL();
            return userBLL.UserLogin(username, password);
        }

        public OperationResult<Boolean> Login(string username, string password)
        {
            UserBLL userBLL = new UserBLL();
            return userBLL.UserLogin(username, password);
        }

        [HttpGet]
        public bool Test()
        {
            return true;
        }
    }
}
