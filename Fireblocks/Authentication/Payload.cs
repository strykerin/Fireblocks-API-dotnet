namespace Fireblocks.Authentication
{
    public class Payload
    {
        public string nameId { get; set; }
        public long nbf { get; set; }
        public long exp { get; set; }
        public long iat { get; set; }
        public string iss { get; set; }
        public string aud { get; set; }
    }
}
