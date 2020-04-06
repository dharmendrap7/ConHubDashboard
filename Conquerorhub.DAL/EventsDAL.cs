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
    public class EventsDAL
    {
        public async Task<GuidResult> SaveORegisteredAboutEvent(string sessionToken, OrganizerRegisterAbouteventDTO model)
        {

            CH_EventRegistrationFromOrganizer data = null;
            using (var db = new ConquerorHubEntities1())
            {
               
                    data = new CH_EventRegistrationFromOrganizer()
                    {
                        EventId = model.EventId,
                        OrganizerId = model.OrganizerId,
                        NameofOrganizer = model.NameofOrganizer,
                        EventName = model.EventName,
                        TypeOfEvent =(int) model.TypeOfEvent,
                        SubTypeOfEvent = model.SubTypeOfEvent,
                        EventStatus=1,
                        modeofevent=(int)model.modeofevent,
                        ImageorVideoforEvent=(int)model.ImageorVideo,
                        Eventfee=model.Eventfee,
                        PaymentStatus=model.PaymentStatus

                        

                    };
                    try
                    {
                        db.CH_EventRegistrationFromOrganizer.Add(data);

                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    return await Task.FromResult(new GuidResult(model.EventId));
                
               
                

            }
        }
        public async Task<GuidResult> SaveOTP(string sessionToken, OtpVerificationDTO model)
        {

            OTP_VerificationTable data = null;
            using (var db = new ConquerorHubEntities1())
            {

                data = new OTP_VerificationTable()
                {
                    EventId = model.EventId,
                    Id = Guid.NewGuid(),
                    OTP=model.OTP,
                    UserId=model.UserId,       
                    

                };
                try
                {
                    db.OTP_VerificationTable.Add(data);

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
                return await Task.FromResult(new GuidResult((Guid)model.EventId));




            }
        }
        public async Task<GuidResult> UpdateParticipantStatus(string sessionToken,ParticipantRegistrationDTO model)
        {

          
            using (var db = new ConquerorHubEntities1())
            {
                var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                var data = db.CH_ParticipantRegistration.Where(x => x.OrganizerId ==model.OrganizerId && x.EventId ==model.EventId).FirstOrDefault();
               
               
                    data.ParticipantStatus = model.ParticipantStatus;
                

                try
                {
                    db.Entry(data).State = EntityState.Modified;


                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
                return await Task.FromResult(new GuidResult(Guid.NewGuid()));
            }
        }
        public async Task<GuidResult> DeleteOTp(string sessionToken, OtpVerificationDTO model)
        {

            int data;
            using (var db = new ConquerorHubEntities1())
            {

                data = (int)db.OTP_VerificationTable.Where(x => x.EventId == model.EventId && x.UserId == model.UserId).Select(x => x.OTP).FirstOrDefault();
                var result = db.OTP_VerificationTable.Where(x => x.EventId == model.EventId && x.UserId == model.UserId).FirstOrDefault(x => x.OTP == model.OTP);
                if (data == model.OTP)
                {
                    try
                    {
                       

                        db.OTP_VerificationTable.Remove(result);

                        db.SaveChanges();
                    }

                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                    return await Task.FromResult(new GuidResult((Guid)model.EventId));




                
            }
        }

        //public async Task<List<OngoingEventsDTO>> GetOngoingEventList(string sessionToken,Guid Eventid)
        //{
        //    using (var db = new ConquerorHubEntities1())
        //    {

        //        var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
        //        try
        //        {
        //            var result = (from details in db.CH_Ongoingevent where details.Eventid==Eventid select new OngoingEventsDTO()
        //            {
        //                UserId = details.UserId,
        //                ContentType = db.CH_Ongoingevent.FirstOrDefault(a=>a.ContentType=="video / mp4").ContentType,
        //                Data = details.Data,
        //                Eventid = details.Eventid,
        //                EventStatus = details.EventStatus,
        //                Id = details.Id,
        //                ParticipantStatus = details.ParticipantStatus,
        //            }).ToList();
        //            return await Task.FromResult(result.ToList());
        //        }
        //        catch (Exception)
        //        {
        //            throw new Exception("Error getting sponsors");
        //        }
        //    };
        //        }
        public async Task<List<OtpVerificationDTO>> Getotpforverification(string sessionToken)
        {
            using (var db = new ConquerorHubEntities1())
            {

                var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                try
                {
                    var result = (from details in db.OTP_VerificationTable
                                  select new OtpVerificationDTO()
                                  {
                                     Id=details.Id,
                                     UserId=details.UserId,
                                     OTP=details.OTP,
                                     EventId=details.EventId
                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception)
                {
                    throw new Exception("Error while getting otp");
                }
            };
        }
        public async Task<List<SubTypeEventDTO>> GetSUbTypeofEvents(string sessionToken)
        {
            List<SubTypeEventDTO> subEvents = new List<SubTypeEventDTO>();
         
            using (var db = new ConquerorHubEntities1())
            {
             subEvents=db.CH_EventSubType.Select(x => new SubTypeEventDTO() { Id = x.Id, EventSubType = x.EventSubType, EventReferenceId = x.EventReferenceId }).ToList();
               
            }
            return await Task.FromResult(subEvents);
        }

        public async Task<List<OrganizerRegisterAbouteventDTO>> GetOrganizerAboutus(string sessionToken,Guid? Userid)
        {
            using (var db = new ConquerorHubEntities1())
            {
                var userId = "";
                if (Userid != null) { userId = Userid.ToString(); }
                else
                { userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId; }

               
                try
                {
                    var result = (from details in db.CH_EventRegistrationFromOrganizer
                                  where details.OrganizerId == userId 

                                  select new OrganizerRegisterAbouteventDTO()
                                  {
                                    NameofOrganizer=details.NameofOrganizer,
                                      EventName=details.EventName,
                                      modeofevent=(ModeofEvent)details.modeofevent,
                                      SubTypeOfEvent=details.SubTypeOfEvent,
                                      TypeOfEvent=(TypeofEvent)details.TypeOfEvent,
                                      EventId=details.EventId,
                                      EventStatus=details.EventStatus,
                                      ImageorVideo=(ExpectingVideoorImage)details.ImageorVideoforEvent,
                                      Eventfee=details.Eventfee,
                                      PaymentStatus=details.PaymentStatus


                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting sponsors");
                }
            }

        }
        





        public async Task<GuidResult> SaveORegisteredAboutParticipant(string sessionToken, OrganizerRegisterAboutparticipantDTO model)
        {

            CH_EventRegistrationFromOrganizer data = null;
            using (var db = new ConquerorHubEntities1())
            {
                var user = db.CH_EventRegistrationFromOrganizer.Where(x => x.OrganizerId == model.OrganizerId && x.EventId==model.EventId).Count();
               

                if (user ==1)
                {
                    CH_EventRegistrationFromOrganizer datatupdate = db.CH_EventRegistrationFromOrganizer.Where(x => x.OrganizerId == model.OrganizerId && x.EventId == model.EventId).FirstOrDefault();
                    datatupdate.StreamOfParticipants =(int) model.StreamOfParticipants;
                    datatupdate.AgeGroup = (int)model.AgeGroup;
                    datatupdate.numofParticipantsinteam = (int)model.numofParticipantsinteam;
                    datatupdate.MaxnumofTeam = (int)model.MaxnumofTeam;

                    try
                    {
                        db.Entry(datatupdate).State = EntityState.Modified;
                   
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                }
                return await Task.FromResult(new GuidResult(model.EventId));

            }
        }
        public async Task<List<OrganizerRegisterAboutparticipantDTO>> GetORegisteredAboutParticipant(string sessionToken,Guid? Userid)
        {
            using (var db = new ConquerorHubEntities1())
            {

                var userId = "";
                if (Userid != null) { userId = Userid.ToString(); }
                else
                { userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId; }

                var data = from details in db.CH_EventRegistrationFromOrganizer
                           where details.OrganizerId == userId
                           select details;
                
                    try
                    {
                        var result = (from details in db.CH_EventRegistrationFromOrganizer
                                      where details.OrganizerId == userId

                                      select new OrganizerRegisterAboutparticipantDTO()
                                      {
                                          
                                          StreamOfParticipants = (streamofparticipants)(details.StreamOfParticipants==null?0:details.StreamOfParticipants),
                                          AgeGroup = (Agegroup)(details.AgeGroup == null ? 0 : details.AgeGroup),
                                          MaxnumofTeam = (Numberofteam)(details.MaxnumofTeam == null ? 0 : details.MaxnumofTeam),
                                          numofParticipantsinteam = (teamsize)(details.numofParticipantsinteam == null ? 0 : details.numofParticipantsinteam),
                                          EventId = details.EventId,
                                          EventStatus = details.EventStatus


                                      }).ToList();
                        return await Task.FromResult(result.ToList());
                    }
                    
                catch (Exception ex)
                {
                    throw new Exception("Error getting details about events");
                }
            }

        }
        public async Task<List<OrganizerRegisterAbouteventDTO>> GetAllEvents(string sessionToken)
        {
            using (var db = new ConquerorHubEntities1())
            {

              
               
                var data = from details in db.CH_EventRegistrationFromOrganizer
                          
                           select details;

                try
                {
                    var result = (from details in db.CH_EventRegistrationFromOrganizer
                                  

                                  select new OrganizerRegisterAbouteventDTO()
                                  {

                                      NameofOrganizer = details.NameofOrganizer,
                                      EventName = details.EventName,
                                      modeofevent = (ModeofEvent)details.modeofevent,
                                      SubTypeOfEvent = details.SubTypeOfEvent,
                                      TypeOfEvent = (TypeofEvent)details.TypeOfEvent,
                                      EventId = details.EventId,
                                      EventStatus = details.EventStatus,
                                      ImageorVideo = (ExpectingVideoorImage)details.ImageorVideoforEvent,
                                      Eventfee = details.Eventfee,
                                      PaymentStatus = details.PaymentStatus,
                                      OrganizerId=details.OrganizerId


                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }

                catch (Exception ex)
                {
                    throw new Exception("Error getting details about events");
                }
            }

        }

        public async Task<GuidResult> SaveImportantDates(string sessionToken, ImportantDatesofEventDTO model)
        {

            CH_EventRegistrationFromOrganizer data = null;
            using (var db = new ConquerorHubEntities1())
            {
                var user = db.CH_EventRegistrationFromOrganizer.Where(x => x.OrganizerId == model.OrganizerId&& x.EventId==model.EventId).Count();


                if (user == 1)
                {
                    CH_EventRegistrationFromOrganizer datatupdate = db.CH_EventRegistrationFromOrganizer.Where(x => x.OrganizerId == model.OrganizerId && x.EventId == model.EventId).FirstOrDefault();
                    datatupdate.StartofEventRegistration = model.StartofEventRegistration;
                    datatupdate.EndOfEventRegistration = model.EndOfEventRegistration;
                    datatupdate.StartofVideoUpload = model.StartofVideoUpload;
                    datatupdate.EndOfVideoUpload = model.EndOfVideoUpload;
                    datatupdate.ResultDate = model.ResultDate;
                    datatupdate.StartOfValuationfromvoters = model.StartOfValuationfromvoters;
                    datatupdate.EndofValuationFromVoters = model.EndofValuationFromVoters;

                    try
                    {
                        db.Entry(datatupdate).State = EntityState.Modified;

                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                }
                return await Task.FromResult(new GuidResult(model.EventId));

            }
        }
        public async Task<List<ImportantDatesofEventDTO>> GetImportantDates(string sessionToken,Guid? Userid)
        {
            using (var db = new ConquerorHubEntities1())
            {

                var userId = "";
                if (Userid != null) { userId = Userid.ToString(); }
                else
                { userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId; }

                try
                {
                    var result = (from details in db.CH_EventRegistrationFromOrganizer
                                  where details.OrganizerId == userId

                                  select new ImportantDatesofEventDTO()
                                  {
                                     
                                      EventId = details.EventId,
                                      StartofEventRegistration=details.StartofEventRegistration,
                                      EndOfEventRegistration=details.EndOfEventRegistration,
                                      StartOfValuationfromvoters=details.StartOfValuationfromvoters,
                                      EndofValuationFromVoters=details.EndofValuationFromVoters,
                                      ResultDate=details.ResultDate,
                                      StartofVideoUpload=details.StartofVideoUpload,
                                      EndOfVideoUpload=details.EndOfVideoUpload,
                                      EventStatus=details.EventStatus


                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception)
                {
                    throw new Exception("Error while getting important dates");
                }
            }

        }
        public async Task<GuidResult> SaveAwardsandRewards(string sessionToken, EventAwardandRewardDTO model)
        {

            CH_EventRegistrationFromOrganizer data = null;
            using (var db = new ConquerorHubEntities1())
            {
                var user = db.CH_EventRegistrationFromOrganizer.Where(x => x.OrganizerId == model.OrganizerId && x.EventId == model.EventId).Count();


                if (user == 1)
                {
                    CH_EventRegistrationFromOrganizer datatupdate = db.CH_EventRegistrationFromOrganizer.Where(x => x.OrganizerId == model.OrganizerId && x.EventId == model.EventId).FirstOrDefault();
                    datatupdate.FirstPrize = model.FirstPrize;
                    datatupdate.SecondPrize = model.SecondPrize;
                    datatupdate.ThirdPrize = model.ThirdPrize;


                    try
                    {
                        db.Entry(datatupdate).State = EntityState.Modified;

                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                }
                return await Task.FromResult(new GuidResult(model.EventId));

            }
        }
        public async Task<List<EventAwardandRewardDTO>> GetAwardandReward(string sessionToken,Guid? Userid)
        {
            using (var db = new ConquerorHubEntities1())
            {

                var userId = "";
                if (Userid != null) { userId = Userid.ToString(); }
                else
                { userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId; }

                try
                {
                    var result = (from details in db.CH_EventRegistrationFromOrganizer
                                  where details.OrganizerId == userId

                                  select new EventAwardandRewardDTO()
                                  {
                                      EventId=details.EventId,
                                      FirstPrize=details.FirstPrize,
                                      SecondPrize=details.SecondPrize,
                                      ThirdPrize=details.ThirdPrize,
                                      EventStatus=details.EventStatus
                                     


                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception)
                {
                    throw new Exception("Error getting award details");
                }
            }

        }

       
    }
}
