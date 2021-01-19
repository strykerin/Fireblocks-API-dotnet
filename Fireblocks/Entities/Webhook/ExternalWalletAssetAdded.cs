namespace Fireblocks.Entities.Webhook
{
    public class ExternalWalletAssetAdded : WebhookRequestBody
    {
        public WalletAssetWebhook Data { get; set; }
    }
}
