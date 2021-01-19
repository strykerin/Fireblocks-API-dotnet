using System.Text.Json.Serialization;

namespace Fireblocks.Entities
{
    public class CreateTransaction
    {
        public CreateTransaction(string assetId, TransferPeerPath source, DestinationTransferPeerPath destination, string amount, TransactionRequestDestination[] destinations)
        {
            AssetId = assetId;
            Source = source;
            Destination = destination;
            Amount = amount;
            Destinations = destinations;
        }

        public string AssetId { get; private set; }
        public TransferPeerPath Source { get; private set; }
        public DestinationTransferPeerPath Destination { get; private set; }
        public TransactionRequestDestination[] Destinations { get; private set; }
        public string Amount { get; private set; }
        public string Fee { get; set; }
        public string GasPrice { get; set; }
        public string GasLimit { get; set; }
        public string NetworkFee { get; set; }
        public string FeeLevel { get; set; }
        public string MaxFee { get; set; }
        public bool? FailOnLowFee { get; set; }
        public string Note { get; set; }
        public bool? AutoStaking { get; set; }
        public string NetworkStaking { get; set; }
        public string CpuStaking { get; set; }
        public TransactionOperation Operation { get; set; }
        public string CustomerRefId { get; set; }
        public string ReplaceTxByHash { get; set; }
        public string ExtraParameters { get; set; }
    }
}