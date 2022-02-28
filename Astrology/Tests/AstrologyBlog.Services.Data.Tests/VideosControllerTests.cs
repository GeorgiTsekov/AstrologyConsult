////namespace AstrologyBlog.Services.Data.Tests
////{
////    using System;
////    using System.Collections.Generic;
////    using System.Text;

////    using AstrologyBlog.Web.Controllers;
////    using AstrologyBlog.Web.ViewModels.Events;
////    using AstrologyBlog.Web.ViewModels.Videos;
////    using FakeItEasy;
////    using Microsoft.AspNetCore.Mvc;
////    using Xunit;

////    [Fact]
////    public void WhenCreateShoultReturn3Videos()
////    {
////        var fakeVideosService = A.Fake<IVideosService>();

////        A
////            .CallTo(() => fakeVideosService.GetAll<VideoViewModel>(1, 1))
////            .Returns(new List<VideoViewModel>
////                {
////                new VideoViewModel
////                    {
////                        Id = 1,
////                        Title = "Title1",
////                        Name = "Pesho",
////                        Description = "asdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjsfjsdkj fsdklfj klsd fjsd",
////                    },
////                new VideoViewModel
////                    {
////                        Id = 2,
////                        Title = "Title2",
////                        Name = "Gosho",
////                        Description = "asdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjsfjsdkj fsdklfj klsd fjsd",
////                    },
////                });

////        var fakeArticleCategoriesService = A.Fake<IArticlesCategoriesService>();

////        A
////            .CallTo(() => fakeVideosService.GetAll<>(1, 1))
////            .Returns(A.CollectionOfFake<>);
////        var videosController = new VideosController(fakeVideosServic, fakeArticleCategoriesServicee);

////        var result = eventsController.All();
////        var viewResult = Assert.IsType<ViewResult>(result);
////        var model = viewResult.Model as IndexEventViewModel;

////        ////var newRes = eventsController.Details(1);
////        ////var newViewRes = Assert.IsType<ViewResult>(newRes);
////        ////var newModel = newViewRes.Model as EventViewModel;

////        ////Assert.Equal("Pesho", newModel.Name);

////        Assert.Equal(2, model.Vide.Count());
////        ////Assert.Equal("Title1", model.Events.FirstOrDefault(x => x.Id == 1).Title);
////        ////Assert.Equal("Gosho", model.Events.FirstOrDefault(x => x.Id == 2).Name);
////        ////Assert.Equal("Plovdiv", model.Events.FirstOrDefault(x => x.Id == 2).Place);
////        ////Assert.Equal("Pesho", model.Events.FirstOrDefault(x => x.Date == "12/22/2022").Name);
////        ////var eventsController = new EventsController(fakeEventsService);

////        ////var result = eventsController.Details(1);

////        ////var viewResult = Assert.IsType<ViewResult>(result);
////        ////var model = viewResult.Model as EventViewModel;
////        ////Assert.Equal("Title1", model.Title);
////    }
////}
