using PowerManagement.Configuration.PowerManagementStructures;
using System;
using System.Runtime.InteropServices;

namespace PowerManagement.Configuration
{
    internal class PowerManagementConfiguration
    {
        [DllImport("PowrProf.dll")]
        public static extern uint CallNtPowerInformation(
            PowerInformationLevel informationLevel,
            IntPtr inputBuffer,
            int inputBufferSize,
            out SystemBatteryState systemBatteryState,
            int outputBufferSize);
    }
}
