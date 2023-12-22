using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro
{
    public class AcclaroApplication : IApplication
    {
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
}
