namespace PowerManagement.Configuration.PowerManagementStructures
{
    public struct SystemPowerInformation
    {
        public uint MaxIdlenessAllowed;
        public uint Idleness;
        public uint TimeRemaining;
        public byte CoolingMode;
    }

    //typedef struct _SYSTEM_POWER_INFORMATION
    //{
    //    ULONG MaxIdlenessAllowed;
    //    ULONG Idleness;
    //    ULONG TimeRemaining;
    //    UCHAR CoolingMode;
    //}
    //SYSTEM_POWER_INFORMATION, * PSYSTEM_POWER_INFORMATION;
}
