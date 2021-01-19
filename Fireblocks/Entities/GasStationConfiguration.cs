namespace Fireblocks.Entities
{
    public class GasStationConfiguration
    {
        /// <summary>
        /// Below this ETH balane the address will be funded up until gasCap value, in ETH units
        /// </summary>
        public string GasThreshold { get; set; }

        /// <summary>
        /// Up to this level the address will be funded with ETH, in ETH units
        /// </summary>
        public string GasCap { get; set; }

        /// <summary>
        /// The funding transaction will be sent with this maximum value gas price, in Gwei units
        /// </summary>
        public string MaxGasPrice { get; set; }
    }
}
