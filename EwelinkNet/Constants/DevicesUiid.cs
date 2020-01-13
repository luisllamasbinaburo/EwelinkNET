using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EwelinkNet.Constants
{
    internal static class DevicesUiid
    {
        private static readonly List<(string? name, int? uuid)> data = new List<(string? name, int? uuid)>
        {
            ("SOCKET", 1),
            ("SOCKET_2", 2),
            ("SOCKET_3", 3),
            ("SOCKET_4", 4),
            ("SOCKET_POWER", 5),
            ("SWITCH", 6),
            ("SWITCH_2", 7),
            ("SWITCH_3", 8),
            ("SWITCH_4", 9),
            ("OSPF", 10),
            ("CURTAIN", 11),
            ("EW-RE", 12),
            ("FIREPLACE", 13),
            ("SWITCH_CHANGE", 14),
            ("THERMOSTAT", 15),
            ("COLD_WARM_LED", 16),
            ("THREE_GEAR_FAN", 17),
            ("SENSORS_CENTER", 18),
            ("HUMIDIFIER", 19),
            ("RGB_BALL_LIGHT", 22),
            ("NEST_THERMOSTAT", 23),
            ("GSM_SOCKET", 24),
            ("AROMATHERAPY", 25),
            ("BJ_THERMOSTAT", 26),
            ("GSM_UNLIMIT_SOCKET", 27),
            ("RF_BRIDGE", 28),
            ("GSM_SOCKET_2", 29),
            ("GSM_SOCKET_3", 30),
            ("GSM_SOCKET_4", 31),
            ("POWER_DETECTION_SOCKET", 32),
            ("LIGHT_BELT", 33),
            ("FAN_LIGHT", 34),
            ("EZVIZ_CAMERA", 35),
            ("SINGLE_CHANNEL_DIMMER_SWITCH", 36),
            ("HOME_KIT_BRIDGE", 38),
            ("FUJIN_OPS", 40),
            ("CUN_YOU_DOOR", 41),
            ("SMART_BEDSIDE_AND_NEW_RGB_BALL_LIGHT", 42),
            ("", 43),
            ("", 44),
            ("DOWN_CEILING_LIGHT", 45),
            ("AIR_CLEANER", 46),
            ("MACHINE_BED", 49),
            ("COLD_WARM_DESK_LIGHT", 51),
            ("DOUBLE_COLOR_DEMO_LIGHT", 52),
            ("ELECTRIC_FAN_WITH_LAMP", 53),
            ("SWEEPING_ROBOT", 55),
            ("RGB_BALL_LIGHT_4", 56),
            ("MONOCHROMATIC_BALL_LIGHT", 57),
            ("MEARICAMERA", 59),
            ("BLADELESS_FAN", 1001),
            ("NEW_HUMIDIFIER", 1002),
            ("WARM_AIR_BLOWER", 1003)
        };


        internal static int? GetDeviceUiidByName(string name) => data.FirstOrDefault(x => x.name == name).uuid;

        internal static string? GetDeviceNameByUiid(int uiid) => data.FirstOrDefault(x => x.uuid == uiid).name;

    }
}