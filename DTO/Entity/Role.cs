using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    [Table(tableName: "ROLES")]
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastUpdatedById { get; set; }
        public DateTime LastmodifiedDate { get; set; }
    }
}
