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
    public class EventsBL
    {
        private EventsDAL obj;
       public EventsBL()
        {
            obj = new EventsDAL();
        }
        public async Task<RequestResult<GuidResult>> SaveORegisteredAboutEvent(string sessionToken, OrganizerRegisterAbouteventViewModel model)
        {
            try
            {
                var data = new OrganizerRegisterAbouteventDTO()
                {
                    EventId = model.EventId,
                    OrganizerId = model.OrganizerId,
                    NameofOrganizer = model.NameofOrganizer,
                    EventName = model.EventName,
                    TypeOfEvent = (TypeofEvent)model.TypeOfEvent,
                    SubTypeOfEvent = model.SubTypeOfEvent,
                    modeofevent = (ModeofEvent)model.modeofevent,
                    ImageorVideo = (ExpectingVideoorImage)model.ImageorVideo,
                    Eventfee=model.Eventfee,
                    PaymentStatus=model.PaymentStatus

                };
                var result = await obj.SaveORegisteredAboutEvent(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> SaveOTP(string sessionToken, OTPVerificationViewModel model)
        {
            try
            {
                var data = new OtpVerificationDTO()
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    EventId = model.EventId,
                    OTP = model.OTP
                };
                var result = await obj.SaveOTP(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> UpdateParticipantStatus(string sessionToken,ParticipationRegistrationViewModel model)
        {
            try
            {
                ParticipantRegistrationDTO obj1 = new ParticipantRegistrationDTO()
                {
                    ParticipantStatus = model.ParticipantStatus,
                    EventId = model.EventId,
                    OrganizerId = model.OrganizerId
                };

                var result = await obj.UpdateParticipantStatus(sessionToken, obj1);
                return new RequestResult<GuidResult>(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> Deleteotp(string sessionToken, OTPVerificationViewModel model)
        {
            try
            {
                var data = new OtpVerificationDTO()
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    EventId = model.EventId,
                    OTP = model.OTP
                };
                var result = await obj.DeleteOTp(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //public async Task<RequestResult<List<OngoingEventViewmodel>>> GetOngoingeventlist(string sessionToken,Guid Eventid)
        //{
        //    EventsDAL obj = new EventsDAL();
        //    var result = await obj.GetOngoingEventList(sessionToken,Eventid);
        //    var ongoingEvent = new List<OngoingEventViewmodel>();
        //    RequestResult<List<OngoingEventViewmodel>> sponsor;

        //    foreach (var item in result)
        //    {
        //        ongoingEvent.Add(new OngoingEventViewmodel()
        //        {  Id=item.Id,
        //            UserId=item.UserId,
        //            Eventid=item.Eventid,
        //            EventStatus=item.EventStatus,
        //            ContentType=item.ContentType,
        //            Data=item.Data,
        //            ParticipantStatus=item.ParticipantStatus,
                    

                  
        //        });
        //    }
        //    sponsor = new RequestResult<List<OngoingEventViewmodel>>(ongoingEvent);
        //    return await Task.FromResult(sponsor);


        //}
        public async Task<RequestResult<List<OTPVerificationViewModel>>> GetOTPVerification(string sessionToken)
        {
            try
            {

                var result = await obj.Getotpforverification(sessionToken);
                var OtpList = new List<OTPVerificationViewModel>();
                RequestResult<List<OTPVerificationViewModel>> sponsor;

                foreach (var item in result)
                {
                    OtpList.Add(new OTPVerificationViewModel()
                    {
                        Id = item.Id,
                        UserId = item.UserId,
                        OTP = item.OTP,
                        EventId = item.EventId
                    });
                }
                sponsor = new RequestResult<List<OTPVerificationViewModel>>(OtpList);
                return await Task.FromResult(sponsor);
            }
            catch(Exception ex)
            {
                throw ex;
            }


        }

        public async Task<RequestResult<List<OrganizerRegisterAbouteventViewModel>>> GetORegisteredAboutEvent(string sessionToken,Guid? Userid)
        {
            try
            {
                var result = await obj.GetOrganizerAboutus(sessionToken, Userid);
                var organizerAboutus = new List<OrganizerRegisterAbouteventViewModel>();
                RequestResult<List<OrganizerRegisterAbouteventViewModel>> sponsor;

                foreach (var item in result)
                {
                    organizerAboutus.Add(new OrganizerRegisterAbouteventViewModel()
                    {
                        NameofOrganizer = item.NameofOrganizer,
                        TypeOfEvent = (TypeofEvent1)item.TypeOfEvent,
                        SubTypeOfEvent = item.SubTypeOfEvent,
                        modeofevent = (ModeofEvent1)item.modeofevent,
                        EventName = item.EventName,
                        EventId = item.EventId,
                        EventStatus = item.EventStatus,
                        ImageorVideo = (ExpectingVideoorImage1)item.ImageorVideo,
                        Eventfee=item.Eventfee,
                        PaymentStatus=item.PaymentStatus

                    });
                }
                sponsor = new RequestResult<List<OrganizerRegisterAbouteventViewModel>>(organizerAboutus);
                return await Task.FromResult(sponsor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RequestResult<List<OrganizerRegisterAbouteventViewModel>>> GetAllEvents(string sessionToken)
        {
            try
            {
                var result = await obj.GetAllEvents(sessionToken);
                var organizerAboutus = new List<OrganizerRegisterAbouteventViewModel>();
                RequestResult<List<OrganizerRegisterAbouteventViewModel>> sponsor;

                foreach (var item in result)
                {
                    organizerAboutus.Add(new OrganizerRegisterAbouteventViewModel()
                    {
                        NameofOrganizer = item.NameofOrganizer,
                        TypeOfEvent = (TypeofEvent1)item.TypeOfEvent,
                        SubTypeOfEvent = item.SubTypeOfEvent,
                        modeofevent = (ModeofEvent1)item.modeofevent,
                        EventName = item.EventName,
                        EventId = item.EventId,
                        EventStatus = item.EventStatus,
                        ImageorVideo = (ExpectingVideoorImage1)item.ImageorVideo,
                        Eventfee = item.Eventfee,
                        PaymentStatus = item.PaymentStatus,
                        OrganizerId=item.OrganizerId

                    });
                }
                sponsor = new RequestResult<List<OrganizerRegisterAbouteventViewModel>>(organizerAboutus);
                return await Task.FromResult(sponsor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<RequestResult<List<EventSubtypeViewModel>>> GetEventSubType(string sessionToken)
        {
            try
            {
                var result = await obj.GetSUbTypeofEvents(sessionToken);
                var eventSubtype = new List<EventSubtypeViewModel>();
                RequestResult<List<EventSubtypeViewModel>> subTypeEvent;
                foreach (var item in result)
                {

                    eventSubtype.Add(new EventSubtypeViewModel()
                    {
                        Id = item.Id,
                        EventReferenceId = item.EventReferenceId,
                        EventSubType = item.EventSubType
                    });
                }
                subTypeEvent = new RequestResult<List<EventSubtypeViewModel>>(eventSubtype);
                return await Task.FromResult(subTypeEvent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> SaveORegisteredAboutParticipant(string sessionToken, OrganizerRegisterAboutparticipantViewModel model)
        {
            try
            {
                var data = new OrganizerRegisterAboutparticipantDTO()
                {
                    OrganizerId = model.OrganizerId,
                    EventId = model.EventId,
                    StreamOfParticipants = (streamofparticipants)model.StreamOfParticipants,
                    AgeGroup = (Agegroup)model.AgeGroup,
                    MaxnumofTeam = (Numberofteam)model.MaxnumofTeam,
                    numofParticipantsinteam = (teamsize)model.numofParticipantsinteam,
                   
                    


                };
                var result = await obj.SaveORegisteredAboutParticipant(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<OrganizerRegisterAboutparticipantViewModel>>> GetORegisteredAboutParticipant(string sessionToken,Guid? Userid)
        {
            try
            {
                var result = await obj.GetORegisteredAboutParticipant(sessionToken, Userid);
                var aboutParticipants = new List<OrganizerRegisterAboutparticipantViewModel>();
                RequestResult<List<OrganizerRegisterAboutparticipantViewModel>> sponsor;

                foreach (var item in result)
                {
                    aboutParticipants.Add(new OrganizerRegisterAboutparticipantViewModel()
                    {
                        StreamOfParticipants = (streamofparticipants1)item.StreamOfParticipants,
                        AgeGroup = (Agegroup1)item.AgeGroup,
                        EventId = item.EventId,
                        MaxnumofTeam = (Numberofteam1)item.MaxnumofTeam,
                        numofParticipantsinteam = (teamsize1)item.numofParticipantsinteam,
                        EventStatus = item.EventStatus,



                    });
                }
                sponsor = new RequestResult<List<OrganizerRegisterAboutparticipantViewModel>>(aboutParticipants);
                return await Task.FromResult(sponsor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RequestResult<GuidResult>> SaveImportantDates(string sessionToken, ImportantDatesofEventViewModel model)
        {
            try
            {
                var data = new ImportantDatesofEventDTO()
                {
                    OrganizerId = model.OrganizerId,
                    EventId = model.EventId,
                    StartofEventRegistration = model.StartofEventRegistration,
                    EndOfEventRegistration = model.EndOfEventRegistration,
                    StartOfValuationfromvoters = model.StartOfValuationfromvoters,
                    EndofValuationFromVoters = model.EndofValuationFromVoters,
                    StartofVideoUpload = model.StartofVideoUpload,
                    EndOfVideoUpload = model.EndOfVideoUpload,
                    ResultDate = model.ResultDate


                };
                var result = await obj.SaveImportantDates(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RequestResult<List<ImportantDatesofEventViewModel>>> GetImportantDates(string sessionToken, Guid? Userid)
        {
            try {
                var result = await obj.GetImportantDates(sessionToken, Userid);
                var importantDates = new List<ImportantDatesofEventViewModel>();
                RequestResult<List<ImportantDatesofEventViewModel>> sponsor;

                foreach (var item in result)
                {
                    importantDates.Add(new ImportantDatesofEventViewModel()
                    {
                        StartofEventRegistration = item.StartofEventRegistration,
                        StartOfValuationfromvoters = item.StartOfValuationfromvoters,
                        StartofVideoUpload = item.StartofVideoUpload,
                        EndOfEventRegistration = item.EndOfEventRegistration,
                        EndofValuationFromVoters = item.EndofValuationFromVoters,
                        EndOfVideoUpload = item.EndOfVideoUpload,
                        ResultDate = item.ResultDate,
                        EventId = item.EventId,
                        EventStatus = item.EventStatus


                    });
                }
                sponsor = new RequestResult<List<ImportantDatesofEventViewModel>>(importantDates);
                return await Task.FromResult(sponsor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            }




        public async Task<RequestResult<GuidResult>> SaveAwardsandRewards(string sessionToken, EventAwardandRewardViewModel model)
        {
            try
            {
                var data = new EventAwardandRewardDTO()
                {
                    EventId = model.EventId,
                    OrganizerId = model.OrganizerId,
                    FirstPrize = model.FirstPrize,
                    SecondPrize = model.SecondPrize,
                    ThirdPrize = model.ThirdPrize

                };
                var result = await obj.SaveAwardsandRewards(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<EventAwardandRewardViewModel>>> GetAwardandReward(string sessionToken, Guid? Userid)
        {
            try {
                var result = await obj.GetAwardandReward(sessionToken, Userid);
                var importantDates = new List<EventAwardandRewardViewModel>();
                RequestResult<List<EventAwardandRewardViewModel>> sponsor;

                foreach (var item in result)
                {
                    importantDates.Add(new EventAwardandRewardViewModel()
                    {
                        FirstPrize = item.FirstPrize,
                        SecondPrize = item.SecondPrize,
                        ThirdPrize = item.ThirdPrize,
                        EventId = item.EventId,
                        EventStatus = item.EventStatus


                    });
                }
                sponsor = new RequestResult<List<EventAwardandRewardViewModel>>(importantDates);
                return await Task.FromResult(sponsor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            }
    }
}
