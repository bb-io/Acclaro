using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Callbacks.Payload;

public class StringUpdatePayload
{
    [Display("String ID")]
    public string Id { get; set; }
}