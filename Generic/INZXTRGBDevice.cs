using RGB.NET.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hex3l.RGB.NET.Devices.NZXT.Generic
{
    interface INZXTRGBDevice : IRGBDevice
    {
        void Initialize(NZXTDeviceUpdateQueue updateQueue, int ledCount);
    }
}
