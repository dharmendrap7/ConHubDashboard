using Conquerorhub.DAL;
using Conquerorhub.DAL.DTO;
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
  public  class BasicFunctionalityofEntireAppService
    {
        private readonly BasicFunctionalityofEntireAppBL _repository;

        public BasicFunctionalityofEntireAppService()
        {
            _repository = new BasicFunctionalityofEntireAppBL();
        }
        public async Task<RequestResult<List<CH_LikesViewModel>>> GetLikeList(string sessionToken)
        {
            try
            {

                return await _repository.GetLikeList(sessionToken);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public async Task<RequestResult<List<SubscriptionViewmodel>>> GetSubscriberslist(string sessionToken)
        {

            try {
                return await _repository.GetSubscribers(sessionToken);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            }



        public async Task<RequestResult<BlockViewModel>> GetBlockUser(string sessionToken,BlockViewModel model)
        {

            try
            {
                return await _repository.GetBlockUser(sessionToken,model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<VotesViewModel>>> GetVoterslist(string sessionToken)
        {

            try{
                return await _repository.GetVotes(sessionToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<CommentViewModel>>> Getcommentlist(string sessionToken,string Postid)
        {
            try
            {
                return await _repository.GetComment(sessionToken, Postid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<SubCommentsViewModel>>> GetSubcommentlist(string sessionToken, string Postid)
        {
            try
            {

                return await _repository.GetSubComment(sessionToken, Postid);
            } catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<ShareViewModel>>> GetShareList(string sessionToken)
        {
            try
            {

                return await _repository.GetShareList(sessionToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<BlockViewModel>>> GetBlockList(string sessionToken)
        {
            try
            {

                return await _repository.GetBlockList(sessionToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<MainPhotosViewModel>>> GetMainphotos(string sessionToken)
        {

            try
            {
                return await _repository.GetMainphotos(sessionToken);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RequestResult<GuidResult>> SaveLikes(string sessionToken, CH_LikesViewModel model)
        {
            try
            {
                var returnData = await _repository.SaveLikes(sessionToken, model);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
                       
        }
        public async Task<RequestResult<GuidResult>> SaveSubscribers(string sessionToken, SubscriptionViewmodel model)
        {
            try
            {
                var returnData = await _repository.SaveSubscribers(sessionToken, model);
                return returnData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> SaveVotes(string sessionToken, VotesViewModel model)
        {

            try
            {
                var returnData = await _repository.SaveVotes(sessionToken, model);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<CommentModel>> SaveComment(string sessionToken, CommentViewModel model)
        {
            try
            {
                var returnData = await _repository.SaveComment(sessionToken, model);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<CommentModel>> SaveSubComment(string sessionToken, SubCommentsViewModel model)
        {
            try
            {
                var returnData = await _repository.SaveSubComment(sessionToken, model);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> SaveShare(string sessionToken, ShareViewModel model)
        {
            try
            {
                var returnData = await _repository.SaveShare(sessionToken, model);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> SavemainPhotos(string sessionToken, MainPhotosViewModel model)
        {
            try
            {
                var returnData = await _repository.Savemainphotos(sessionToken, model);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> Saveblockuser(string sessionToken, BlockViewModel model)
        {
            try
            {
                var returnData = await _repository.SaveBlockUser(sessionToken, model);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> DeleteSponsorPost(string sessionToken,Guid?Postid,Guid?Userid)
        {
            try
            {
                var returnData = await _repository.DeleteSponsorPost(sessionToken, Postid, Userid);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> DeleteHomePost(string sessionToken, Guid? Postid, Guid? Userid)
        {
            try
            {
                var returnData = await _repository.DeleteHomePost(sessionToken, Postid, Userid);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> DeleteSharePost(string sessionToken, Guid? Postid, Guid? Userid)
        {
            try
            {
                var returnData = await _repository.DeleteSharePost(sessionToken, Postid, Userid);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> DeleteParticipantGalleryPost(string sessionToken, Guid? Postid, Guid? Userid)
        {
            try
            {
                var returnData = await _repository.DeleteParticipantGalleryPost(sessionToken, Postid, Userid);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
