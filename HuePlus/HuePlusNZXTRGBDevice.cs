using RGB.NET.Core;
using Hex3l.RGB.NET.Devices.NZXT.Generic;

namespace Hex3l.RGB.NET.Devices.NZXT.HuePlus
{
    public class HuePlusNZXTRGBDevice : NZXTRGBDevice<NZXTRGBDeviceInfo>
    {
        #region Constructors

        internal HuePlusNZXTRGBDevice(NZXTRGBDeviceInfo info)
            : base(info)
        { }

        #endregion

        #region Methods
        protected override void InitializeLayout(int ledCount)
        {
            for (int i = 0; i < ledCount; i++)
            {
                InitializeLed(LedId.LedStripe1 + i, new Rectangle(i * 20, 0, 20, 20));
            }

            //TODO DarthAffe 07.10.2017: We don't know the model, how to save layouts and images?
            ApplyLayoutFromFile(PathHelper.GetAbsolutePath($@"Layouts\NZXT\HuePlus\{DeviceInfo.Model.Replace(" ", string.Empty).ToUpper()}.xml"), null);
        }

        protected override object CreateLedCustomData(LedId ledId) => (int)ledId - (int)LedId.LedStripe1;

        public override void SyncBack()
        { }

        #endregion
    }
}
