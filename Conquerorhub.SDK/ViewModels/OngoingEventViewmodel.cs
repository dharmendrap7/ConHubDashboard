using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.SDK.ViewModels
{
   public class OngoingEventViewmodel
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> Eventid { get; set; }
        public string UserId { get; set; }
        public Nullable<int> ParticipantStatus { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public Nullable<int> EventStatus { get; set; }
        public Nullable<System.Guid> VideoId { get; set; }
    }
}
