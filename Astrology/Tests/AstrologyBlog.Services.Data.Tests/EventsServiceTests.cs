namespace AstrologyBlog.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Web.Controllers;
    using AstrologyBlog.Web.ViewModels.Events;
    using FakeItEasy;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;

    public class EventsServiceTests
    {
        [Fact]
        public void TestGetAll_WhenCreate2EventsShoultReturn2EventsWithTheSameValues()
        {
            var id = ListOfEvents().FirstOrDefault().Id;
            var fakeEventsService = A.Fake<IEventsService>();

            A
                .CallTo(() => fakeEventsService.GetAll<EventViewModel>(null))
                .Returns(ListOfEvents());

            var eventsController = new EventsController(fakeEventsService);

            var result = eventsController.All();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = viewResult.Model as IndexEventViewModel;
            Assert.Equal(2, model.Events.Count());
            Assert.Equal("Title1", model.Events.FirstOrDefault(x => x.Id == 1).Title);
            Assert.Equal("Gosho", model.Events.FirstOrDefault(x => x.Id == 2).Name);
            Assert.Equal("Plovdiv", model.Events.FirstOrDefault(x => x.Id == 2).Place);
            Assert.Equal("Pesho", model.Events.FirstOrDefault(x => x.Date == "12/22/2022").Name);

            A.CallTo(() => fakeEventsService.GetById<EventViewModel>(id))
                .Returns(ListOfEvents().FirstOrDefault(x => x.Id == id));

            var newRes = eventsController.Details(id);
            var newViewRes = Assert.IsType<ViewResult>(newRes);
            var newModel = newViewRes.Model as EventViewModel;

            Assert.Equal("Pesho", newModel.Name);
        }

        [Fact]
        public void TestGetById_WhenCreateEventReturnSameEventWhenUseGetById()
        {
            var id = ListOfEvents().FirstOrDefault().Id;
            var fakeEventsService = A.Fake<IEventsService>();

            A.CallTo(() => fakeEventsService.GetById<EventViewModel>(id))
                .Returns(ListOfEvents().FirstOrDefault(x => x.Id == id));
            var eventsController = new EventsController(fakeEventsService);

            var newRes = eventsController.Details(id);
            var newViewRes = Assert.IsType<ViewResult>(newRes);
            var newModel = newViewRes.Model as EventViewModel;

            Assert.Equal("Pesho", newModel.Name);
        }

        private static List<EventViewModel> ListOfEvents()
        {
            return new List<EventViewModel>
                {
                new EventViewModel
                    {
                        Id = 1,
                        Title = "Title1",
                        Name = "Pesho",
                        Date = "12/22/2022",
                        Place = "Sofia",
                        Description = "asdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjsfjsdkj fsdklfj klsd fjsd",
                    },
                new EventViewModel
                    {
                        Id = 2,
                        Title = "Title2",
                        Name = "Gosho",
                        Date = "11/22/2022",
                        Place = "Plovdiv",
                        Description = "asdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjsfjsdkj fsdklfj klsd fjsd",
                    },
                };
        }
    }
}
