namespace Fireblocks.Entities
{
    public class TransferPeerPath
    {
        /// <summary>
        /// [ VAULT_ACCOUNT, EXCHANGE_ACCOUNT, INTERNAL_WALLET, EXTERNAL_WALLET, NETWORK_CONNECTION, FIAT_ACCOUNT, COMPOUND ]
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The ID of the peer
        /// </summary>
        public string Id { get; set; }
    }
}
