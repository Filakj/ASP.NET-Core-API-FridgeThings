using System;
using System.Collections.Generic;
using System.Text;

namespace WhatYouGot.Library.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Passphrase { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
