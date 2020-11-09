namespace AstrologyBlog.Web.Areas.Administration.Controllers
{
    using AstrologyBlog.Common;
    using AstrologyBlog.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
