using System;

namespace DTO.Entity
{
    public class Entity {

        public int EntityId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOA { get; set; }
        public string MobileNo { get; set; }
        public string AlternateNo { get; set; }
        public string EmergencyContactNo { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastUpdatedById { get; set; }
        public DateTime LastmodifiedDate { get; set; }

    }
}
