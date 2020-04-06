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
    public class BasicFunctionalityofEntireAppBL
    {
        private BasicFunctionalityoftheentireAppDAL obj;
        public BasicFunctionalityofEntireAppBL()
        {
            obj = new BasicFunctionalityoftheentireAppDAL();
        }
        public async Task<RequestResult<List<CH_LikesViewModel>>> GetLikeList(string sessionToken)
        {
            try
            {
                var result = await obj.GetLikeList(sessionToken);
                if (result != null)
                {
                    var likeList = new List<CH_LikesViewModel>();
                    RequestResult<List<CH_LikesViewModel>> sponsor;

                    foreach (var item in result)
                    {
                        likeList.Add(new CH_LikesViewModel()
                        {
                            Id = item.Id,
                            DestinationUserId = item.DestinationUserId,
                            SourceUserId = item.SourceUserId,
                            LikeStatus = item.LikeStatus,
                            Imageid = item.Imageid,
                            DateandTime = item.DateandTime


                        });
                    }
                    sponsor = new RequestResult<List<CH_LikesViewModel>>(likeList);
                    return await Task.FromResult(sponsor);
                }
                return await Task.FromResult(new RequestResult<List<CH_LikesViewModel>>(null));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<SubscriptionViewmodel>>> GetSubscribers(string sessionToken)
        {
            try
            {
                var result = await obj.GetSubscribers(sessionToken);
                var likeList = new List<SubscriptionViewmodel>();
                RequestResult<List<SubscriptionViewmodel>> sponsor;

                foreach (var item in result)
                {
                    likeList.Add(new SubscriptionViewmodel()
                    {
                        Id = item.Id,
                        ProfileUserId = item.ProfileUserId,
                        SubscriberUserId = item.SubscriberUserId,
                        SubscriptionStatus = item.SubscriptionStatus,
                        Datetime = item.Datetime

                    });
                }
                sponsor = new RequestResult<List<SubscriptionViewmodel>>(likeList);
                return await Task.FromResult(sponsor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<VotesViewModel>>> GetVotes(string sessionToken)
        {
            try
            {
                BasicFunctionalityoftheentireAppDAL obj = new BasicFunctionalityoftheentireAppDAL();
                var result = await obj.Getvotelist(sessionToken);
                var likeList = new List<VotesViewModel>();
                RequestResult<List<VotesViewModel>> sponsor;

                foreach (var item in result)
                {
                    likeList.Add(new VotesViewModel()
                    {
                        Id = item.Id,
                        userid = item.userid,
                        PostId = item.PostId,
                        VoteStatus = item.VoteStatus,
                        DateTime = item.DateTime
                    });
                }
                sponsor = new RequestResult<List<VotesViewModel>>(likeList);
                return await Task.FromResult(sponsor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<BlockViewModel>> GetBlockUser(string sessionToken,BlockViewModel model)
        {
            try
            {
                BlockDTO blockDto = new BlockDTO();
                blockDto.BlockedUser = model.BlockedUser;
                blockDto.BlockingUser = model.BlockingUser;
                BasicFunctionalityoftheentireAppDAL obj = new BasicFunctionalityoftheentireAppDAL();
                var result = await obj.GetBlockUser(sessionToken,blockDto);
              
                RequestResult<BlockViewModel> sponsor;
                BlockViewModel blockViewModel = new BlockViewModel();
                if (result != null)
                {
                    blockViewModel.BlockedUser = result.BlockedUser;
                    blockViewModel.BlockingUser = result.BlockingUser;
                    blockViewModel.DateTime = result.DateTime;
                    blockViewModel.Status = result.Status;
                }
               
                sponsor = new RequestResult<BlockViewModel>(blockViewModel);
                return await Task.FromResult(sponsor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<CommentViewModel>>> GetComment(string sessionToken, string Postid)
        {
            try
            {
                var result = await obj.GetCommentList(sessionToken, Postid);
                var likeList = new List<CommentViewModel>();
                RequestResult<List<CommentViewModel>> sponsor;

                foreach (var item in result)
                {
                    likeList.Add(new CommentViewModel()
                    {
                        Id = item.Id,
                        PostId = item.PostId,
                        UserId = item.UserId,
                        CommentMessage = item.CommentMessage,
                        CommentedDate = item.CommentedDate,
                        AspNetUser = new AspnetuserViewModel()
                        {
                            UserName = item.AspNetUser.UserName
                        }

                    });
                }
                sponsor = new RequestResult<List<CommentViewModel>>(likeList);
                return await Task.FromResult(sponsor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<SubCommentsViewModel>>> GetSubComment(string sessionToken, string Postid)
        {
            try
            {
                var result = await obj.GetSubCommentList(sessionToken, Postid);
                var likeList = new List<SubCommentsViewModel>();
                RequestResult<List<SubCommentsViewModel>> sponsor;

                foreach (var item in result)
                {
                    likeList.Add(new SubCommentsViewModel()
                    {
                        CommentId = item.CommentId,
                        PostId = item.PostId,
                        UserId = item.UserId,
                        SubCommentmsg = item.SubCommentmsg,
                        SubCommentDatetime = item.SubCommentDatetime,
                        AspNetUser = new AspnetuserViewModel()
                        {
                            UserName = item.AspNetUser.UserName
                        }

                    });
                }
                sponsor = new RequestResult<List<SubCommentsViewModel>>(likeList);
                return await Task.FromResult(sponsor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<List<ShareViewModel>>> GetShareList(string sessionToken)
        {
            try
            {
                var result = await obj.GetShareList(sessionToken);
                var likeList = new List<ShareViewModel>();
                RequestResult<List<ShareViewModel>> sponsor;

                foreach (var item in result)
                {
                    likeList.Add(new ShareViewModel()
                    {
                        Id = item.Id,
                        PostId = item.PostId,
                        DestinationPage = item.DestinationPage,
                        SourcePage = item.SourcePage,
                        ShareCount = item.ShareCount,
                        DateTime = item.DateTime,
                        ContentType = item.ContentType


                    });
                }
                sponsor = new RequestResult<List<ShareViewModel>>(likeList);
                return await Task.FromResult(sponsor);
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
                var result = await obj.GetBlockList(sessionToken);
                var blockList = new List<BlockViewModel>();
                RequestResult<List<BlockViewModel>> block;

                foreach (var item in result)
                {
                    blockList.Add(new BlockViewModel()
                    {
                        Id = item.Id,
                        BlockedUser = item.BlockedUser,
                        BlockingUser = item.BlockingUser,
                        Status = item.Status,
                        DateTime = item.DateTime


                    });
                }
                block = new RequestResult<List<BlockViewModel>>(blockList);
                return await Task.FromResult(block);
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
                var result = await obj.GetMainphotos(sessionToken);
                var likeList = new List<MainPhotosViewModel>();
                RequestResult<List<MainPhotosViewModel>> sponsor;

                foreach (var item in result)
                {
                    likeList.Add(new MainPhotosViewModel()
                    {
                        Id = item.Id,
                        PhotosId = item.PhotosId,
                        BannerPicData = item.BannerPicData,
                        ProfilePicData = item.ProfilePicData,
                        UserId = item.UserId


                    });
                }
                sponsor = new RequestResult<List<MainPhotosViewModel>>(likeList);
                return await Task.FromResult(sponsor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<RequestResult<GuidResult>> SaveLikes(string sessionToken, CH_LikesViewModel model)
        {
            try
            {
                var DalObj = new BasicFunctionalityoftheentireAppDAL();
                // RequestResult<SponsorDTO> rrUserDetails;
                var data = new CH_LikesDTO()
                {
                    Id = model.Id,
                    DestinationUserId = model.DestinationUserId,
                    SourceUserId = model.SourceUserId,
                    LikeStatus = model.LikeStatus,
                    Imageid = model.Imageid

                };

                var result = await DalObj.SaveLikes(sessionToken, data);
                return new RequestResult<GuidResult>(result);
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
                // RequestResult<SponsorDTO> rrUserDetails;
                var data = new SubscriptionDTO()
                {
                    Id = Guid.NewGuid(),
                    SubscriptionStatus = model.SubscriptionStatus,
                    ProfileUserId = model.ProfileUserId,
                    SubscriberUserId = model.SubscriberUserId,

                };

                var result = await obj.SaveSubscribers(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> SaveVotes(string sessionToken, VotesViewModel model)
        {
            try
            {
                // RequestResult<SponsorDTO> rrUserDetails;
                var data = new VotesDTO()
                {
                    Id = Guid.NewGuid(),
                    VoteStatus = model.VoteStatus,
                    PostId = model.PostId,
                    EventId = model.EventId,
                    userid = model.userid
                };

                var result = await obj.SaveVotes(sessionToken, data);
                return new RequestResult<GuidResult>(result);
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
                var data = new CommentDTO()
                {
                    Id = model.Id,
                    PostId = model.PostId,
                    UserId = model.UserId,
                    CommentMessage = model.CommentMessage,
                    CommentedDate = model.CommentedDate,
                };

                var result = await obj.SaveComment(sessionToken, data);
                if (result != null)
                {
                    CommentModel cM = new CommentModel();
                    cM.result = result.result;
                    cM.UserName = result.UserName;
                    cM.CommentId = result.CommentId;
                    cM.CommentDate = result.CommentDate;
                    cM.CommentMsg = result.CommentMsg;
                    return new RequestResult<CommentModel>(cM);
                }
                else
                {
                    return new RequestResult<CommentModel>(new CommentModel() { result = false });
                }

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
                // RequestResult<SponsorDTO> rrUserDetails;
                var data = new SubCommentsDTO()
                {
                    CommentId = model.CommentId,

                    PostId = model.PostId,
                    UserId = model.UserId,
                    SubCommentDatetime = DateTime.UtcNow,
                    SubCommentId = model.SubCommentId,
                    SubCommentmsg = model.SubCommentmsg

                };

                var result = await obj.SaveSubComment(sessionToken, data);
                if (result != null)
                {
                    CommentModel cM = new CommentModel();
                    cM.result = result.result;
                    cM.UserName = result.UserName;
                    cM.CommentId = result.CommentId;
                    cM.CommentDate = result.CommentDate;
                    cM.CommentMsg = result.CommentMsg;
                    return new RequestResult<CommentModel>(cM);
                }
                else
                {
                    return new RequestResult<CommentModel>(new CommentModel() { result = false });
                }
                //return new RequestResult<GuidResult>(result);
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
                // RequestResult<SponsorDTO> rrUserDetails;
                var data = new ShareDTO()
                {
                    Id = Guid.NewGuid(),
                    PostId = model.PostId,
                    DestinationPage = model.DestinationPage,
                    SourcePage = model.SourcePage,
                    ContentType = model.ContentType,
                };

                var result = await obj.SaveShare(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> Savemainphotos(string sessionToken, MainPhotosViewModel model)
        {
            try
            {
                // RequestResult<SponsorDTO> rrUserDetails;
                var data = new MainPhotosDTO()
                {
                    Id = model.Id,
                    PhotosId = model.PhotosId,
                    BannerPicData = model.BannerPicData,
                    ProfilePicData = model.ProfilePicData,
                    UserId = model.UserId

                };

                var result = await obj.Savemainphotos(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> SaveBlockUser(string sessionToken, BlockViewModel model)
        {
            try
            {
                // RequestResult<SponsorDTO> rrUserDetails;
                var data = new BlockDTO()
                {
                    Id = model.Id,
                    BlockedUser=model.BlockedUser,
                    BlockingUser=model.BlockingUser,
                    DateTime=model.DateTime,
                    Status=model.Status

                };

                var result = await obj.SaveBlock(sessionToken, data);
                return new RequestResult<GuidResult>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RequestResult<GuidResult>> DeleteSponsorPost(string sessionToken, Guid? Postid, Guid? Userid)
        {
            try
            {
                var result = await obj.DeleteSponsorPost(sessionToken, Postid, Userid);


                return new RequestResult<GuidResult>(result);
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
                var result = await obj.DeleteHomePost(sessionToken, Postid, Userid);


                return new RequestResult<GuidResult>(result);
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
                var result = await obj.DeleteSharePost(sessionToken, Postid, Userid);


                return new RequestResult<GuidResult>(result);
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
                var result = await obj.DeleteParticipantGalleryPost(sessionToken, Postid, Userid);


                return new RequestResult<GuidResult>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
