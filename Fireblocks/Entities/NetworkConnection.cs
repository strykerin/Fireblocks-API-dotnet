namespace Fireblocks.Entities
{
    public class NetworkConnection
    {
        public string Id { get; set; }
        public Channel LocalChannel { get; set; }
        public Channel RemoteChannel { get; set; }
    }
}
