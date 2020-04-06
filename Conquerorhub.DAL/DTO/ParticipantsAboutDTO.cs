using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.DAL.DTO
{
   public class ParticipantsAboutDTO
    {
        public System.Guid Id { get; set; }
        public string Userid { get; set; }
        public string BasicDetails { get; set; }
        public string ContactDetails { get; set; }
        public string EducationDetails { get; set; }
    }

}
