using System.Data.SqlClient;
using System.Linq;
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
            {
                var errors = ModelState.Values
                    .SelectMany(o => o.Errors)
                    .Select(o => o.ErrorMessage)
                    .Union(
                        ModelState.Values
                        .SelectMany(o => o.Errors)
                        .Select(o => o.Exception?.Message)
                    )
                    .Where(o => !string.IsNullOrEmpty(o));

                return BadRequest(string.Join("\n", errors));
            }

            try
            {
                _memberService.UpsertMember(member);

                return Ok();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
