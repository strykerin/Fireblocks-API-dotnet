namespace Fireblocks.Entities
{
    public class TransactionDetails
    {
        public string Id { get; set; }
        public string AssetId { get; set; }
        public Source Source { get; set; }
        public Destination Destination { get; set; }
        public Amountinfo AmountInfo { get; set; }
        public Feeinfo FeeInfo { get; set; }
        public int RequestedAmount { get; set; }
        public int Amount { get; set; }
        public int NetAmount { get; set; }
        public int AmountUSD { get; set; }
        public int ServiceFee { get; set; }
        public int NetworkFee { get; set; }
        public string CreatedAt { get; set; }
        public string LastUpdated { get; set; }
        public string Status { get; set; }
        public string TxHash { get; set; }
        public string Tag { get; set; }
        public string SubStatus { get; set; }
        public string DestinationAddress { get; set; }
        public string DestinationAddressDescription { get; set; }
        public string DestinationTag { get; set; }
        public string[] SignedBy { get; set; }
        public string CreatedBy { get; set; }
        public string RejectedBy { get; set; }
        public string AddressType { get; set; }
        public string Note { get; set; }
        public string ExchangeTxId { get; set; }
        public string FeeCurrency { get; set; }
        public string Operation { get; set; }
        public Networkrecord[] NetworkRecords { get; set; }
        public Amlscreeningresult AmlScreeningResult { get; set; }
        public string CustomerRefId { get; set; }
        public int NumOfConfirmations { get; set; }
        public Signedmessage[] SignedMessages { get; set; }
        public string ReplacedTxHash { get; set; }
        public Extraparameters ExtraParameters { get; set; }
    }

    public class Source
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string SubType { get; set; }
    }

    public class Destination
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string SubType { get; set; }
    }

    public class Amountinfo
    {
        public string Amount { get; set; }
        public string RequestedAmount { get; set; }
        public string NetAmount { get; set; }
        public string AmountUSD { get; set; }
    }

    public class Feeinfo
    {
        public string NetworkFee { get; set; }
        public string ServiceFee { get; set; }
    }

    public class Amlscreeningresult
    {
        public string Provider { get; set; }
        public Payload Payload { get; set; }
    }

    public class Payload
    {
    }

    public class Extraparameters
    {
    }

    public class Networkrecord
    {
        public Source Source { get; set; }
        public Destination Destination { get; set; }
        public string TxHash { get; set; }
        public string NetworkFee { get; set; }
        public string AssetId { get; set; }
        public string NetAmount { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string DestinationAddress { get; set; }
    }

    public class Signedmessage
    {
        public string Content { get; set; }
        public string Algorithm { get; set; }
        public int[] DerivationPath { get; set; }
        public Signature Signature { get; set; }
        public string PublicKey { get; set; }
    }

    public class Signature
    {
        public string R { get; set; }
        public string S { get; set; }
        public int V { get; set; }
    }
}
