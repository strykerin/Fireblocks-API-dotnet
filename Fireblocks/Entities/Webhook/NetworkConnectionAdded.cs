namespace Fireblocks.Entities.Webhook
{
    public class NetworkConnectionAdded : WebhookRequestBody
    {
        public NetworkConnection Data { get; set; }
    }
}
