using RGB.NET.Core;
using System;

namespace Hex3l.RGB.NET.Devices.NZXT.Generic
{
    public class NZXTRGBDeviceInfo : IRGBDeviceInfo 
    {
        #region Properties & Fields
        public RGBDeviceType DeviceType { get; }

        public int DeviceID { get; }

        public string DeviceName { get; }

        public string Manufacturer { get; }

        public string Model { get; }

        public Uri Image { get; set; }

        public bool SupportsSyncBack => false;

        public RGBDeviceLighting Lighting => RGBDeviceLighting.Key;

        #endregion

        #region Constructors

        internal NZXTRGBDeviceInfo(RGBDeviceType deviceType, int deviceID, string manufacturer = "NZXT", string model = "Generic")
        {
            this.DeviceType = deviceType;
            this.DeviceID = deviceID;
            this.Manufacturer = manufacturer;
            this.Model = model;

            DeviceName = $"{Manufacturer} {Model}";
        }

        #endregion
    }
}
