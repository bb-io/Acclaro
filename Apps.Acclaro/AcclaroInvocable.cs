using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro
{
    public class AcclaroInvocable : BaseInvocable
    {
        protected AcclaroClient Client { get; set; }
        protected IEnumerable<AuthenticationCredentialsProvider> Creds => InvocationContext.AuthenticationCredentialsProviders;

        public AcclaroInvocable(InvocationContext invocationContext) : base(invocationContext)
        {
            Client = new AcclaroClient();
        }
    }
}
