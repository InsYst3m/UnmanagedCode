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

        public int GetLastSleepTime()
        {
            PowerManagementConfiguration.CallNtPowerInformation(PowerInformationLevel.LastSleepTime,
                IntPtr.Zero, 0, out long time, Marshal.SizeOf(typeof(long)));

            var dateTime = new DateTime(2020, 4, 13, 0, 0, 0);

            return dateTime.AddTicks(time / 100).Second;
        }

        public int GetLastWakeTime()
        {
            PowerManagementConfiguration.CallNtPowerInformation(PowerInformationLevel.LastWakeTime,
                IntPtr.Zero, 0, out long time, Marshal.SizeOf(typeof(long)));

            var dateTime = new DateTime(2020, 4, 13, 0, 0, 0);

            return dateTime.AddTicks(time / 100).Second;
        }
    }
}
