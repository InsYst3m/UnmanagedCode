using PowerManagement.Configuration;
using PowerManagement.Configuration.Enums;
using PowerManagement.Configuration.PowerManagementStructures;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace PowerManagement
{
    public class PowerManagementService
    {
        public SystemBatteryState GetSystemBatteryState()
        {
            var result = PowerManagementConfiguration.CallNtPowerInformation(PowerInformationLevel.SystemBatteryState,
                IntPtr.Zero, 0, out SystemBatteryState state, Marshal.SizeOf<SystemBatteryState>());

            return result == PowerInformationStatus.Success
                ? state
                : throw new Win32Exception("Something went wrong.");
        }

        public SystemPowerInformation GetSystemPowerInformation()
        {
            var result = PowerManagementConfiguration.CallNtPowerInformation(PowerInformationLevel.SystemPowerInformation,
                IntPtr.Zero, 0, out SystemPowerInformation info, Marshal.SizeOf<SystemPowerInformation>());

            return result == PowerInformationStatus.Success
                ? info
                : throw new Win32Exception("Something went wrong.");
        }

        public int GetLastSleepTime()
        {
            return GetSleepOrWakeTime(PowerInformationLevel.LastSleepTime);
        }

        public int GetLastWakeTime()
        {
            return GetSleepOrWakeTime(PowerInformationLevel.LastWakeTime);
        }

        public bool ReserveHibernateFile()
        {
            return HibernateFile(HibernateFileActions.Reserve);
        }

        public bool DeleteHibernateFile()
        {
            return HibernateFile(HibernateFileActions.Delete);
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/powrprof/nf-powrprof-setsuspendstate
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, call GetLastError.
        /// </summary>
        /// <param name="hibernate">If this parameter is TRUE, the system hibernates. If the parameter is FALSE, the system is suspended.</param>
        /// <param name="force">This parameter has no effect.</param>
        /// <param name="wakeupEventsDisabled">If this parameter is TRUE, the system disables all wake events. If the parameter is FALSE, any system wake events remain enabled.</param>
        public void SuspendState(bool hibernate, bool force, bool wakeupEventsDisabled)
        {
            var result = PowerManagementConfiguration.SetSuspendState(hibernate, force, wakeupEventsDisabled);

            if (result == 0)
                throw new Win32Exception("Something went wrong.");
        }

        #region Private methods

        private int GetSleepOrWakeTime(PowerInformationLevel informationLevel)
        {
            var result = PowerManagementConfiguration.CallNtPowerInformation(informationLevel, IntPtr.Zero, 0,
                out long time, Marshal.SizeOf<long>());

            var dateTime = new DateTime(2020, 4, 13, 0, 0, 0);

            return result == PowerInformationStatus.Success
                ? dateTime.AddTicks(time / 100).Second
                : throw new Win32Exception("Something went wrong.");
        }

        private bool HibernateFile(HibernateFileActions action)
        {
            var boolSize = Marshal.SizeOf<bool>();
            IntPtr intPtr = Marshal.AllocCoTaskMem(boolSize);
            Marshal.WriteByte(intPtr, (byte)action);

            var result = PowerManagementConfiguration.CallNtPowerInformation(PowerInformationLevel.SystemReserveHiberFile,
                intPtr,
                boolSize,
                IntPtr.Zero,
                0);

            return result == PowerInformationStatus.Success;
        }

        #endregion

    }
}
