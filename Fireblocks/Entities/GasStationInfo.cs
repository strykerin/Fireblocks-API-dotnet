using System.Collections.Generic;

namespace Fireblocks.Entities
{
    public class GasStationInfo
    {
        /// <summary>
        /// A dictionary of an asset and its balance in the Gas Station
        /// </summary>
        public Dictionary<string, string> Balance { get; set; }

        /// <summary>
        /// The settings of your Gas Station
        /// </summary>
        public GasStationConfiguration Configuration { get; set; }
    }
}
