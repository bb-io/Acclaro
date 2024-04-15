using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Acclaro;

public class AcclaroInvocable : BaseInvocable
{
    protected AcclaroClient Client { get; set; }
    protected IEnumerable<AuthenticationCredentialsProvider> Creds => InvocationContext.AuthenticationCredentialsProviders;

    public AcclaroInvocable(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new AcclaroClient(invocationContext.AuthenticationCredentialsProviders);
    }
}