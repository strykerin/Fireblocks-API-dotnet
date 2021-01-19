namespace Fireblocks.Entities
{
    public class TransactionRequestDestination
    {
        public string Amount { get; set; }
        public DestinationTransferPeerPath Destination { get; set; }
    }
}
