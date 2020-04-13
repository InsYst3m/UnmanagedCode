using PowerManagement.Configuration;
using PowerManagement.Configuration.PowerManagementStructures;
using System;
using System.Runtime.InteropServices;

namespace PowerManagement
{
    public class PowerManagementService
    {
        public SystemBatteryState GetSystemBatteryState()
        {
            PowerManagementConfiguration.CallNtPowerInformation(PowerInformationLevel.SystemBatteryState,
                IntPtr.Zero, 0, out SystemBatteryState state, Marshal.SizeOf(typeof(SystemBatteryState)));

            return state;
        }

        public SystemPowerInformation GetSystemPowerInformation()
        {
            PowerManagementConfiguration.CallNtPowerInformation(PowerInformationLevel.SystemPowerInformation,
                IntPtr.Zero, 0, out SystemPowerInformation info, Marshal.SizeOf(typeof(SystemPowerInformation)));

            return info;
        }
    }
}
