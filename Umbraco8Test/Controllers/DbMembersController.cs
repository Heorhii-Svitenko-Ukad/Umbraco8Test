using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Umbraco.Core.Services;
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
        public int UpsertMember(DbMember member)
        {
            return _memberService.UpsertMember(member);
        }
    }
}
