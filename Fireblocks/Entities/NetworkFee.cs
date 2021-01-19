namespace Fireblocks.Entities
{
    public class NetworkFee
    {
        /// <summary>
        /// [optional] For UTXOs
        /// </summary>
        public string FeePerByte { get; set; }

        /// <summary>
        /// [optional] For Ethereum assets (ETH and Tokens)
        /// </summary>
        public string GasPrice { get; set; }

        /// <summary>
        /// [optional] All other assets
        /// </summary>
        public string NetworkFeeValue { get; set; }
    }
}