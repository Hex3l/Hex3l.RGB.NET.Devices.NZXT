using System;

namespace Hex3l.RGB.NET.Devices.NZXT.Native
{
    class NZXTSharpHandler
    {
        private static NZXTSharpHandler _instance;
        public static NZXTSharpHandler Instance => _instance ?? new NZXTSharpHandler();

        public NZXTSharp.HuePlus.HuePlus huePlus;

        public bool initHuePlus()
        {
            NZXTSharp.HuePlus.HuePlus hue = new NZXTSharp.HuePlus.HuePlus();
            if(hue.ID != null)
            {
                huePlus = hue;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
