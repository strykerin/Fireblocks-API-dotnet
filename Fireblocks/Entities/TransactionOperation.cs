namespace Fireblocks.Entities
{
    public class TransactionOperation
    {
        /// <summary>
        /// [ TRANSFER, RAW, CONTRACT_CALL, MINT, BURN, SUPPLY_TO_COMPOUND, REDEEM_FROM_COMPOUND ]
        /// </summary>
        public string Operation { get; set; }
    }
}
