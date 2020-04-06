using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.DAL.DTO
{
  public  class OrganizerAboutUsDTO
    {
        public System.Guid Id { get; set; }
        public string UserId { get; set; }
        public string NameOfOrganization { get; set; }
        public Nullable<System.DateTime> StartedInTheYear { get; set; }
        public string Address { get; set; }
        public Nullable<Int64> ContactNumber { get; set; }
        public string VisionofTheOrganization { get; set; }
        public string MissionOfTheOrganization { get; set; }
        public string Selfdesctiption { get; set; }
        public string EmailId { get; set; }
        public Nullable<long> Fax { get; set; }
    }
}
