﻿using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco8Test.Models;

namespace Umbraco8Test.Services
{
    public class DbMemberService
    {
        private readonly IMemberService _memberService;
        private readonly IMemberTypeService _memberTypeService;

        public DbMemberService(IMemberService memberService, IMemberTypeService memberTypeService)
        {
            _memberService = memberService;
            _memberTypeService = memberTypeService;
        }

        public void UpsertMember(DbMember member)
        {
            var savedMember = _memberService.GetByEmail(member.Email);

            if (savedMember == null)
            {
                string memberTypeName = _memberTypeService.GetDefault();

                var memberType = _memberTypeService.Get(memberTypeName);
                savedMember = new Member(memberType);
            }

            savedMember.Key = member.UserId;
            savedMember.Name = member.Name;
            savedMember.Email = member.Email;
            savedMember.CreateDate = member.Created;

            _memberService.Save(savedMember);
        }
    }
}