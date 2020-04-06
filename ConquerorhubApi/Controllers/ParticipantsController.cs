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
    [RoutePrefix("api/participants")]
    public class ParticipantsController : ApiController
    {
        private ParticipantsServices services;
        public ParticipantsController()
        {
             services = new ParticipantsServices();
        }
        [HttpPost]
        [Route("saveparticipantsphotogallery")]
        public async Task<RequestResult<GuidResult>> SaveUserSecurity(string sessionToken, GalleryViewModel model)
        {

            try
            {
                var result = await services.SaveParticipantPhotoGAllery(sessionToken, model);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;

            }
        }
        [Route("getparticipantphotogallery")]
        public async Task<RequestResult<List<GalleryViewModel>>> GetParticipantPhotoGallery(string sessionToken, Guid? userid)
        {

            try
            {
                var result = await services.GetParticipantPhotoGallery(sessionToken, userid);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
            [Route("saveparticipantsregistration")]
            public async Task<RequestResult<GuidResult>> SaveParticipantsdetails(string sessionToken, ParticipationRegistrationViewModel model)
            {

            try
            {
                var result = await services.SaveParticipantsdetails(sessionToken, model);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;

            }
            }
        [HttpPost]
        [Route("saveparticipantsAbout")]
        public async Task<RequestResult<GuidResult>> SaveParticipantsAbout(string sessionToken, ParticipantsAboutViewModel model)
        {
            try
            {
                var result = await services.SaveParticipantAbout(sessionToken, model);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [Route("getparticipantsregistration")]
            public async Task<RequestResult<List<ParticipationRegistrationViewModel>>> GetParticipantsdetails(string sessionToken, Guid eventId)
            {

            try
            {
                var result = await services.GetParticipantsdetails(sessionToken, eventId);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
            }
        [Route("getparticipantAbout")]
        public async Task<RequestResult<List<ParticipantsAboutViewModel>>> GetParticipantsdetails(string sessionToken, Guid? UserId)
        {

            try
            {
                var result = await services.GetparticipantAbout(sessionToken, UserId);

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

