using RGB.NET.Core;
using System.Collections.Generic;

namespace Hex3l.RGB.NET.Devices.NZXT.Generic
{
    public class NZXTDeviceUpdateQueue : UpdateQueue
    {
        #region Properties & Fields

        private int _deviceID;

        #endregion

        #region Constructors

        public NZXTDeviceUpdateQueue(IDeviceUpdateTrigger updateTrigger, int deviceID)
            : base(updateTrigger)
        {
            this._deviceID = deviceID;
        }

        #endregion

        #region Methods

        protected override void Update(Dictionary<object, Color> dataSet)
        {
            foreach (KeyValuePair<object, Color> data in dataSet)
            {

            }
        }

        #endregion
    }
}
