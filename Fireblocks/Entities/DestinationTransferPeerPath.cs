namespace Fireblocks.Entities
{
    public class DestinationTransferPeerPath : TransferPeerPath
    {
        /// <summary>
        /// Destination address
        /// </summary>
        public OneTimeAddress OneTimeAddress { get; set; }
    }
}
