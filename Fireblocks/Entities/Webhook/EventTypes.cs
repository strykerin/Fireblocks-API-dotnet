namespace Fireblocks.Entities.Webhook
{
    public enum EventTypes
    {
        TRANSACTION_CREATED = 0,
        TRANSACTION_STATUS_UPDATED = 1,
        VAULT_ACCOUNT_ADDED = 2,
        VAULT_ACCOUNT_ASSET_ADDED = 3,
        INTERNAL_WALLET_ASSET_ADDED = 4,
        EXTERNAL_WALLET_ASSET_ADDED = 5,
        EXCHANGE_ACCOUNT_ADDED = 6,
        FIAT_ACCOUNT_ADDED = 7,
        NETWORK_CONNECTION_ADDED = 8
    }
}
