using Conquerorhub.DAL;
using Conquerorhub.DAL.DTO;
using Conquerorhub.Model;
using Conquerorhub.SDK.BusinessLogic;
using Conquerorhub.SDK.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.SDK.Services
{
    public class OrganizerBasicDetailsServices
    {
        private OrganizerBasicDetailsBL bldata;
        public OrganizerBasicDetailsServices()
        {
            bldata = new OrganizerBasicDetailsBL();
        }

        public async Task<RequestResult<GuidResult>> SaveCorporateApplicantDetails(string sessionToken, SponsorViewModel model)
        {
            try
            {
                var returnData = await bldata.Savesponsordetails(sessionToken, model);
                return returnData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RequestResult<List<SponsorViewModel>>> GetSponsorList(string sessionToken,Guid?Userid)
        {

            try
            {
                return await bldata.GetSponsorList(sessionToken, Userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RequestResult<GuidResult>> SaveOrganizerAboutUs(string sessionToken, OrganizerAboutusViewModel model)
        {
            try
            {
                var returnData = await bldata.SaveOrganizerAboutUs(sessionToken, model);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<OrganizerAboutusViewModel>> GetOrganizerAboutUs(string sessionToken,Guid?Userid)
        {

            try
            {
                return await bldata.GetOrganizerAboutUs(sessionToken, Userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

