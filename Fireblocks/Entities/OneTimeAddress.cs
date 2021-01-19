namespace Fireblocks.Entities
{
    public class OneTimeAddress
    {
        /// <summary>
        /// Transfer destination address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Transfer destination tag (for Ripple, 'memo' for EOS/XLM), for SEN/Signet used as Bank Transfer Description
        /// </summary>
        public string Tag { get; set; }
    }
}