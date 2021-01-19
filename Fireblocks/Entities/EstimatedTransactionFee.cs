using System.Text.Json.Serialization;

namespace Fireblocks.Entities
{
    public class EstimatedTransactionFee
    {
        public EstimatedTransactionFee(string assetId, string amount, TransferPeerPath source, DestinationTransferPeerPath destination)
        {
            AssetId = assetId;
            Amount = amount;
            Source = source;
            Destination = destination;
        }

        public string AssetId { get; private set; }
        public string Amount { get; private set; }
        public TransferPeerPath Source { get; private set; }
        public DestinationTransferPeerPath Destination { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TransactionOperation Operation { get; set; }
    }
}
