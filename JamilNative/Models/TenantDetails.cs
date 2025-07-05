using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamilNative.Models
{
    public class TenantDetails
    {
        //public int TenantId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string NinNumber { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public string Gender { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public int OccupantsNumber { get; set; }

        public int MaritalstatusId { get; set; }

        public string NextofkinName { get; set; } = null!;

        public int NokRelationshipId { get; set; }

        public string NokPhonenumber { get; set; } = null!;

        public int HouseId { get; set; }

        public DateTime AddedOn = DateTime.Now;

        public string TdMaritalstatus { get; set; } = null!;

        public string TdNokRelationship { get; set; } = null!;

        public string TdHouse { get; set; } = null!;


    }
}
