using Hex3l.RGB.NET.Devices.NZXT.Generic;
using NZXTSharp;
using NZXTSharp.HuePlus;
using RGB.NET.Core;
using System.Collections.Generic;

namespace Hex3l.RGB.NET.Devices.NZXT.HuePlus
{
    public class HuePlusDeviceUpdateQueue : NZXTDeviceUpdateQueue
    {
        #region Properties & Fields

        private HuePlusChannel _hueChannel;

        #endregion

        #region Constructors

        public HuePlusDeviceUpdateQueue(IDeviceUpdateTrigger updateTrigger, int deviceID, HuePlusChannel channel)
            : base(updateTrigger, deviceID)
        {
            this._hueChannel = channel;
        }

        #endregion

        #region Methods

        protected override void Update(Dictionary<object, global::RGB.NET.Core.Color> dataSet)
        {
            byte[] colors = new byte[_hueChannel.ChannelInfo.NumLeds*3];
            foreach (KeyValuePair<object, global::RGB.NET.Core.Color> data in dataSet)
            {
                int index = (((int)data.Key) * 3);

                colors[index] = data.Value.GetG();
                colors[index + 1] = data.Value.GetR();
                colors[index + 2] = data.Value.GetB();
            }

            Fixed effect = new Fixed(colors); // Create Effect
            _hueChannel.Parent.ApplyEffect(_hueChannel, effect);
        }

        #endregion
    }
}
