namespace AstrologyBlog.Web.Controllers
{
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Data;
    using AstrologyBlog.Web.ViewModels.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : BaseController
    {
        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(
            IVotesService votesService,
            UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.votesService.VoteAsync(input.ArticleId, user.Id, input.StarsCount);
            var averageStarsVote = this.votesService.GetAverageStarsFromVotes(input.ArticleId);
            return new VoteResponseModel { AverageStarsVote = averageStarsVote };
        }
    }
}
