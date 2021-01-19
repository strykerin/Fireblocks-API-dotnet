namespace Fireblocks.Entities.Webhook
{
    public class TransactionStatusUpdated : WebhookRequestBody
    {
        public TransactionDetails Data { get; set; }
    }
}
