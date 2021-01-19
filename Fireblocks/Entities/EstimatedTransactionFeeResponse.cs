namespace Fireblocks.Entities
{
    public class EstimatedTransactionFeeResponse
    {
        /// <summary>
        /// Transactions with this fee will probably take longer to be mined
        /// </summary>
        public TransactionFee Low { get; set; }

        /// <summary>
        /// Average transactions fee
        /// </summary>
        public TransactionFee Medium { get; set; }

        /// <summary>
        /// Transactions with this fee should be mined the fastest
        /// </summary>
        public TransactionFee High { get; set; }
    }
}
