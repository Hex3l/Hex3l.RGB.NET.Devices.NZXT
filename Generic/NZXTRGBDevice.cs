using RGB.NET.Core;
using System.Collections.Generic;
using System.Linq;

namespace Hex3l.RGB.NET.Devices.NZXT.Generic
{
    public abstract class NZXTRGBDevice<TDeviceInfo> : AbstractRGBDevice<TDeviceInfo>, INZXTRGBDevice
         where TDeviceInfo : NZXTRGBDeviceInfo
    {
        #region Properties & Fields

        public override TDeviceInfo DeviceInfo { get; }

        protected NZXTDeviceUpdateQueue DeviceUpdateQueue { get; set; }

        #endregion

        #region Constructors

        protected NZXTRGBDevice(TDeviceInfo info)
        {
            this.DeviceInfo = info;
        }

        #endregion

        #region Methods

        public void Initialize(NZXTDeviceUpdateQueue updateQueue, int ledCount)
        {
            DeviceUpdateQueue = updateQueue;

            InitializeLayout(ledCount);

            if (Size == Size.Invalid)
            {
                Rectangle ledRectangle = new Rectangle(this.Select(x => x.LedRectangle));
                Size = ledRectangle.Size + new Size(ledRectangle.Location.X, ledRectangle.Location.Y);
            }
        }

        protected abstract void InitializeLayout(int ledCount);

        protected override void UpdateLeds(IEnumerable<Led> ledsToUpdate)
            => DeviceUpdateQueue.SetData(ledsToUpdate.Where(x => (x.Color.A > 0) && (x.CustomData is int)));

        #endregion
    }
}
