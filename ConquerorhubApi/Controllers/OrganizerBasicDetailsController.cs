using Conquerorhub.Model;
using Conquerorhub.SDK.Services;
using Conquerorhub.SDK.ViewModels;
using ConquerorhubApi.Errorhandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConquerorhubApi.Controllers
{[RoutePrefix("api/OrganizerDetails")]
    public class OrganizerBasicDetailsController : ApiController
    {
        private OrganizerBasicDetailsServices services;
        public OrganizerBasicDetailsController()
        {
            services = new OrganizerBasicDetailsServices();
        }
        [HttpPost]
        [Route("savesponsordetails")]
        public async Task<RequestResult<GuidResult>> SaveUserSecurity(string sessionToken, SponsorViewModel model)
        {
            try
            {

                var result = await services.SaveCorporateApplicantDetails(sessionToken, model);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }

        
        [Route("getsponsordetails")]
        public async Task<RequestResult<List<SponsorViewModel>>> GetSponsorDetails(string sessionToken,Guid? userid)
        {

            try
            {
                var result = await services.GetSponsorList(sessionToken, userid);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [Route("getorganizeraboutus")]
        public async Task<RequestResult<OrganizerAboutusViewModel>> GetOrganizerAboutUs(string sessionToken,Guid? UserId)
        {

            try
            {
                var result = await services.GetOrganizerAboutUs(sessionToken, UserId);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }

        [HttpPost]
        [Route("saveorganizeraboutus")]
        public async Task<RequestResult<GuidResult>> SaveOrganizerAboutUs(string sessionToken, OrganizerAboutusViewModel model)
        {
            try
            {

                var result = await services.SaveOrganizerAboutUs(sessionToken, model);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }


    }
}
