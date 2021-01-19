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

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Fee { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string GasPrice { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string GasLimit { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string NetworkFee { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FeeLevel { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string MaxFee { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? FailOnLowFee { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Note { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AutoStaking { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string NetworkStaking { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CpuStaking { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TransactionOperation Operation { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CustomerRefId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ReplaceTxByHash { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ExtraParameters { get; set; }
    }
}