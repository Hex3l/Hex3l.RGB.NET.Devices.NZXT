using RGB.NET.Core;
using Hex3l.RGB.NET.Devices.NZXT.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Hex3l.RGB.NET.Devices.NZXT.Native;
using Hex3l.RGB.NET.Devices.NZXT.HuePlus;

namespace Hex3l.RGB.NET.Devices.NZXT
{
    public class NZXTDeviceProvider : IRGBDeviceProvider
    {
        #region Properties & Fields

        private static NZXTDeviceProvider _instance;
        public static NZXTDeviceProvider Instance => _instance ?? new NZXTDeviceProvider();

        public bool IsInitialized { get; private set; }

        public bool HasExclusiveAccess { get; private set; }

        public IEnumerable<IRGBDevice> Devices { get; private set; }

        public Func<CultureInfo> GetCulture { get; set; } = CultureHelper.GetCurrentCulture;

        public DeviceUpdateTrigger UpdateTrigger { get; }

        #endregion

        #region Constructors

        public NZXTDeviceProvider()
        {
            if (_instance != null) throw new InvalidOperationException($"There can be only one instance of type {nameof(NZXTDeviceProvider)}");
            _instance = this;

            UpdateTrigger = new DeviceUpdateTrigger();
        }

        #endregion

        #region Methods

        public bool Initialize(RGBDeviceType loadFilter = RGBDeviceType.All, bool exclusiveAccessIfPossible = false, bool throwExceptions = false)
        {
            IsInitialized = false;

            try
            {
                UpdateTrigger?.Stop();

                NZXTSharpHandler handler = NZXTSharpHandler.Instance;

                IList<IRGBDevice> devices = new List<IRGBDevice>();

                if (handler.initHuePlus()) {
                    NZXTSharp.HuePlus.HuePlus hue = handler.huePlus;
                    NZXTDeviceUpdateQueue updateQueue = new HuePlusDeviceUpdateQueue(UpdateTrigger, hue.ID, hue.Channel1);
                    INZXTRGBDevice device = new HuePlusNZXTRGBDevice(new NZXTRGBDeviceInfo(RGBDeviceType.LedStripe, hue.ID, null, "HuePlus Channel 1"));
                    device.Initialize(updateQueue, hue.Channel1.ChannelInfo.NumLeds);

                    devices.Add(device);

                    updateQueue = new HuePlusDeviceUpdateQueue(UpdateTrigger, hue.ID, hue.Channel2);
                    device = new HuePlusNZXTRGBDevice(new NZXTRGBDeviceInfo(RGBDeviceType.LedStripe, hue.ID, null, "HuePlus Channel 2"));
                    device.Initialize(updateQueue, hue.Channel2.ChannelInfo.NumLeds);

                    devices.Add(device);
                }

                UpdateTrigger?.Start();

                Devices = new ReadOnlyCollection<IRGBDevice>(devices);
                IsInitialized = true;
            }
            catch
            {
                if (throwExceptions)
                    throw;
                return false;
            }

            return true;
        }

        public void ResetDevices()
        {
            //TODO: Implement
        }

        public void Dispose()
        { }

        #endregion
    }
}
