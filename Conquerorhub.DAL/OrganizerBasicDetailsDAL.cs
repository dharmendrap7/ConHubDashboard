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
    public class OrganizerBasicDetailsDAL
    {
        public async Task<GuidResult> SaveSponsorDetails(string sessionToken, SponsorDTO model)
        {
            using (var db = new ConquerorHubEntities1())
            {
                var data = new Sponsor()
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    DateandTime = model.DateandTime,
                    Like = model.Like,
                    Caption = model.Caption,
                    Comment = model.Comment,
                    Image = model.Image,
                    Private = model.Private,
                    Public = model.Public,
                    ImageId = model.ImageId

                };
                try
                {
                    db.Sponsors.Add(data);
                    db.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw;
                }
                return await Task.FromResult(new GuidResult(new Guid()));


            }
        }

        public async Task<List<SponsorDTO>> GetSponsorList(string sessionToken,Guid ?Userid)
        {


            using (var db = new ConquerorHubEntities1())
            {
               
                try
                {
                    var result = (from details in db.Sponsors
                                 

                                  select new SponsorDTO()
                                  {
                                      Id = details.Id,
                                      Image = details.Image,
                                      Private = details.Private,
                                      Public = details.Private,
                                      ImageId = details.ImageId,
                                      Comment = details.Comment,
                                      Like = details.Like,
                                      Caption = details.Caption,
                                      DateandTime = details.DateandTime,
                                      UserId=details.UserId


                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception)
                {
                    throw new Exception("Error getting sponsors");
                }




            }
        }
        public async Task<GuidResult> SaveOrganizerAboutUs(string sessionToken, OrganizerAboutUsDTO model)
        {
            CH_OrganiztionAboutUs data = null;
            using (var db = new ConquerorHubEntities1())
            {
                var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                var count = db.CH_OrganiztionAboutUs.Where(a => a.UserId == userId).Count();
                if (count == 0)
                {
                    data = new CH_OrganiztionAboutUs()
                    {
                        Id = model.Id,
                        UserId = model.UserId,
                        NameOfOrganization = model.NameOfOrganization,
                        StartedInTheYear = model.StartedInTheYear,
                        ContactNumber =model.ContactNumber,
                        VisionofTheOrganization = model.VisionofTheOrganization,
                        MissionOfTheOrganization = model.MissionOfTheOrganization,
                        Selfdesctiption = model.Selfdesctiption,
                        Address = model.Address,
                        Datetime = DateTime.UtcNow,
                        EmailId=model.EmailId,
                        Fax=model.Fax


                    };


                    try
                    {
                        db.CH_OrganiztionAboutUs.Add(data);
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
                    var data1 = db.CH_OrganiztionAboutUs.Where(m => m.UserId == userId).Select(m => m).FirstOrDefault();
                    
                    data1.ContactNumber = model.ContactNumber;
                    data1.VisionofTheOrganization = model.VisionofTheOrganization;
                    data1.StartedInTheYear = model.StartedInTheYear;
                    data1.Selfdesctiption = model.Selfdesctiption;
                    data1.MissionOfTheOrganization = model.MissionOfTheOrganization;
                    data1.NameOfOrganization = model.NameOfOrganization;
                    data1.Address = model.Address;


                    try
                    {
                        db.Entry(data1).State = EntityState.Modified;
                        //db.DAP_USER_KYC_DOCUMENTS.AddRange(kycDetails);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

            }
            return await Task.FromResult(new GuidResult(Guid.Empty));
        }
        public async Task<OrganizerAboutUsDTO> GetOrganizerAboutus(string sessionToken,Guid?Userid)
        {
            using (var db = new ConquerorHubEntities1())
            {
                var userId = "";
                if (Userid != null) { userId = Userid.ToString(); }
                else {

                    userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                }
                var data = db.CH_OrganiztionAboutUs.Where(x => x.UserId == userId).Select(x => x).FirstOrDefault();
                OrganizerAboutUsDTO result = null;
                try
                {
                    if (data != null)
                    {
                         result = new OrganizerAboutUsDTO()
                        {
                            UserId = data.UserId,
                            NameOfOrganization = data.NameOfOrganization,
                            VisionofTheOrganization = data.VisionofTheOrganization,
                            MissionOfTheOrganization = data.MissionOfTheOrganization,
                            StartedInTheYear = data.StartedInTheYear,
                            Address = data.Address,
                            ContactNumber = data.ContactNumber,
                            Selfdesctiption = data.Selfdesctiption,
                            EmailId=data.EmailId,
                            Fax=data.Fax

                        };

                     
                    }
                    return await Task.FromResult(result);
                }


                catch (Exception ex)
                {
                    throw new Exception("Error getting sponsors");
                }

            }

        }
    }
}