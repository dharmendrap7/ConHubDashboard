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
{
    [RoutePrefix("api/applicationmandatory")]
    public class ApplicationMandatoryController : ApiController
    {
        private ApplicationMandatoryService obj;
        public ApplicationMandatoryController()
        {
            obj = new ApplicationMandatoryService();
        }



        [Route("savesessiontoken")]
        [HttpPost]
        public async Task<RequestResult<GuidResult>> SaveUserToken(SessionTokenViewModel model)
        {try
            {
                var services = new ApplicationMandatoryService();
                var result = await services.SaveUsersession(model);
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;

            }
        }

        [Route("getuserlist")]
        public async Task<RequestResult<List<AspnetuserViewModel>>> GetUserList(string sessionToken)
        {

            try
            {
                var result = await obj.Getuserlist(sessionToken);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [Route("getlastlogin")]
        public async Task<RequestResult<LastLoginViewModel>> GetlastLogin(string sessionToken)
        {

            try
            {
                var result = await obj.GatLastLogin(sessionToken);

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
