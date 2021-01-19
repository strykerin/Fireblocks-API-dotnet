using System.Text.Json.Serialization;

namespace Fireblocks.Entities
{
    public class DropTransaction
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FeeLevel { get; set; }
    }
}
