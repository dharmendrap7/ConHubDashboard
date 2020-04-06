using Conquerorhub.Model;
using Conquerorhub.SDK.BusinessLogic;
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
    [RoutePrefix("api/Events")]
    public class EventsController : ApiController
    {
        Eventservices obj = new Eventservices();
        [HttpPost]
        [Route("saveOregisteredAboutevent")]
        public async Task<RequestResult<GuidResult>> SaveORegisteredAboutEvent(string sessionToken, OrganizerRegisterAbouteventViewModel model)
        {

            try
            {
                var result = await obj.SaveORegisteredAboutEvent(sessionToken, model);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }

        [HttpPost]
        [Route("saveotp")]
        public async Task<RequestResult<GuidResult>> SaveOTp(string sessionToken, OTPVerificationViewModel model)
        {
            try
            {

                var result = await obj.SaveOTP(sessionToken, model);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }

        [HttpPost]
        [Route("UpdateParticipantStatus")]
        public async Task<RequestResult<GuidResult>> UpdateParticipantStatus(string sessionToken, ParticipationRegistrationViewModel model)
        {

            try
            {
                var result = await obj.UpdateParticipantStatus(sessionToken, model);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }

        [HttpPost]
        [Route("deleteotp")]
        public async Task<RequestResult<GuidResult>> DeleteOTP(string sessionToken, OTPVerificationViewModel model)
        {

            try
            {
                var result = await obj.DeleteOTP(sessionToken, model);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }

        [Route("getOregisteredAboutevent")]
        public async Task<RequestResult<List<OrganizerRegisterAbouteventViewModel>>> GetORegisteredAboutEvent(string sessionToken,Guid? Userid)
        {

            try
            {
                var result = await obj.GetORegisteredAboutEvent(sessionToken, Userid);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }

        [Route("getallevents")]
        public async Task<RequestResult<List<OrganizerRegisterAbouteventViewModel>>> GetAllEvents(string sessionToken)
        {

            try
            {
                var result = await obj.GetAllEvents(sessionToken);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }

        [Route("geteventsubtype")]
        public async Task<RequestResult<List<EventSubtypeViewModel>>> Geteventsubtype(string sessionToken)
        {
            try
            {

                var result = await obj.GetEventSubtype(sessionToken);

                return result;
            }
            catch (Exception ex) {
                ErrorHandler.SendErrorToText(ex); throw ex; }
        }
        ////[Route("getOngoingEventList")]
        ////public async Task<RequestResult<List<OngoingEventViewmodel>>> GetOngoingeventList(string sessionToken,Guid Eventid)
        ////{
        ////    var services = new Eventservices();

        ////    var result = await services.GetOngoingEventList(sessionToken,Eventid);

        ////    return result;
        ////}
        [Route("getotplist")]
        public async Task<RequestResult<List<OTPVerificationViewModel>>> Getotplist(string sessionToken)
        {

            try
            {
                var result = await obj.Getotplist(sessionToken);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [HttpPost]
        [Route("SaveOregisteredAboutparticipant")]
        public async Task<RequestResult<GuidResult>> SaveORegisteredAboutParticipant(string sessionToken, OrganizerRegisterAboutparticipantViewModel model)
        {

            try
            {
                var result = await obj.SaveORegisteredAboutParticipant(sessionToken, model);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [Route("getOregisteredAboutparticipant")]
        public async Task<RequestResult<List<OrganizerRegisterAboutparticipantViewModel>>> GetORegisteredAboutParticipant(string sessionToken,Guid? Userid)
        {

            try
            {
                var result = await obj.GetORegisteredAboutParticipant(sessionToken, Userid);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [HttpPost]
        [Route("saveOimportantdates")]
        public async Task<RequestResult<GuidResult>> SaveOImportantDates(string sessionToken, ImportantDatesofEventViewModel model)
        {

            try
            {
                var result = await obj.SaveImportantDates(sessionToken, model);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [Route("getOimportantdates")]
        public async Task<RequestResult<List<ImportantDatesofEventViewModel>>> GetSponsorDetails(string sessionToken,Guid? Userid)
        {

            try
            {
                var result = await obj.GetImportantDates(sessionToken, Userid);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [HttpPost]
        [Route("saveOAwardsandRewards")]
        public async Task<RequestResult<GuidResult>> SaveAwardandReward(string sessionToken, EventAwardandRewardViewModel model)
        {

            try
            {
                var result = await obj.SaveAwardsandRewards(sessionToken, model);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }

        }

        [Route("getOAwardsandRewards")]
        public async Task<RequestResult<List<EventAwardandRewardViewModel>>> GetAwardandReward(string sessionToken,Guid? Userid)
        {

            try
            {
                var result = await obj.GetAwardsandRewards(sessionToken, Userid);

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
