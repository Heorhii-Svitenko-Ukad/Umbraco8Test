using System.Web.Http;
using Umbraco.Web.WebApi;
using Umbraco8Test.Models;
using Umbraco8Test.Services;

namespace Umbraco8Test.Controllers
{
    public class DbMembersController : UmbracoApiController
    {
        private readonly DbMemberService _memberService;

        public DbMembersController(DbMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPut]
        public IHttpActionResult UpsertMember(DbMember member)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_memberService.UpsertMember(member));
        }
    }
}
