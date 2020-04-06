using Conquerorhub.DAL;
using Conquerorhub.DAL.DTO;
using Conquerorhub.Model;
using Conquerorhub.SDK.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.SDK.BusinessLogic
{
   public class ParticipantsBL
    {
        private ParticipantsDAL DalObj;
        public ParticipantsBL()
        {

            DalObj = new ParticipantsDAL();
        }
        public async Task<RequestResult<GuidResult>> SaveParticipantsdetails(string sessionToken, ParticipationRegistrationViewModel model)
        {
            try
            {

                var data = new ParticipantRegistrationDTO()
                {
                    EventId = model.EventId,
                    OrganizerId = model.OrganizerId,
                    ParticipantId = model.ParticipantId,
                    Name = model.Name,
                    DateOfBirthh = model.DateOfBirthh,
                    Qualification = model.Qualification,
                    Modeofcompitetion = (modeofcompetationDTO)model.Modeofcompitetion,
                    CollegeorSchool = model.CollegeorSchool,
                    ContactNumber = model.ContactNumber,
                    ContentType = model.ContentType,
                    Data = model.Data,
                    FileName = model.FileName,
                    VideoId = model.VideoId,
                    ParticipantStatus = model.ParticipantStatus,
                    About_Self=model.About_Self
                };
                var result = await DalObj.SaveParticipantsdetails(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<ParticipationRegistrationViewModel>>> GetParticipantsdetails(string sessionToken,Guid eventid)
        {
            try
            {
                var result = await DalObj.GetParticipantsdetails(sessionToken, eventid);
                var participantsList = new List<ParticipationRegistrationViewModel>();
                RequestResult<List<ParticipationRegistrationViewModel>> participants;

                foreach (var item in result)
                {
                    participantsList.Add(new ParticipationRegistrationViewModel()
                    {
                        Id = item.Id,

                        Name = item.Name,
                        Modeofcompitetion = (modeofcompetation)Enum.Parse(typeof(modeofcompetation), item.Modeofcompitetion.ToString()),
                        Qualification = item.Qualification,
                        DateOfBirthh = item.DateOfBirthh,
                        About_Self = item.About_Self,
                        CollegeorSchool = item.CollegeorSchool,
                        ContactNumber = item.ContactNumber,
                        EventId = item.EventId,
                        OrganizerId = item.OrganizerId,
                        ContentType = item.ContentType,
                        Data = item.Data,
                        FileName = item.FileName,
                        VideoId = item.VideoId,
                        ParticipantStatus = item.ParticipantStatus
                    });
                }
                participants = new RequestResult<List<ParticipationRegistrationViewModel>>(participantsList);
                return await Task.FromResult(participants);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<GalleryViewModel>>> GetParticipantsPhotoGallery(string sessionToken, Guid? Userid)
        {
            try
            {

                var result = await DalObj.GetParticipantPhotoGallery(sessionToken, Userid);
                var sponsorList = new List<GalleryViewModel>();
                RequestResult<List<GalleryViewModel>> sponsor;

                foreach (var item in result)
                {
                    sponsorList.Add(new GalleryViewModel()
                    {
                        Id = item.Id,
                        ImageData = item.ImageData,
                        Caption = item.Caption,
                        UserId = item.UserId,
                        PostId = item.PostId,
                        ContentType = item.ContentType,
                        DateAndTime = item.DateAndTime
                    });
                }
                sponsor = new RequestResult<List<GalleryViewModel>>(sponsorList);
                return await Task.FromResult(sponsor);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<RequestResult<GuidResult>> SaveParticipantsPhotoGallery(string sessionToken, GalleryViewModel model)
        {
            try
            {
                // RequestResult<SponsorDTO> rrUserDetails;
                var data = new GalleryDTO()
                {
                    Id = model.Id,
                    ImageData = model.ImageData,
                    Caption = model.Caption,
                    UserId = model.UserId,
                    PostId = model.PostId,
                    ContentType = model.ContentType

                };

                var result = await DalObj.SaveParticipantPhotoGallery(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RequestResult<GuidResult>> SaveParticipantAbout(string sessionToken, ParticipantsAboutViewModel model)
        {

            try
            {
                var data = new ParticipantsAboutDTO()
                {

                    BasicDetails = DetailsJsonBase.SaveToString<Basicdetails>(model.basicDetails)
                        ,
                    ContactDetails = DetailsJsonBase.SaveToString<ContactInformation>(model.contactInformation),
                    EducationDetails = DetailsJsonBase.SaveToString<Educationqualification>(model.EducationQualification),
                    Userid = model.Userid,
                    Id = model.Id



                };
                var result = await DalObj.SaveParticipantBsicdetails(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<ParticipantsAboutViewModel>>> GetParticipantsAbout(string sessionToken, Guid? Userid)
        {
            try
            {
                var result = await DalObj.GetParticipantsAbout(sessionToken, Userid);
                var sponsorList = new List<ParticipantsAboutViewModel>();
                RequestResult<List<ParticipantsAboutViewModel>> sponsor;

                foreach (var item in result)
                {
                    sponsorList.Add(new ParticipantsAboutViewModel()
                    {
                        basicDetails = DetailsJsonBase.LoadFromString<Basicdetails>(item.BasicDetails),
                        contactInformation = DetailsJsonBase.LoadFromString<ContactInformation>(item.ContactDetails),
                        EducationQualification = DetailsJsonBase.LoadFromString<Educationqualification>(item.EducationDetails),

                    });
                }
                sponsor = new RequestResult<List<ParticipantsAboutViewModel>>(sponsorList);
                return await Task.FromResult(sponsor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
