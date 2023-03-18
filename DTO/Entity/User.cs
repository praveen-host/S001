using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastmodifiedDate { get; set; }
    }

    public class UserDetail
    {
        public int UserDetailId { get; set; }
        public int UserId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string Gender { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastmodifiedDate { get; set; }

    }
}
