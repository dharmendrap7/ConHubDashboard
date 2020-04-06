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
   public class OrganizerBasicDetailsBL
    {
        private OrganizerBasicDetailsDAL DalObj;
        public OrganizerBasicDetailsBL()
        {
            DalObj = new OrganizerBasicDetailsDAL();
        }

        public async Task<RequestResult<GuidResult>> Savesponsordetails(string sessionToken, SponsorViewModel model)
        {
            try
            {

                var data = new SponsorDTO()
                {
                    UserId = model.UserId,
                    ImageId = model.ImageId,
                    Id = model.Id,
                    Image = model.Image,

                    Like = model.Like,
                    Comment = model.Comment,
                    Private = model.Private,
                    Public = model.Public,
                    Caption = model.Caption,
                    DateandTime = DateTime.UtcNow,
                };

                var result = await DalObj.SaveSponsorDetails(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<SponsorViewModel>>> GetSponsorList(string sessionToken,Guid? Userid)
        {
            try
            {
                var result = await DalObj.GetSponsorList(sessionToken, Userid);
                var sponsorList = new List<SponsorViewModel>();
                RequestResult<List<SponsorViewModel>> sponsor;

                foreach (var item in result)
                {
                    sponsorList.Add(new SponsorViewModel()
                    {
                        Id = item.Id,
                        Image = item.Image,
                        ImageId = item.ImageId,
                        Private = item.Private,
                        Public = item.Public,
                        Like = item.Like,
                        Caption = item.Caption,
                        DateandTime = item.DateandTime,
                        Comment = item.Comment,
                        UserId = item.UserId
                    });
                }
                sponsor = new RequestResult<List<SponsorViewModel>>(sponsorList);
                return await Task.FromResult(sponsor);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> SaveOrganizerAboutUs(string sessionToken, OrganizerAboutusViewModel model)
        {
            try
            {
                var data = new OrganizerAboutUsDTO()
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    NameOfOrganization = model.NameOfOrganization,
                    ContactNumber = model.ContactNumber,
                    MissionOfTheOrganization = model.MissionOfTheOrganization,
                    VisionofTheOrganization = model.VisionofTheOrganization,
                    Selfdesctiption = model.Selfdesctiption,
                    StartedInTheYear = model.StartedInTheYear,
                    Address = DetailsJsonBase.SaveToString<AddressDetailJson>(model.Address),
                    EmailId=model.EmailId,
                    Fax=model.Fax
                };
                var result = await DalObj.SaveOrganizerAboutUs(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<OrganizerAboutusViewModel>> GetOrganizerAboutUs(string sessionToken,Guid?Userid)
        {try
            {

                var result = await DalObj.GetOrganizerAboutus(sessionToken, Userid);
                OrganizerAboutusViewModel aboutUs = null;
                if (result != null)
                {
                    aboutUs = new OrganizerAboutusViewModel()
                    {
                        UserId = result.UserId,
                        VisionofTheOrganization = result.VisionofTheOrganization,
                        MissionOfTheOrganization = result.MissionOfTheOrganization,
                        StartedInTheYear = result.StartedInTheYear,
                        Address = DetailsJsonBase.LoadFromString<AddressDetailJson>(result.Address),
                        ContactNumber = result.ContactNumber,
                        NameOfOrganization = result.NameOfOrganization,
                        Selfdesctiption = result.Selfdesctiption,
                        Id = result.Id,
                        EmailId=result.EmailId,
                        Fax=result.Fax
                    };

                };
                var result1 = new RequestResult<OrganizerAboutusViewModel>(aboutUs);
                return await Task.FromResult(result1);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

    }
}
    


