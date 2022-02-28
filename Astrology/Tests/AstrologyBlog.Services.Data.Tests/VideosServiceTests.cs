namespace AstrologyBlog.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;
    using AstrologyBlog.Web.ViewModels;
    using AstrologyBlog.Web.ViewModels.Videos;
    using Moq;
    using Xunit;

    public class VideosServiceTests
    {
        public VideosServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public void TestGetListOfVideos_WithoutAnyData_ShouldReturnGetAllCount()
        {
            var mockVideoRepo = new Mock<IDeletableEntityRepository<Video>>();
            mockVideoRepo.Setup(x => x.All()).Returns(ListOfVideos().AsQueryable());

            var videosService = new VideosService(mockVideoRepo.Object);
            var allVideos = videosService.GetAll<VideoViewModel>(1, 12);
            Assert.Equal(2, allVideos.Count());
        }

        [Fact]
        public void TestGetListOfVideos_WithoutAnyData_ShouldReturnGetById()
        {
            var mockVideoRepo = new Mock<IDeletableEntityRepository<Video>>();
            mockVideoRepo.Setup(x => x.AllAsNoTracking()).Returns(ListOfVideos().AsQueryable());

            var videosService = new VideosService(mockVideoRepo.Object);
            var currentVideo = videosService.GetById<SingleVideoViewModel>(1);
            Assert.Equal("Pesho", currentVideo.Name);
        }

        ////[Fact]
        ////public async void TestCreateAsync_WithoutAnyData_ShouldReturnGetAll()
        ////{
        ////    var mockVideoRepo = new Mock<IDeletableEntityRepository<Video>>();
        ////    mockVideoRepo.Setup(x => x.All()).Returns(ListOfVideos().AsQueryable());

        ////    var videosService = new VideosService(mockVideoRepo.Object);
        ////    var video = new CreateVideoInputModel
        ////    {
        ////        Name = "Me",
        ////        Title = "TitleMe",
        ////        Description = "asdpkoaso as;ld kas;l dkas;ld kasl fjsdklfjsdklj fsdkjf klsdj fklsj fas fhjksdhf jksdh jksdhg lsdhg sdhg sdhglksdjgh sjklh klsjf ksdj fs",
        ////        ArticlesCategoryId = 3,
        ////        VideoUrl = "https://www.youtube.com/watch?v=oneJK8gyUGc&t=6s",
        ////    };

        ////    await videosService.CreateAsync(video);

        ////    var allVideos = videosService.GetAll<VideoViewModel>(1, 12);
        ////    Assert.Equal(3, allVideos.Count());
        ////}

        private static List<Video> ListOfVideos()
        {
            return new List<Video>
                {
                new Video
                    {
                        Id = 1,
                        Title = "Title1",
                        Name = "Pesho",
                        Description = "asdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjsfjsdkj fsdklfj klsd fjsd",
                        ArticlesCategoryId = 1,
                        VideoUrl = "https://www.youtube.com/watch?v=oneJK8gyUGc&t=6s",
                    },
                new Video
                    {
                        Id = 2,
                        Title = "Title2",
                        Name = "Pesho2",
                        Description = "ASDsdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjsfjsdkj fsdklfj klsd fjsd",
                        ArticlesCategoryId = 2,
                        VideoUrl = "https://www.youtube.com/watch?v=oneJK8gyUGc&t=6s",
                    },
                };
        }
    }
}
