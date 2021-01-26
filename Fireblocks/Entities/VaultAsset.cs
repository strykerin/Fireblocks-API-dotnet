namespace Fireblocks.Entities
{
    public class VaultAsset
    {
        /// <summary>
        /// The ID of the asset
        /// </summary>
        public string Id { get; set; }
        public string Total { get; set; }
        public string Balance { get; set; }
        public string Available { get; set; }
        public string Pending { get; set; }
        public string LockedAmount { get; set; }
        public string TotalStakedCPU { get; set; }
        public string TotalStakedNetwork { get; set; }
        public string SelfStakedCPU { get; set; }
        public string SelfStakedNetwork { get; set; }
        public string PendingRefundCPU { get; set; }
        public string PendingRefundNetwork { get; set; }
    }
}
