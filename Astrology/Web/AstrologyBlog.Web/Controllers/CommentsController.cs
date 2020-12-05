namespace AstrologyBlog.Web.Controllers
{
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Data;
    using AstrologyBlog.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(
            ICommentsService commentsService,
            UserManager<ApplicationUser> userManager)
        {
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCommentInputModel inputModel)
        {
            var parentId = inputModel.ParentId == 0 ? null : inputModel.ParentId;

            if (parentId.HasValue)
            {
                if (!this.commentsService.IsCommentInArticle(parentId.Value, inputModel.ArticleId))
                {
                    return this.BadRequest();
                }
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.commentsService.Create(inputModel.ArticleId, user.Id, inputModel.Content, parentId);
            return this.RedirectToAction("ById", "Articles", new { id = inputModel.ArticleId });
        }
    }
}
