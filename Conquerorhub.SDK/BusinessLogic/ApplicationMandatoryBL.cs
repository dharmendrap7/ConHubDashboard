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
    public class ApplicationMandatoryBL
    {
        private ApplicationMandatoryDAL obj;
        public ApplicationMandatoryBL()
        {

            obj = new ApplicationMandatoryDAL();
        }

        public async Task<RequestResult<GuidResult>> SaveSessionToken(SessionTokenViewModel model)
        {
            try
            {

                var SessionTable = new SessionTokenDTO()
                {
                    id = model.id,
                    SessionToken1 = model.SessionToken1,
                    UserId = model.UserId,

                    CreatedDateandTime = model.CreatedDateandTime,
                    ExpiryDateandTime = model.ExpiryDateandTime
                };

                var result = await obj.SaveSessionDetails(SessionTable);
                var rrUserDetails = new RequestResult<GuidResult>(result);
                return await Task.FromResult(rrUserDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<AspnetuserViewModel>>> Getuserslist(string sessionToken)
        {
            try
            {

                var result = await obj.GetAspnetusers(sessionToken);
                List<AspnetuserViewModel> usersList = new List<AspnetuserViewModel>();
                if (result != null)
                {

                    foreach (var item in result)
                    {
                        usersList.Add(new AspnetuserViewModel()
                        {
                            Id = item.Id,
                            Email = item.Email,
                            //TwoFactorEnabled = item.TwoFactorEnabled,
                            UserActive = item.UserActive,
                            UserName = item.UserName,
                            Usertype = item.Usertype,

                        });
                    }

                };
                var result1 = new RequestResult<List<AspnetuserViewModel>>(usersList);
                return await Task.FromResult(result1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RequestResult<LastLoginViewModel>> GetLastLogin(string sessionToken)
        {
            try
            {

                var result = await obj.GetLastLogin(sessionToken);
                LastLoginViewModel lastLogin = new LastLoginViewModel();
                if (result != null)
                {
                    lastLogin.UserId = result.UserId;
                    lastLogin.ExpiryDateTime = result.ExpiryDateTime;
                    lastLogin.CreatedDateandTime = result.CreatedDateandTime;
                    lastLogin.SessionToken = result.SessionToken;                     
                    

                };
                var result1 = new RequestResult<LastLoginViewModel>(lastLogin);
                return await Task.FromResult(result1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
