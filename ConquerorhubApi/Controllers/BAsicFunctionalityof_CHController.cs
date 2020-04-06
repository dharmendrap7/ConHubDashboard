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
    [RoutePrefix("api/savecommonfunctionality")]
    public class BAsicFunctionalityof_CHController : ApiController
    {
        private BasicFunctionalityofEntireAppService services;
        public BAsicFunctionalityof_CHController()
        {
            services = new BasicFunctionalityofEntireAppService();
        }

            [Route("gettotallikesofthepost")]
            public async Task<RequestResult<List<CH_LikesViewModel>>> GetSponsorDetails(string sessionToken)
            {

            try
            {
                var result = await services.GetLikeList(sessionToken);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
            }
        [Route("gettotalsubscribersperprofile")]
        public async Task<RequestResult<List<SubscriptionViewmodel>>> GetTotalSubscribersperprofile(string sessionToken)
        {

            try
            {
                var result = await services.GetSubscriberslist(sessionToken);

                return result;
            }
            catch(Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [Route("gettotalvotesperpost")]
        public async Task<RequestResult<List<VotesViewModel>>> GetTotalVoteperpost(string sessionToken)
        {

            try
            {
                var result = await services.GetVoterslist(sessionToken);

                return result;
            }
            catch(Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
               
            }
        }
        [Route("getblockusers")]
        public async Task<RequestResult<BlockViewModel>> GetBlockUser(string sessionToken,string blockeduser,string blockingUser)
        {
            BlockViewModel blockViewModel = new BlockViewModel();
            blockViewModel.BlockedUser = blockeduser;
            blockViewModel.BlockingUser = blockingUser;
            try
            {
                var result = await services.GetBlockUser(sessionToken,blockViewModel);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;

            }
        }
        [Route("getpostcomment")]
        public async Task<RequestResult<List<CommentViewModel>>> GetTotalcomment(string sessionToken,string Postid)
        {

            try
            {
                var result = await services.Getcommentlist(sessionToken, Postid);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [Route("getpostSubcomment")]
        public async Task<RequestResult<List<SubCommentsViewModel>>> GetSubcomment(string sessionToken, string Postid)
        {

            try
            {
                var result = await services.GetSubcommentlist(sessionToken, Postid);

                return result;
            }
            catch (Exception ex){
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
            
        }
        [Route("gettotalshare")]
        public async Task<RequestResult<List<ShareViewModel>>> GettotalShare(string sessionToken)
        {

            try
            {
                var result = await services.GetShareList(sessionToken);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }


        [Route("getblockeduser")]
        public async Task<RequestResult<List<BlockViewModel>>> Getblocklist(string sessionToken)
        {

            try
            {
                var result = await services.GetBlockList(sessionToken);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [Route("getmainphotos")]
        public async Task<RequestResult<List<MainPhotosViewModel>>> Getmainphotos(string sessionToken)
        {

            try
            {
                var result = await services.GetMainphotos(sessionToken);

                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [HttpPost]
            [Route("savelikes")]
            public async Task<RequestResult<GuidResult>> SaveLikes(string sessionToken, CH_LikesViewModel model)
            {
            try
            {
                var result = await services.SaveLikes(sessionToken, model);
                return result;
            }
            catch(Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
            }
        [HttpPost]
        [Route("savesubscribers")]
        public async Task<RequestResult<GuidResult>> Savesubscribers(string sessionToken, SubscriptionViewmodel model)
        {
            try
            {
                var result = await services.SaveSubscribers(sessionToken, model);
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [HttpPost]
        [Route("savevote")]
        public async Task<RequestResult<GuidResult>> SaveVote(string sessionToken, VotesViewModel model)
        {
            try
            {
                var result = await services.SaveVotes(sessionToken, model);
                return result;
            }
            catch (Exception ex) {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }

        }
        [HttpPost]
        [Route("savecomment")]
        public async Task<RequestResult<CommentModel>> SaveComment(string sessionToken, CommentViewModel model)
        {
            try
            {
                var result = await services.SaveComment(sessionToken, model);
                return result;
            }
            catch(Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [HttpPost]
        [Route("savesubcomment")]
        public async Task<RequestResult<CommentModel>> SaveSubComment(string sessionToken, SubCommentsViewModel model)
        {
            try
            {
                var result = await services.SaveSubComment(sessionToken, model);
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [HttpPost]
        [Route("saveshare")]
        public async Task<RequestResult<GuidResult>> SaveShare(string sessionToken, ShareViewModel model)
        {
            try
            {
                var result = await services.SaveShare(sessionToken, model);
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [HttpPost]
        [Route("savemainphotos")]
        public async Task<RequestResult<GuidResult>> SaveMainPhotoshare(string sessionToken, MainPhotosViewModel model)
        {
            try
            {
                var result = await services.SavemainPhotos(sessionToken, model);
                return result;
            }
            catch(Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }


        [HttpPost]
        [Route("saveblockusers")]
        public async Task<RequestResult<GuidResult>> SaveBlockUsers(string sessionToken, BlockViewModel model)
        {
            try
            {
                var result = await services.Saveblockuser(sessionToken, model);
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [HttpPost]
        [Route("deletesponsorspost")]
        public async Task<RequestResult<GuidResult>> DeleteSponsorPost(string sessionToken, Guid? postid,Guid?Userid)
        {
            try
            {
                var result = await services.DeleteSponsorPost(sessionToken, postid, Userid);
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [HttpPost]
        [Route("deletehomepost")]
        public async Task<RequestResult<GuidResult>> DeleteHomePost(string sessionToken, Guid? postid, Guid? Userid)
        {
            try
            {
                var result = await services.DeleteHomePost(sessionToken, postid, Userid);
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [HttpPost]
        [Route("deletesharepost")]
        public async Task<RequestResult<GuidResult>> DeleteSharePost(string sessionToken, Guid? postid, Guid? Userid)
        {
            try
            {
                var result = await services.DeleteSharePost(sessionToken, postid, Userid);
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.SendErrorToText(ex);
                throw ex;
            }
        }
        [HttpPost]
        [Route("deleteparticipantsgallerypost")]
        public async Task<RequestResult<GuidResult>> DeleteParticipantGalleryPost(string sessionToken, Guid? postid, Guid? Userid)
        {
            try
            {
                var result = await services.DeleteParticipantGalleryPost(sessionToken, postid, Userid);
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

