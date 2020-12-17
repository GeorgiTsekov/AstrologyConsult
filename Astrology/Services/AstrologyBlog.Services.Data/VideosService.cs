namespace AstrologyBlog.Services.Data
{
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
            var videoInput = input.VideoUrl;
            string youtubeVideo = MakeYoutubeVideoWorkForMyApp(videoInput);

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

        public async Task DeleteAsync(int id)
        {
            var video = this.videoRepository.All().FirstOrDefault(x => x.Id == id);
            this.videoRepository.Delete(video);
            await this.videoRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            var videos = this.videoRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
            return videos;
        }

        public T GetById<T>(int id)
        {
            var video = this.videoRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return video;
        }

        public int GetCount()
        {
            return this.videoRepository.All().Count();
        }

        public async Task UpdateAsync(int id, EditVideoInputModel input)
        {
            var videoInput = input.VideoUrl;
            string youtubeVideo = MakeYoutubeVideoWorkForMyApp(videoInput);

            var video = this.videoRepository.All().FirstOrDefault(x => x.Id == id);
            video.Title = input.Title;
            video.Name = input.Name;
            video.Description = input.Description;
            video.VideoUrl = youtubeVideo;
            video.ArticlesCategoryId = input.ArticlesCategoryId;
            await this.videoRepository.SaveChangesAsync();
        }

        private static string MakeYoutubeVideoWorkForMyApp(string videoInput)
        {
            var sb = new StringBuilder();
            sb.Append("https://www.youtube.com/embed/");
            var splitedVideoUrl = videoInput.Split("watch?v=");
            sb.Append(splitedVideoUrl[1]);
            sb.Append("?autoplay=0");
            var youtubeVideo = sb.ToString().TrimEnd();
            return youtubeVideo;
        }
    }
}
