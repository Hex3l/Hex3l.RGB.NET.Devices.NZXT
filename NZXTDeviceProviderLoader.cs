using RGB.NET.Core;

namespace Hex3l.RGB.NET.Devices.NZXT
{
    public class NZXTDeviceProviderLoader : IRGBDeviceProviderLoader
    {
        #region Properties & Fields

        public bool RequiresInitialization => false;

        #endregion

        #region Methods

        public IRGBDeviceProvider GetDeviceProvider() => NZXTDeviceProvider.Instance;

        #endregion
    }
}
