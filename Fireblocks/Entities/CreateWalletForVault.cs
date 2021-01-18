using System.Text.Json.Serialization;

namespace Fireblocks.Entities
{
    public class CreateWalletForVault
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string EosAccountName { get; set; }
    }
}
