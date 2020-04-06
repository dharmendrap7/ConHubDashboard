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
    public class ApplicationMandatoryService
    {
        private ApplicationMandatoryBL obj;
        public ApplicationMandatoryService()
        {
            obj = new ApplicationMandatoryBL();
        }


        public async Task<RequestResult<GuidResult>> SaveUsersession(SessionTokenViewModel model)
        {
            try
            {
                return await obj.SaveSessionToken(model);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<AspnetuserViewModel>>> Getuserlist(string sessionToken)
        {

            try
            {
                return await obj.Getuserslist(sessionToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<LastLoginViewModel>> GatLastLogin(string sessionToken)
        {

            try
            {
                return await obj.GetLastLogin(sessionToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
