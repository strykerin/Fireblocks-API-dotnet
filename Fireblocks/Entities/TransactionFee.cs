namespace Fireblocks.Entities
{
    public class TransactionFee
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
        /// [optional] For Ethereum assets (ETH and Tokens), the limit for how much can be used
        /// </summary>
        public string GasLimit { get; set; }

        /// <summary>
        /// [optional] Transaction fee
        /// </summary>
        public string NetworkFeeValue { get; set; }
    }
}
