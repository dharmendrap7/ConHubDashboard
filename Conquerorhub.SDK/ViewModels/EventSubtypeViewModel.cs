using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.SDK.ViewModels
{
  public  class EventSubtypeViewModel
    {
        public int Id { get; set; }
        public Nullable<int> EventReferenceId { get; set; }
        public string EventSubType { get; set; }
    }
}
