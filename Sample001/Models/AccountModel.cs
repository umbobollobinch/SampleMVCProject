using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample001.Models
{
    public class AccountModel
    {
        public string User { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; } = "";
        public string SID { get; set; } = "";
    }
}
