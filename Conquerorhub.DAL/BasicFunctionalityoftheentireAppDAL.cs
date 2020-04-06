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
    public class BasicFunctionalityoftheentireAppDAL
    {

        public async Task<List<CH_LikesDTO>> GetLikeList(string sessionToken)
        {


            using (var db = new ConquerorHubEntities1())
            {
                var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                try
                {
                    if (userId != null)
                    {
                        var result = (from details in db.CH_Likes


                                      select new CH_LikesDTO()
                                      {
                                          Id = details.Id,
                                          LikeStatus = details.LikeStatus,
                                          DestinationUserId = details.DestinationUserId,
                                          SourceUserId = details.SourceUserId,
                                          Imageid = details.Imageid,
                                          DateandTime = details.DateandTime



                                      }).ToList();

                        return await Task.FromResult(result.ToList());
                    }

                    return await Task.FromResult(new List<CH_LikesDTO>() {null });
                }
                catch (Exception)
                {
                    throw new Exception("Error getting like");
                }
            }

        }
        public async Task<List<SubscriptionDTO>> GetSubscribers(string sessionToken)
        {


            using (var db = new ConquerorHubEntities1())
            {
                var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                try
                {
                    var result = (from details in db.CH_SubscriptionTable


                                  select new SubscriptionDTO()
                                  {
                                      Id = details.Id,
                                      ProfileUserId = details.ProfileUserId,
                                      SubscriberUserId = details.SubscriberUserId,
                                      SubscriptionStatus = details.SubscriptionStatus,
                                      Datetime=details.Datetime



                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception)
                {
                    throw new Exception("Error getting sponsors");
                }
            }

        }
        public async Task<List<VotesDTO>> Getvotelist(string sessionToken)
        {


            using (var db = new ConquerorHubEntities1())
            {
                var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                try
                {
                    var result = (from details in db.CH_VoteTable


                                  select new VotesDTO()
                                  {
                                      Id = details.Id,
                                      userid = details.userid,
                                      PostId = details.PostId,
                                      VoteStatus = details.VoteStatus,
                                      DateTime=details.DateTime


                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception)
                {
                    throw new Exception("Error getting vote");
                }
            }

        }
        public async Task<BlockDTO> GetBlockUser(string sessionToken,BlockDTO model)
        {


            using (var db = new ConquerorHubEntities1())
            {       

               try
                {
                    var result = (from details in db.CH_BlockTable where details.BlockedUser==model.BlockedUser && details.BlockingUser==model.BlockingUser


                                  select new BlockDTO()
                                  {
                                      Id = details.Id,
                                      BlockedUser=details.BlockedUser,
                                      DateTime = details.DateTime,
                                      BlockingUser=details.BlockingUser,
                                      Status=details.Status


                                  }).FirstOrDefault();
                    return await Task.FromResult(result);
                }
                catch (Exception)
                {
                    throw new Exception("Error getting vote");
                }
            }

        }
        public async Task<List<CommentDTO>> GetCommentList(string sessionToken,string Postid)
        {
            using (var db = new ConquerorHubEntities1())
            {
                var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                try
                {
                    
                    var result = (from details in db.CH_CommentTable where details.PostId==new Guid(Postid)


                                  select new CommentDTO()
                                  {
                                      Id = details.Id,
                                      PostId = details.PostId,
                                      UserId = details.UserId,
                                      CommentMessage = details.CommentMessage,
                                      CommentedDate = details.CommentedDate,
                                      AspNetUser = new AspnetUserDTO()
                                      {
                                          UserName = db.AspNetUsers.FirstOrDefault(a=>a.Id==details.UserId).UserName
                                      }



                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting comments");
                }
            }

        }
        public async Task<List<SubCommentsDTO>> GetSubCommentList(string sessionToken, string Postid)
        {
            using (var db = new ConquerorHubEntities1())
            {
                var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                try
                {
                    var result = (from details in db.CH_SubComment
                                  where details.CommentId ==new Guid(Postid)


                                  select new SubCommentsDTO()
                                  {
                                      CommentId = details.CommentId,
                                      PostId = details.PostId,
                                      UserId = details.UserId,
                                      SubCommentmsg = details.SubCommentmsg,
                                      SubCommentDatetime = details.SubCommentDatetime,
                                      AspNetUser = new AspnetUserDTO()
                                      {
                                          UserName = db.AspNetUsers.FirstOrDefault(a => a.Id == details.UserId).UserName
                                      }



                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting sponsors");
                }
            }

        }
        public async Task<List<ShareDTO>> GetShareList(string sessionToken)
        {
            using (var db = new ConquerorHubEntities1())
            {
                var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                try
                {
                    var result = (from details in db.CH_ShareTable


                                  select new ShareDTO()
                                  {
                                      Id = details.Id,
                                      PostId = details.PostId,
                                      DestinationPage = details.DestinationPage,
                                      SourcePage = details.SourcePage,
                                      ShareCount=details.ShareCount,
                                      DateTime=details.DateTime,
                                      ContentType=details.ContentType,
                                      

                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception)
                {
                    throw new Exception("Error getting share");
                }
            }

        }
        public async Task<List<BlockDTO>> GetBlockList(string sessionToken)
        {
            using (var db = new ConquerorHubEntities1())
            {
                var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                try
                {
                    var result = (from details in db.CH_BlockTable
                                  where details.BlockingUser==userId && details.Status==true


                                  select new BlockDTO()
                                  {
                                      Id = details.Id,
                                      BlockedUser=details.BlockedUser,
                                      BlockingUser=details.BlockingUser,
                                      Status=details.Status,
                                      DateTime=details.DateTime


                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception)
                {
                    throw new Exception("Error getting share");
                }
            }

        }

        public async Task<List<MainPhotosDTO>> GetMainphotos(string sessionToken)
        {
            using (var db = new ConquerorHubEntities1())
            {
                var userId = db.SessionTokens.Where(a => a.SessionToken1 == sessionToken).SingleOrDefault().UserId;
                try
                {
                    var result = (from details in db.CH_MainPhotos


                                  select new MainPhotosDTO()
                                  {
                                      Id = details.Id,
                                      PhotosId = details.PhotosId,
                                      BannerPicData = details.BannerPicData,
                                      ProfilePicData = details.ProfilePicData,
                                      UserId = details.UserId


                                  }).ToList();
                    return await Task.FromResult(result.ToList());
                }
                catch (Exception)
                {
                    throw new Exception("Error getting image");
                }
            }

        }


        public async Task<GuidResult> SaveLikes(string sessionToken, CH_LikesDTO model)
        {
            CH_Likes details = null;
            using (var db = new ConquerorHubEntities1())
            {
                var user = db.CH_Likes.Where(x => x.DestinationUserId == model.DestinationUserId && x.Imageid == model.Imageid &&x.SourceUserId==model.SourceUserId).Count();
                if (user == 0)
                {
                    if (model.LikeStatus == true)
                    {
                        details = new CH_Likes()
                        {
                            Id = Guid.NewGuid(),
                            LikeStatus = true,
                            Imageid = model.Imageid,
                            DestinationUserId = model.DestinationUserId,
                            SourceUserId = model.SourceUserId,
                            DateandTime=DateTime.Now

                        };
                    }
                    else
                    {

                        details = new CH_Likes()
                        {
                            Id = Guid.NewGuid(),
                            LikeStatus = false,
                            Imageid = model.Imageid,
                            DestinationUserId = model.DestinationUserId,
                            SourceUserId = model.SourceUserId,
                            DateandTime = DateTime.Now



                        };

                    }

                    try
                    {
                        db.CH_Likes.Add(details);
                        //db.DAP_USER_KYC_DOCUMENTS.AddRange(kycDetails);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ;
                    }

                }
                else
                {
                    CH_Likes data = new CH_Likes();
                    data = db.CH_Likes.FirstOrDefault(a => a.DestinationUserId == model.DestinationUserId && a.Imageid == model.Imageid && a.SourceUserId==model.SourceUserId);
                    if (model.LikeStatus == false)
                    {
                        data.LikeStatus = false;
                        data.DateandTime = DateTime.Now;



                    }
                    else
                    {
                        data.LikeStatus = true;
                        data.DateandTime = DateTime.Now;
                    }

                    try
                    {
                        db.Entry(data).State = EntityState.Modified;
                        //db.DAP_USER_KYC_DOCUMENTS.AddRange(kycDetails);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                }
            }
            return await Task.FromResult(new GuidResult(Guid.Empty));
        }
        public async Task<GuidResult> SaveSubscribers(string sessionToken, SubscriptionDTO model)
        {
            CH_SubscriptionTable details = null;
            using (var db = new ConquerorHubEntities1())
            {
                var user = db.CH_SubscriptionTable.Where(x => x.SubscriberUserId == model.SubscriberUserId && x.ProfileUserId == model.ProfileUserId).Count();
                if (user == 0)
                {
                    if (model.SubscriptionStatus == true)
                    {
                        details = new CH_SubscriptionTable()
                        {
                            Id = Guid.NewGuid(),
                            SubscriptionStatus = true,
                            ProfileUserId = model.ProfileUserId,
                            SubscriberUserId = model.SubscriberUserId,
                            Datetime=DateTime.Now

                        };
                    }
                    else
                    {

                        details = new CH_SubscriptionTable()
                        {
                            Id = Guid.NewGuid(),
                            SubscriptionStatus = false,
                            ProfileUserId = model.ProfileUserId,
                            SubscriberUserId = model.SubscriberUserId,
                            Datetime=DateTime.Now
                        };

                    }

                    try
                    {
                        db.CH_SubscriptionTable.Add(details);
                        //db.DAP_USER_KYC_DOCUMENTS.AddRange(kycDetails);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                }
                else
                {
                    CH_SubscriptionTable data = new CH_SubscriptionTable();
                    data = db.CH_SubscriptionTable.FirstOrDefault(a => a.SubscriberUserId == model.SubscriberUserId && a.ProfileUserId == model.ProfileUserId);
                    if (model.SubscriptionStatus == false)
                    {
                        data.SubscriptionStatus = false;


                    }
                    else
                    {
                        data.SubscriptionStatus = true;
                    }

                    try
                    {
                        db.Entry(data).State = EntityState.Modified;
                        //db.DAP_USER_KYC_DOCUMENTS.AddRange(kycDetails);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                }
            }
            return await Task.FromResult(new GuidResult(Guid.Empty));
        }
        public async Task<GuidResult> SaveVotes(string sessionToken, VotesDTO model)
        {
            CH_VoteTable details = null;
            using (var db = new ConquerorHubEntities1())
            {
                var user = db.CH_VoteTable.Where(x => x.userid == model.userid && x.PostId == model.PostId).Count();
                if (user == 0)
                {
                    if (model.VoteStatus == true)
                    {
                        details = new CH_VoteTable()
                        {
                            Id = Guid.NewGuid(),
                            VoteStatus = true,
                            PostId = model.PostId,
                            userid = model.userid,
                           EventId=model.EventId,
                           DateTime=DateTime.Now

                        };
                    }
                    else
                    {

                        details = new CH_VoteTable()
                        {
                            Id = Guid.NewGuid(),
                            VoteStatus = false,
                            PostId = model.PostId,
                            userid = model.userid,
                            EventId=model.EventId,
                            DateTime=DateTime.Now

                        };

                    }

                    try
                    {
                        db.CH_VoteTable.Add(details);
                        //db.DAP_USER_KYC_DOCUMENTS.AddRange(kycDetails);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                }
                else
                {
                    CH_VoteTable data = new CH_VoteTable();
                    data = db.CH_VoteTable.FirstOrDefault(a => a.userid == model.userid && a.PostId == model.PostId);
                    if (model.VoteStatus == false)
                    {
                        data.VoteStatus = false;


                    }
                    else
                    {
                        data.VoteStatus = true;
                    }

                    try
                    {
                        db.Entry(data).State = EntityState.Modified;
                        //db.DAP_USER_KYC_DOCUMENTS.AddRange(kycDetails);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                }
            }
            return await Task.FromResult(new GuidResult(Guid.Empty));
        }
        public async Task<CommentModelDTO> SaveComment(string sessionToken, CommentDTO model)
        {
            CommentModelDTO dTO = new CommentModelDTO();
            CH_CommentTable details = null;
            if (model.CommentMessage != null) {
                var Date = DateTime.UtcNow;
                using (var db = new ConquerorHubEntities1())
                {

                    details = new CH_CommentTable()
                    {
                        Id = model.Id,
                        PostId = model.PostId,
                        UserId = model.UserId,
                        CommentMessage = model.CommentMessage,
                        CommentedDate = Date,

                    };



                    try
                    {
                        db.CH_CommentTable.Add(details);
                        //db.DAP_USER_KYC_DOCUMENTS.AddRange(kycDetails);
                        int res = db.SaveChanges();
                        if (res > 0)
                        {
                           
                            dTO.CommentDate = Date.ToString();
                            dTO.result = true;
                            dTO.CommentId = model.Id.ToString();
                            dTO.UserName = db.AspNetUsers.Where(a => a.Id == model.UserId.ToString()).FirstOrDefault().UserName;
                            dTO.CommentMsg = model.CommentMessage;
                            return await Task.FromResult(dTO);
                        }
                    }

                    catch (Exception)
                    {
                        throw;
                    }
                }

            }
            return await Task.FromResult(dTO);
        }
        public async Task<CommentModelDTO> SaveSubComment(string sessionToken, SubCommentsDTO model)
        {
            CommentModelDTO dTO = new CommentModelDTO();
            CH_SubComment details = null;
            if (model.SubCommentmsg != null) {
                var Date = DateTime.UtcNow;
                using (var db = new ConquerorHubEntities1())
                {

                    details = new CH_SubComment()
                    {
                        CommentId = model.CommentId,

                        PostId = model.PostId,
                        UserId = model.UserId,
                        SubCommentDatetime = Date,
                        SubCommentId = model.SubCommentId,
                        SubCommentmsg = model.SubCommentmsg

                    };



                    try
                    {
                        db.CH_SubComment.Add(details);

                        int res = db.SaveChanges();
                        if (res > 0)
                        {
                           
                            dTO.CommentDate = Date.ToString();
                            dTO.result = true;
                            dTO.CommentId = model.SubCommentId.ToString();
                            dTO.UserName = db.AspNetUsers.Where(a => a.Id == model.UserId.ToString()).FirstOrDefault().UserName;
                            dTO.CommentMsg = model.SubCommentmsg;
                            return await Task.FromResult(dTO);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

            }
            return await Task.FromResult(dTO);
        }
        public async Task<GuidResult> SaveShare(string sessionToken, ShareDTO model)
        {
            CH_ShareTable details = null;
            using (var db = new ConquerorHubEntities1())
            {


                details = new CH_ShareTable()
                {
                    Id = model.Id,
                    PostId = model.PostId,
                    DestPostid = Guid.NewGuid(),
                       DestinationPage=model.DestinationPage,
                       SourcePage=model.SourcePage,
                       DateTime=DateTime.Now,
                       ContentType=model.ContentType,

                       
                    };

                

                try
                {
                    db.CH_ShareTable.Add(details);
                    //db.DAP_USER_KYC_DOCUMENTS.AddRange(kycDetails);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
            return await Task.FromResult(new GuidResult(Guid.Empty));
        }
        public async Task<GuidResult> SaveBlock(string sessionToken, BlockDTO model)
        {
            CH_BlockTable details = null;
            using (var db = new ConquerorHubEntities1())
            {
                var data = db.CH_BlockTable.Where(x => x.BlockedUser == model.BlockedUser && x.BlockingUser == model.BlockingUser).Select(x => x).Count();
                if (data == 0)
                {

                    details = new CH_BlockTable()
                    {
                     
                        BlockedUser = model.BlockedUser,
                        BlockingUser = model.BlockingUser,
                        DateTime = model.DateTime,
                        Status=model.Status

                    };

                    try
                    {
                        db.CH_BlockTable.Add(details);
                       
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                else
                {
                    var data1 = db.CH_BlockTable.Where(x => x.BlockedUser == model.BlockedUser && x.BlockingUser == model.BlockingUser).Select(x => x).FirstOrDefault();
                    data1.Status = model.Status;
                    try
                    {
                        db.Entry(data1).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        throw;
                    }

                }
                var unSubscribe = db.CH_SubscriptionTable.Where(x => x.SubscriberUserId == model.BlockedUser && x.ProfileUserId == model.BlockingUser).Select(x => x).FirstOrDefault();
                if (unSubscribe != null)
                {
                    if (model.Status == true)
                    {
                        unSubscribe.SubscriptionStatus = false;

                        try
                        {
                            db.Entry(unSubscribe).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }

                var unSubscribe1 = db.CH_SubscriptionTable.Where(x => x.SubscriberUserId == model.BlockingUser && x.ProfileUserId == model.BlockedUser).Select(x => x).FirstOrDefault();
                if (unSubscribe1 != null)
                {
                    if (model.Status == true)
                    {
                        unSubscribe1.SubscriptionStatus = false;

                        try
                        {
                            db.Entry(unSubscribe).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }



            }
            return await Task.FromResult(new GuidResult(Guid.Empty));
        }
        public async Task<GuidResult> Savemainphotos(string sessionToken, MainPhotosDTO model)
        {
            CH_MainPhotos details = null;
            using (var db = new ConquerorHubEntities1())
            {
                var count = db.CH_MainPhotos.Where(m => m.UserId == model.UserId).Select(x => x).Count();
                if (count == 0)
                {
                    details = new CH_MainPhotos()
                    {
                        Id = model.Id,
                        PhotosId = model.PhotosId,
                        BannerPicData = model.BannerPicData,
                        ProfilePicData = model.ProfilePicData,
                        UserId = model.UserId

                    };



                    try
                    {
                        db.CH_MainPhotos.Add(details);
                        //db.DAP_USER_KYC_DOCUMENTS.AddRange(kycDetails);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                else
                {
                    var data = db.CH_MainPhotos.Where(x => x.UserId == model.UserId).Select(x => x).FirstOrDefault();
                   
                    data.PhotosId = model.PhotosId;
                    if (model.BannerPicData.Length != 0)
                    {
                        data.BannerPicData = model.BannerPicData;
                    }
                    if (model.ProfilePicData.Length!=0)
                    {
                        data.ProfilePicData = model.ProfilePicData;
                    }
                    data.UserId = model.UserId;

                    try
                    {
                        db.Entry(data).State = EntityState.Modified;
                        //db.DAP_USER_KYC_DOCUMENTS.AddRange(kycDetails);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

            }
            return await Task.FromResult(new GuidResult(Guid.Empty));
        }

        public async Task<GuidResult> DeleteSponsorPost(string sessionToken,Guid? postid,Guid?Userid)
        {
            Sponsor data;
            using (var db = new ConquerorHubEntities1())
            {
                data = db.Sponsors.Where(x => x.ImageId == postid && x.UserId==Userid.ToString() ).Select(x => x).FirstOrDefault();            
               
                    try
                    {
                    db.Sponsors.Remove(data);
                        db.SaveChanges();
                    }

                    catch (Exception ex)
                    {
                        throw;
                    }
                
                return await Task.FromResult(new GuidResult(new Guid()));
            }

        }
        public async Task<GuidResult> DeleteHomePost(string sessionToken, Guid? postid, Guid? Userid)
        {
            CH_HomePageData data;
            using (var db = new ConquerorHubEntities1())
            {
                data = db.CH_HomePageData.Where(x => x.Postid == postid && x.UserId == Userid.ToString()).Select(x => x).FirstOrDefault();

                try
                {
                    db.CH_HomePageData.Remove(data);
                    db.SaveChanges();
                }

                catch (Exception ex)
                {
                    throw;
                }

                return await Task.FromResult(new GuidResult(new Guid()));
            }

        }
        public async Task<GuidResult> DeleteSharePost(string sessionToken, Guid? postid, Guid? Userid)
        {
            using (var db = new ConquerorHubEntities1())
            {
            
                CH_ShareTable data = db.CH_ShareTable.Where(x => x.PostId == postid && x.DestinationPage == Userid.ToString()).Select(x => x).FirstOrDefault();
                CH_Likes data1 = db.CH_Likes.Where(x => x.Imageid == postid && x.SourceUserId == Userid.ToString()).Select(x => x).FirstOrDefault();
                CH_CommentTable data2 = db.CH_CommentTable.Where(x => x.PostId == postid && x.UserId == Userid.ToString()).Select(x => x).FirstOrDefault();
                CH_SubComment data3=db.CH_SubComment.Where(x => x.PostId == postid && x.UserId == Userid.ToString()).Select(x => x).FirstOrDefault();
                try
                {
                    db.CH_ShareTable.Remove(data);
                    if (data1 != null)
                    {
                        db.CH_Likes.Remove(data1);
                    }
                    if (data2 != null)
                    {
                        db.CH_CommentTable.Remove(data2);
                    }
                    if (data3 != null)
                    {
                        db.CH_SubComment.Remove(data3);
                    }
                    
                    db.SaveChanges();
                }

                catch (Exception ex)
                {
                    throw;
                }

                return await Task.FromResult(new GuidResult(new Guid()));
            }

        }
        public async Task<GuidResult> DeleteParticipantGalleryPost(string sessionToken, Guid? postid, Guid? Userid)
        {
            using (var db = new ConquerorHubEntities1())
            {

                CH_ParticipantsGallery data = db.CH_ParticipantsGallery.Where(x => x.PostId == postid && x.UserId == Userid.ToString()).Select(x => x).FirstOrDefault();
                try
                {
                    db.CH_ParticipantsGallery.Remove(data);
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
            
        
        
    

