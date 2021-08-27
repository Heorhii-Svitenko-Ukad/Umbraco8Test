using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Umbraco8Test.Services
{
    public class DbMemberServiceComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<DbMemberService>(Lifetime.Scope);
        }
    }
}