using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.Acclaro;

public class AcclaroApplication : IApplication, ICategoryProvider
{
        
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.LspPortal];
        set { }
    }
        
    public string Name
    {
        get => "My Acclaro";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}