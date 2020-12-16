namespace AstrologyBlog.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;
    using AstrologyBlog.Web.ViewModels.Videos;

    public class VideosService : IVideosService
    {
        private readonly IDeletableEntityRepository<Video> videoRepository;

        public VideosService(IDeletableEntityRepository<Video> videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public async Task<int> CreateAsync(CreateVideoInputModel input)
        {
            var youtubeVideo = new StringBuilder();
            youtubeVideo.Append("https://www.youtube.com/embed/");
            var splitedVideoUrl = input.VideoUrl.Split("watch?v=");
            youtubeVideo.Append(splitedVideoUrl[1]);
            youtubeVideo.Append("?autoplay=0");
            var video = new Video
            {
                Title = input.Title,
                Name = input.Name,
                Description = input.Description,
                VideoUrl = youtubeVideo.ToString().TrimEnd(),
                ArticlesCategoryId = input.ArticlesCategoryId,
            };

            await this.videoRepository.AddAsync(video);
            await this.videoRepository.SaveChangesAsync();
            return video.Id;
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var videos = this.videoRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
            return videos;
        }

        public int GetCount()
        {
            return this.videoRepository.All().Count();
        }
    }
}
