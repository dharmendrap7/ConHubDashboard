﻿using Conquerorhub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.SDK.ViewModels
{
   public class ParticipantsAboutViewModel
    {
        public Basicdetails basicDetails { get; set; }
        public ContactInformation contactInformation { get; set; }
        public Educationqualification EducationQualification { get; set; }
        public System.Guid Id { get; set; }
        public string Userid { get; set; }

    }
    public class Basicdetails : DetailsJsonBase
    {
        public string FullName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string NativePlace { get; set; }
        public string LivesAt { get; set; }
    }
    public class ContactInformation : DetailsJsonBase
    {
        public Int64 Phonenumber { get; set; }
        public string email { get; set; }
    }
    public class Educationqualification : DetailsJsonBase
    {
        public string highschool { get; set; }
        public string preuniversity { get; set; }
        public string Ug { get; set; }
        public string Pg { get; set; }
        public string Phd { get; set; }
    }
}