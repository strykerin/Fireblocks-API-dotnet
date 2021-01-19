namespace Fireblocks.Entities
{
    public class CallbackResponse
    {
        /// <summary>
        /// [APPROVE, REJECT, IGNORE]
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Free text of the rejection reason for logging purposes
        /// </summary>
        public string RejectionReason { get; set; }
    }
}
