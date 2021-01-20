using Fireblocks.Entities.Webhook;
using System;

namespace Fireblocks.Entities
{
    public class WebhookRequestBody
    {
        public string Type { get; set; }
        public string TenantId { get; set; }
        public long Timestamp { get; set; }
        public dynamic Data { get; set; }


        private Type _dataType;
        public Type DataType
        {
            get
            {
                return _dataType;
            }
            set
            {
                if (!Enum.IsDefined(typeof(EventTypes), Type))
                {
                    throw new ArgumentException("Invalid Event Type");
                }
                else
                {
                    Enum.TryParse(Type, out EventTypes eventTypes);
                    switch (eventTypes)
                    {
                        case EventTypes.TRANSACTION_CREATED:
                            _dataType = EventTypes.TRANSACTION_CREATED.GetType();
                            break;
                        case EventTypes.TRANSACTION_STATUS_UPDATED:
                            _dataType = EventTypes.TRANSACTION_STATUS_UPDATED.GetType();
                            break;
                        case EventTypes.VAULT_ACCOUNT_ADDED:
                            _dataType = EventTypes.VAULT_ACCOUNT_ADDED.GetType();
                            break;
                        case EventTypes.VAULT_ACCOUNT_ASSET_ADDED:
                            _dataType = EventTypes.VAULT_ACCOUNT_ASSET_ADDED.GetType();
                            break;
                        case EventTypes.INTERNAL_WALLET_ASSET_ADDED:
                            _dataType = EventTypes.INTERNAL_WALLET_ASSET_ADDED.GetType();
                            break;
                        case EventTypes.EXTERNAL_WALLET_ASSET_ADDED:
                            _dataType = EventTypes.EXTERNAL_WALLET_ASSET_ADDED.GetType();
                            break;
                        case EventTypes.EXCHANGE_ACCOUNT_ADDED:
                            _dataType = EventTypes.EXCHANGE_ACCOUNT_ADDED.GetType();
                            break;
                        case EventTypes.FIAT_ACCOUNT_ADDED:
                            _dataType = EventTypes.FIAT_ACCOUNT_ADDED.GetType();
                            break;
                        case EventTypes.NETWORK_CONNECTION_ADDED:
                            _dataType = EventTypes.NETWORK_CONNECTION_ADDED.GetType();
                            break;
                    }
                }
            }
        }
    }
}