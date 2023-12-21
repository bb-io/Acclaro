using System.Runtime.InteropServices;

namespace Apps.Acclaro.Callbacks.Payload
{
    public class StringUpdatePayload
    {
        [DispId("String ID")]
        public string Id { get; set; }
    }
}
