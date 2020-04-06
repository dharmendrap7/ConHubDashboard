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
    public class ParticipantsServices
    {
        private ParticipantsBL bldata;
        public ParticipantsServices()
        {
            bldata = new ParticipantsBL();
        }

        public async Task<RequestResult<GuidResult>> SaveParticipantsdetails(string sessionToken, ParticipationRegistrationViewModel model)
        {
            try
            {
                var returnData = await bldata.SaveParticipantsdetails(sessionToken, model);
                return returnData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
                 
        }
       


        public async Task<RequestResult<List<ParticipationRegistrationViewModel>>> GetParticipantsdetails(string sessionToken, Guid Eventid)
        {
            try{

                return await bldata.GetParticipantsdetails(sessionToken, Eventid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<GalleryViewModel>>> GetParticipantPhotoGallery(string sessionToken, Guid? Userid)
        {

            try
            {
                return await bldata.GetParticipantsPhotoGallery(sessionToken, Userid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> SaveParticipantPhotoGAllery(string sessionToken, GalleryViewModel model)
        {
            try
            {
                var returnData = await bldata.SaveParticipantsPhotoGallery(sessionToken, model);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> SaveParticipantAbout(string sessionToken, ParticipantsAboutViewModel model)
        {
            try
            {
                var returnData = await bldata.SaveParticipantAbout(sessionToken, model);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<ParticipantsAboutViewModel>>> GetparticipantAbout(string sessionToken, Guid? Userid)
        {
            try
            {

                return await bldata.GetParticipantsAbout(sessionToken, Userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
