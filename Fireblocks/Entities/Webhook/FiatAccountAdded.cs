namespace Fireblocks.Entities.Webhook
{
    public class FiatAccountAdded : WebhookRequestBody
    {
        public ThirdPartyWebhook Data { get; set; }
    }
}
