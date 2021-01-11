namespace AstrologyBlog.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using Moq;
    using Xunit;

    public class VotesServiceTests
    {
        [Fact]
        public async Task WhenUserVotes2TimesOnly1VoteShoutBeCounted()
        {
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback((Vote vote) => list.Add(vote));

            var service = new VotesService(mockRepo.Object);

            await service.VoteAsync(1, "1", 1);
            await service.VoteAsync(1, "1", 3);
            await service.VoteAsync(1, "1", 4);
            await service.VoteAsync(1, "1", 5);
            await service.VoteAsync(1, "1", 5);

            Assert.Equal(1, list.Count);
            Assert.Equal(5, list.First().StarsCount);
        }

        [Fact]
        public async Task When2UsersVotesForSameArticleTheAverageShoultBeCorrect()
        {
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback((Vote vote) => list.Add(vote));

            var service = new VotesService(mockRepo.Object);

            await service.VoteAsync(2, "Gosho", 5);
            await service.VoteAsync(2, "Tosho", 1);
            await service.VoteAsync(2, "Gosho", 2);

            mockRepo.Verify(x => x.AddAsync(It.IsAny<Vote>()), Times.Exactly(2));

            Assert.Equal(2, list.Count);
            Assert.Equal(1.5, service.GetAverageStarsFromVotes(2));
        }
    }
}
