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
    public class Eventservices
    {
        private EventsBL obj;
        public Eventservices()
        {
            obj = new EventsBL();
        }

        public async Task<RequestResult<GuidResult>> SaveORegisteredAboutEvent(string sessionToken, OrganizerRegisterAbouteventViewModel model)
        {
            try
            {
                var returnData = await obj.SaveORegisteredAboutEvent(sessionToken, model);
                return returnData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RequestResult<GuidResult>> SaveOTP(string sessionToken, OTPVerificationViewModel model)
        {
            try
            {
                var returnData = await obj.SaveOTP(sessionToken, model);
                return returnData;
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
                var returnData = await obj.UpdateParticipantStatus(sessionToken, model);
                return returnData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> DeleteOTP(string sessionToken, OTPVerificationViewModel model)
        {
            try {
                var returnData = await obj.Deleteotp(sessionToken, model);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            }

        public async Task<RequestResult<List<OrganizerRegisterAbouteventViewModel>>> GetORegisteredAboutEvent(string sessionToken,Guid? Userid)
        {

            try
            {
                return await obj.GetORegisteredAboutEvent(sessionToken, Userid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<OrganizerRegisterAbouteventViewModel>>> GetAllEvents(string sessionToken)
        {

            try
            {
                return await obj.GetAllEvents(sessionToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<EventSubtypeViewModel>>> GetEventSubtype(string sessionToken)
        {
            try
            {

                return await obj.GetEventSubType(sessionToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public async Task<RequestResult<List<OngoingEventViewmodel>>> GetOngoingEventList(string sessionToken,Guid Eventid)
        //{
        //    var aboutEvent = new EventsBL();

        //    return await aboutEvent.GetOngoingeventlist(sessionToken, Eventid);
        //}
        public async Task<RequestResult<List<OTPVerificationViewModel>>> Getotplist(string sessionToken)
        {
            try
            {

                return await obj.GetOTPVerification(sessionToken);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }




        public async Task<RequestResult<GuidResult>> SaveORegisteredAboutParticipant(string sessionToken, OrganizerRegisterAboutparticipantViewModel model)
        {
            try
            {
                var returnData = await obj.SaveORegisteredAboutParticipant(sessionToken, model);
                return returnData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<OrganizerRegisterAboutparticipantViewModel>>> GetORegisteredAboutParticipant(string sessionToken,Guid? Userid)
        {
            try
            {

                return await obj.GetORegisteredAboutParticipant(sessionToken, Userid);
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
                var returnData = await obj.SaveImportantDates(sessionToken, model);
                return returnData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<ImportantDatesofEventViewModel>>> GetImportantDates(string sessionToken,Guid? Userid)
        {

            try
            {
                return await obj.GetImportantDates(sessionToken, Userid);
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
                var returnData = await obj.SaveAwardsandRewards(sessionToken, model);
                return returnData;
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }

        public async Task<RequestResult<List<EventAwardandRewardViewModel>>> GetAwardsandRewards(string sessionToken,Guid? Userid)
        {

            try
            {
                return await obj.GetAwardandReward(sessionToken, Userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
