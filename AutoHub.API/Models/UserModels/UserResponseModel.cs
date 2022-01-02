﻿using System;
using System.Collections.Generic;

namespace AutoHub.API.Models.UserModels
{
    public class UserResponseModel
    {
        public int UserId { get; set; }

        public string Username { get; set; }
        
        public IList<string> UserRoles { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistrationTime { get; set; }
    }
}