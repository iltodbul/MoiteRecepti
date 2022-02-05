namespace MoiteRecepti.Web.Areas.Administration.Controllers
{
    using MoiteRecepti.Common;
    using MoiteRecepti.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
