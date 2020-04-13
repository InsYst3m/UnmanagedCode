using PowerManagement.Configuration.Enums;
using PowerManagement.Configuration.PowerManagementStructures;
using System;
using System.Runtime.InteropServices;

namespace PowerManagement.Configuration
{
    internal class PowerManagementConfiguration
    {
        [DllImport("PowrProf.dll")]
        public static extern PowerInformationStatus CallNtPowerInformation(
            PowerInformationLevel informationLevel,
            IntPtr inputBuffer,
            int inputBufferSize,
            out SystemBatteryState systemBatteryState,
            int outputBufferSize);

        [DllImport("PowrProf.dll")]
        public static extern PowerInformationStatus CallNtPowerInformation(
            PowerInformationLevel informationLevel,
            IntPtr inputBuffer,
            int inputBufferSize,
            out SystemPowerInformation systemBatteryState,
            int outputBufferSize);

        [DllImport("PowrProf.dll")]
        public static extern PowerInformationStatus CallNtPowerInformation(
            PowerInformationLevel informationLevel,
            IntPtr inputBuffer,
            int inputBufferSize,
            out long time,
            int outputBufferSize);

        [DllImport("PowrProf.dll")]
        public static extern PowerInformationStatus CallNtPowerInformation(
            PowerInformationLevel informationLevel,
            IntPtr inputBuffer,
            int inputBufferSize,
            IntPtr outputBuffer,
            uint outputBufferSize);

        [DllImport("PowrProf.dll", SetLastError = true)]
        public static extern uint SetSuspendState(
            bool Hibernate,
            bool Force,
            bool WakeupEventsDisabled
        );
    }
}
