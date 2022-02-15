namespace AstrologyBlog.Web.Controllers
{
    using System.Threading.Tasks;

    using AstrologyBlog.Common;
    using AstrologyBlog.Services.Data;
    using AstrologyBlog.Web.ViewModels.Events;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : Controller
    {
        private readonly IEventsService eventsService;

        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public IActionResult All()
        {
            var viewModel = new IndexEventViewModel
            {
                Events = this.eventsService.GetAll<EventViewModel>(),
            };
            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(CreateEventInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.eventsService.CreateAsync(input);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Details(int id)
        {
            var eventView = this.eventsService.GetById<EventViewModel>(id);
            if (eventView == null)
            {
                return this.NotFound();
            }

            return this.View(eventView);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var inputModel = this.eventsService.GetById<EditEventInputModel>(id);
            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id, EditEventInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.eventsService.UpdateAsync(id, input);

            return this.RedirectToAction(nameof(this.Details), new { id });
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.eventsService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
