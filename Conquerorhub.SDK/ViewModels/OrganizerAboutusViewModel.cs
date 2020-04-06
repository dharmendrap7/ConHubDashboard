using Conquerorhub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.SDK.ViewModels
{
    public class OrganizerAboutusViewModel
    {
        public System.Guid Id { get; set; }
        public string UserId { get; set; }
        public string NameOfOrganization { get; set; }
        public Nullable<System.DateTime> StartedInTheYear { get; set; }
        public AddressDetailJson Address { get; set; }
        public Nullable<Int64> ContactNumber { get; set; }
        public string VisionofTheOrganization { get; set; }
        public string MissionOfTheOrganization { get; set; }
        public string Selfdesctiption { get; set; }
        public string EmailId { get; set; }
        public Nullable<long> Fax { get; set; }
    }

    public class AddressDetailJson:DetailsJsonBase
    {
        public string Nationality { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int zip { get; set; }
        public string ProperAddress { get; set; }



    }
}
