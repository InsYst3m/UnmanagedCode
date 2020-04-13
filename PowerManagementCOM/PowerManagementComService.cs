using PowerManagement;
using PowerManagement.Configuration.PowerManagementStructures;
using System;
using System.Runtime.InteropServices;

namespace PowerManagementCOM
{
    [ComVisible(true)]
    [Guid("3d9921b2-36ec-42ff-b024-64c711fbf25b")]
    [ClassInterface(ClassInterfaceType.None)]
    public class PowerManagementComService : IPowerManagementComService
    {
        private PowerManagementService _service;

        public PowerManagementComService()
        {
            _service = new PowerManagementService();
        }

        public SystemPowerInformation GetSystemPowerInformation()
        {
            return _service.GetSystemPowerInformation();
        }

        public SystemBatteryState GetSystemBatteryState()
        {
            return _service.GetSystemBatteryState();
        }

        public int GetLastWakeTime()
        {
            return _service.GetLastWakeTime();
        }

        public int GetLastSleepTime()
        {
            return _service.GetLastSleepTime();
        }

        public bool DeleteHibernateFile()
        {
            return _service.DeleteHibernateFile();
        }

        public bool ReserveHibernateFile()
        {
            return _service.ReserveHibernateFile();
        }

        public void SuspendState(bool hibernate, bool force, bool wakeupEventsDisabled)
        {
            _service.SuspendState(hibernate, force, wakeupEventsDisabled);
        }
    }
}
