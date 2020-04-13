using PowerManagement.Configuration.PowerManagementStructures;
using System.Runtime.InteropServices;

namespace PowerManagementCOM
{
    [ComVisible(true)]
    [Guid("1d608944-16d9-4949-a987-20a3424651a9")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IPowerManagementComService
    {
        SystemPowerInformation GetSystemPowerInformation();
        SystemBatteryState GetSystemBatteryState();
        int GetLastWakeTime();
        int GetLastSleepTime();
        bool DeleteHibernateFile();
        bool ReserveHibernateFile();
        void SuspendState(bool hibernate, bool force, bool wakeupEventsDisabled);
    }
}