namespace AstrologyBlog.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;
    using AstrologyBlog.Web.ViewModels.Events;

    public class EventsService : IEventsService
    {
        private readonly IDeletableEntityRepository<Event> eventRepository;

        public EventsService(IDeletableEntityRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task CreateAsync(CreateEventInputModel input)
        {
            var events = new Event
            {
                Title = input.Title,
                Name = input.Name,
                Date = input.Date,
                Place = input.Place,
                Description = input.Description,
            };

            await this.eventRepository.AddAsync(events);
            await this.eventRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var eventModel = this.eventRepository.All().FirstOrDefault(x => x.Id == id);
            this.eventRepository.Delete(eventModel);
            await this.eventRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Event> events = this.eventRepository.All().OrderByDescending(x => x.CreatedOn);
            if (count.HasValue)
            {
                events = events.Take(count.Value);
            }

            return events.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var eventModel = this.eventRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return eventModel;
        }

        public async Task UpdateAsync(int id, EditEventInputModel input)
        {
            var eventModel = this.eventRepository.All().FirstOrDefault(x => x.Id == id);
            eventModel.Title = input.Title;
            eventModel.Name = input.Name;
            eventModel.Date = input.Date;
            eventModel.Place = input.Place;
            eventModel.Description = input.Description;
            await this.eventRepository.SaveChangesAsync();
        }
    }
}
