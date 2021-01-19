namespace Fireblocks.Entities.Webhook
{
    public class VaultAccountAssetAdded : WebhookRequestBody
    {
        public AssetAddedData Data { get; set; }
    }
}
