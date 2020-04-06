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
    public class ParticipantsDAL
    {

        public async Task<GuidResult> SaveParticipantsdetails(string sessionToken, ParticipantRegistrationDTO model)
        {
            using (var db = new ConquerorHubEntities1())
            {
                var check = db.CH_ParticipantRegistration.Where(x => x.ParticipantId == model.ParticipantId && x.EventId==model.EventId).Count();
                if (check == 0)
                {
                    var data = new CH_ParticipantRegistration()
                    {
                        Id = Guid.NewGuid(),
                        EventId = model.EventId,
                        OrganizerId = model.OrganizerId,
                        ParticipantId = model.ParticipantId,
                        Name = model.Name,
                        DateOfBirthh = model.DateOfBirthh,
                        Qualification = model.Qualification,
                        Modeofcompitetion = (int)model.Modeofcompitetion,
                        CollegeorSchool = model.CollegeorSchool,
                        ContactNumber = model.ContactNumber,
                        ContentType = model.ContentType,
                        Data = model.Data,
                        FileName = model.FileName,
                        ParticipantsPostId = model.VideoId,
                        // ParticipantStatus = model.ParticipantStatus
                        About_Self = model.About_Self


                    };
                    try
                    {
                        db.CH_ParticipantRegistration.Add(data);
                        db.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    return await Task.FromResult(new GuidResult(new Guid()));
                }

                else
                {
                    var data1 = db.CH_ParticipantRegistration.Where(x => x.ParticipantId == model.ParticipantId).FirstOrDefault();

                    data1.Data = model.Data;
                    data1.ContentType = model.ContentType;
                    data1.ParticipantsPostId = model.VideoId;
                    data1.FileName = model.FileName;
                    try
                    {
                        db.Entry(data1).State = EntityState.Modified;
                    
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                    return await Task.FromResult(new GuidResult(Guid.Parse(model.ParticipantId)));
                }

            }

        }
        public async Task<GuidResult> SaveParticipantBsicdetails(string sessionToken, ParticipantsAboutDTO model)
        {
            using (var db = new ConquerorHubEntities1())
            {
                var check = db.CH_ParticipantsAbout.Where(x => x.Userid == model.Userid).Count();
                var userid = db.SessionTokens.Where(x => x.SessionToken1 == sessionToken).FirstOrDefault().UserId;
                if (check == 0)
                {
                    var data = new CH_ParticipantsAbout()
                    {
                       
                        BasicDetails=model.BasicDetails,
                        ContactDetails=model.ContactDetails,
                        EducationDetails=model.EducationDetails,
                        Id=model.Id,
                        Userid= userid
                    };
                    try
                    {
                        db.CH_ParticipantsAbout.Add(data);
                        db.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    return await Task.FromResult(new GuidResult(new Guid()));
                }

                else
                {
                    var data1 = db.CH_ParticipantsAbout.Where(x => x.Userid == model.Userid).FirstOrDefault();
                    if (model.BasicDetails != null)
                    {
                        data1.BasicDetails = model.BasicDetails;
                    }
                    if (model.ContactDetails != null)
                    {
                        data1.ContactDetails = model.ContactDetails;
                    }
                    if (model.EducationDetails != null)
                    {
                        data1.EducationDetails = model.EducationDetails;
                    }
                
                    
                    try
                    {
                        db.Entry(data1).State = EntityState.Modified;

                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                    return await Task.FromResult(new GuidResult((model.Id)));
                }

            }

        }

        public async Task<List<ParticipantRegistrationDTO>> GetParticipantsdetails(string sessionToken, Guid Eventid)
        {


            using (var db = new ConquerorHubEntities1())
            {
                var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                try
                {
                    var result = (from details in db.CH_ParticipantRegistration
                                  where details.ParticipantId == userId && details.EventId == Eventid


                                  select new ParticipantRegistrationDTO()
                                  {
                                      Id = details.Id,
                                      Name = details.Name,
                                      Modeofcompitetion = (modeofcompetationDTO)details.Modeofcompitetion,
                                      Qualification = details.Qualification,
                                      DateOfBirthh = details.DateOfBirthh,
                                      About_Self = details.About_Self,
                                      CollegeorSchool = details.CollegeorSchool,
                                      ContactNumber = details.ContactNumber,
                                      EventId = details.EventId,
                                      OrganizerId = details.OrganizerId,
                                      ContentType=details.ContentType,
                                      Data=details.Data,
                                      FileName=details.FileName,
                                      VideoId=details.ParticipantsPostId,
                                      ParticipantStatus=details.ParticipantStatus
                                    
                                  



                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting details of participants");
                }
            }

        }
        public async Task<List<ParticipantsAboutDTO>> GetParticipantsAbout(string sessionToken, Guid?Userid)
        {


            using (var db = new ConquerorHubEntities1())
            {
                var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                try
                {
                    var result = (from details in db.CH_ParticipantsAbout
                                  where details.Userid == userId 


                                  select new ParticipantsAboutDTO()
                                  {
                                       BasicDetails= details.BasicDetails,
                        ContactDetails= details.ContactDetails,
                        EducationDetails= details.EducationDetails,
                        Id=details.Id,
                        Userid= details.Userid





                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting participants details");
                }
            }

        }
        public async Task<List<GalleryDTO>> GetParticipantPhotoGallery (string sessionToken, Guid? Userid)
        {


            using (var db = new ConquerorHubEntities1())
            {
                var userId = "";
                if (Userid == null)
                {
                    userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                }
                else
                {
                    userId = Userid.ToString();
                }
                try
                {
                    var result = (from details in db.CH_ParticipantsGallery


                                  select new GalleryDTO()
                                  {
                                      Id=details.Id,
                                      ImageData=details.ImageData,
                                      Caption=details.Caption,
                                      UserId=details.UserId,
                                      PostId=details.PostId,
                                      ContentType=details.ContentType,
                                      DateAndTime=details.DateAndTime
                                      
                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception)
                {
                    throw new Exception("Error getting photo gallery");
                }




            }
        }


        public async Task<GuidResult> SaveParticipantPhotoGallery(string sessionToken, GalleryDTO model)
        {
            using (var db = new ConquerorHubEntities1())
            {
                var data = new CH_ParticipantsGallery()
                {

                    Id = model.Id,
                    ImageData = model.ImageData,
                    Caption = model.Caption,
                    UserId = model.UserId,
                    PostId = model.PostId,
                    ContentType=model.ContentType,
                    DateAndTime=DateTime.UtcNow

                };
                try
                {
                    db.CH_ParticipantsGallery.Add(data);
                    db.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw;
                }
                return await Task.FromResult(new GuidResult(new Guid()));


            }
        }
    }
}
