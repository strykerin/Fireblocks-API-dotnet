namespace Fireblocks.Entities.Webhook
{
    public class InternalWalletAssetAdded : WebhookRequestBody
    {
        public WalletAssetWebhook Data { get; set; }
    }
}
