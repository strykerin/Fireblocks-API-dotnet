using System.Collections.Generic;

namespace Fireblocks.Entities
{
    public class VaultAccount
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool HiddenOnUI { get; set; }
        public string CustomerRefId { get; set; }
        public bool AutoFuel { get; set; }
        public List<VaultAsset> Assets { get; set; }
    }
}
