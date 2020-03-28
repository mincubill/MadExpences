using System;
using System.Collections.Generic;

namespace MadExpences.Core
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserPrivilege UserPrivilege { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Category> Categories { get; set; }

    }

    public enum UserPrivilege
    {
        User = 1,
        Admin = 2,
    }
}
