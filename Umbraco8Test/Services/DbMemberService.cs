using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Services;
using Umbraco8Test.Models;

namespace Umbraco8Test.Services
{
    public class DbMemberService
    {
        private readonly IMemberService _memberService;

        public DbMemberService(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public int UpsertMember(DbMember member)
        {


            return 123;
        }
    }
}