using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLAsite.Models
{
    public class User
    {
        public int UserNo { get; set; }
        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string regDate { get; set; }
        public string delYn { get; set; }
    }
}
