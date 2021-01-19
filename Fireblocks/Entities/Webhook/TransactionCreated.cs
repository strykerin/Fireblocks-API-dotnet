namespace Fireblocks.Entities.Webhook
{
    public class TransactionCreated : WebhookRequestBody
    {
        public TransactionDetails Data { get; set; }
    }
}
