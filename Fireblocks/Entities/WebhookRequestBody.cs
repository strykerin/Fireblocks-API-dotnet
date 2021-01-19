namespace Fireblocks.Entities
{
    public class WebhookRequestBody
    {
        public string Type { get; set; }
        public string TenantId { get; set; }
        public long Timestamp { get; set; }
    }
}
