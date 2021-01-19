namespace Fireblocks.Entities.Webhook
{
    public class VaultAccountAdded : WebhookRequestBody
    {
        public VaultAccount Data { get; set; }
    }
}
