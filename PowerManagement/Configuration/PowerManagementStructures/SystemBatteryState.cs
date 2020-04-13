namespace PowerManagement.Configuration.PowerManagementStructures
{
    public struct SystemBatteryState
    {
        public bool AcOnLine;
        public bool BatteryPresent;
        public bool Charging;
        public bool Discharging;
        public bool Spare1;
        public byte Tag;
        public uint MaxCapacity;
        public uint RemainingCapacity;
        public uint Rate;
        public uint EstimatedTime;
        public uint DefaultAlert1;
        public uint DefaultAlert2;
    }

    //typedef struct {
    //  BOOLEAN AcOnLine;
    //  BOOLEAN BatteryPresent;
    //  BOOLEAN Charging;
    //  BOOLEAN Discharging;
    //  BOOLEAN Spare1[3];
    //  BYTE    Tag;
    //  DWORD   MaxCapacity;
    //  DWORD   RemainingCapacity;
    //  DWORD   Rate;
    //  DWORD   EstimatedTime;
    //  DWORD   DefaultAlert1;
    //  DWORD   DefaultAlert2;
    //} SYSTEM_BATTERY_STATE, *PSYSTEM_BATTERY_STATE;
}
