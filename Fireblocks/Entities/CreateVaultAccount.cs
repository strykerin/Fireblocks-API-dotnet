using System.Text.Json.Serialization;

namespace Fireblocks.Entities
{
    public class CreateVaultAccount
    {
        public CreateVaultAccount(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public bool HiddenOnUI { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CustomerRefId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AutoFuel { get; set; }
    }
}
