using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using Umbraco.Core.Logging;
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

                var errorString = string.Join("\n", errors);
                Logger.Info<DbMembersController>("Discarding invalid request {Error}", errorString);

                return BadRequest(errorString);
            }

            try
            {
                _memberService.UpsertMember(member);

                Logger.Info<DbMemberService>("Upserted member {@Member}", member);

                return Ok();
            }
            catch (SqlException ex)
            {
                Logger.Warn<DbMembersController>(ex, "Upserting member {@Member} failed", member);

                return BadRequest(ex.Message);
            }
        }
    }
}
