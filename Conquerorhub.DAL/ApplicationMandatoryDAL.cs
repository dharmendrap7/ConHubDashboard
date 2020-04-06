using Conquerorhub.DAL.DTO;
using Conquerorhub.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.DAL
{
   public class ApplicationMandatoryDAL
    {
        public async Task<GuidResult> SaveSessionDetails(SessionTokenDTO model)
        {
            using (var db = new ConquerorHubEntities1())
            {
                var user = db.SessionTokens.Where(x => x.UserId == model.UserId).Select(x => x).FirstOrDefault();

                if (user != null)
                {
                    var data = db.CH_LastLogin.Where(x => x.UserId == model.UserId).Select(x => x).FirstOrDefault();
                    if (data == null)
                    {
                        var details1 = new CH_LastLogin()
                        {
                            UserId = user.UserId,
                            ExpiryDateTime = user.ExpiryDateandTime,
                            CreatedDateandTime = user.CreatedDateandTime,
                            SessionToken = user.SessionToken1,


                        };
                        try
                        {
                            db.CH_LastLogin.Add(details1);
                            //db.DAP_USER_KYC_DOCUMENTS.AddRange(kycDetails);
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                    else
                    {
                        data.CreatedDateandTime = user.CreatedDateandTime;
                        data.ExpiryDateTime = user.ExpiryDateandTime;
                        data.SessionToken = user.SessionToken1;
                        try
                        {
                            db.Entry(data).State = EntityState.Modified;


                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                    user.SessionToken1 = model.SessionToken1;
                    user.CreatedDateandTime = model.CreatedDateandTime;
                    user.ExpiryDateandTime = model.ExpiryDateandTime;
                    try
                    {
                        db.Entry(user).State = EntityState.Modified;


                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                else
                {

                    var details = new SessionToken()
                    {
                        id = model.id,
                        SessionToken1 = model.SessionToken1,
                        UserId = model.UserId,
                        ExpiryDateandTime = model.ExpiryDateandTime,
                        CreatedDateandTime = model.CreatedDateandTime
                    };
                    try
                    {
                        db.SessionTokens.Add(details);
                       
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                return await Task.FromResult(new GuidResult(Guid.Empty));
            }
        }
        public async Task<List<AspnetUserDTO>> GetAspnetusers(string sessionToken)
        {


            using (var db = new ConquerorHubEntities1())
            {
               
                try
                {
                    var result = (from details in db.AspNetUsers


                                  select new AspnetUserDTO()
                                  {
                                      Id = details.Id,
                                     Email=details.Email,
                                     TwoFactorEnabled=details.TwoFactorEnabled,
                                     UserActive=details.UserActive,
                                     UserName=details.UserName,
                                     Usertype=details.Usertype,


                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception)
                {
                    throw new Exception("Error getting sponsors");
                }




            }
        }
        public async Task<LastLoginDTO> GetLastLogin(string sessionToken)
        {


            using (var db = new ConquerorHubEntities1())
            {
               var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                try
                {
                    var result = (from details in db.CH_LastLogin 
                                  where details.UserId==userId

                                  select new LastLoginDTO()
                                  {
                                      Id = details.Id,
                                      UserId = details.UserId,
                                      ExpiryDateTime = details.ExpiryDateTime,
                                      CreatedDateandTime = details.CreatedDateandTime,
                                      SessionToken = details.SessionToken,

                                  }).FirstOrDefault();
                    return await Task.FromResult(result);
                }
                catch (Exception)
                {
                    throw new Exception("Error getting sponsors");
                }




            }
        }

    }
}
