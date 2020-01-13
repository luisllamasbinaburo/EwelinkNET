using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EwelinkNet.Classes
{
    internal static class DeviceFactory
    {
        internal static Device CreateDevice(Ewelink context, Device device)
        {
            var newDevice = CreateDeviceByDeviceName(device.deviceName);

            device.Adapt(newDevice);
            newDevice.context = context;

            return newDevice;
        }

        private static Device CreateDeviceByDeviceName(string deviceName)
        {
            Device newDevice = null;

            if (deviceName != null)
            {
                switch (deviceName)
                {
                    case "SOCKET": newDevice = new SwitchDevice(); break;
                    case "SOCKET_2": newDevice = new MultiSwitchDevice(); break;
                    case "SOCKET_3": newDevice = new MultiSwitchDevice(); break;
                    case "SOCKET_4": newDevice = new MultiSwitchDevice(); break;
                    case "SOCKET_POWER": newDevice = new SwitchDevice(); break;
                    case "SWITCH": newDevice = new SwitchDevice(); break;
                    case "SWITCH_2": newDevice = new MultiSwitchDevice(); break;
                    case "SWITCH_3": newDevice = new MultiSwitchDevice(); break;
                    case "SWITCH_4": newDevice = new MultiSwitchDevice(); break;
                    case "OSPF": newDevice = new SwitchDevice(); break;
                    case "CURTAIN": newDevice = new CurtainDevice(); break;
                    case "EW-RE": newDevice = new SwitchDevice(); break;
                    case "FIREPLACE": newDevice = new SwitchDevice(); break;
                    case "SWITCH_CHANGE": newDevice = new SwitchDevice(); break;
                    case "THERMOSTAT": newDevice = new ThermostatDevice(); break;
                    case "COLD_WARM_LED": newDevice = new SwitchDevice(); break;
                    case "THREE_GEAR_FAN": newDevice = new SwitchDevice(); break;
                    case "SENSORS_CENTER": newDevice = new SwitchDevice(); break;
                    case "HUMIDIFIER": newDevice = new SwitchDevice(); break;
                    case "RGB_BALL_LIGHT": newDevice = new SwitchDevice(); break;
                    case "NEST_THERMOSTAT": newDevice = new ThermostatDevice(); break;
                    case "GSM_SOCKET": newDevice = new SwitchDevice(); break;
                    case "AROMATHERAPY": newDevice = new SwitchDevice(); break;
                    case "BJ_THERMOSTAT": newDevice = new ThermostatDevice(); break;
                    case "GSM_UNLIMIT_SOCKET": newDevice = new SwitchDevice(); break;
                    case "RF_BRIDGE": newDevice = new RfBridgeDevice(); break;
                    case "GSM_SOCKET_2": newDevice = new MultiSwitchDevice(); break;
                    case "GSM_SOCKET_3": newDevice = new MultiSwitchDevice(); break;
                    case "GSM_SOCKET_4": newDevice = new MultiSwitchDevice(); break;
                    case "POWER_DETECTION_SOCKET": newDevice = new SwitchDevice(); break;
                    case "LIGHT_BELT": newDevice = new SwitchDevice(); break;
                    case "FAN_LIGHT": newDevice = new SwitchDevice(); break;
                    case "EZVIZ_CAMERA": newDevice = new SwitchDevice(); break;
                    case "SINGLE_CHANNEL_DIMMER_SWITCH": newDevice = new SwitchDevice(); break;
                    case "HOME_KIT_BRIDGE":  newDevice = new SwitchDevice(); break;
                    case "FUJIN_OPS": newDevice = new SwitchDevice(); break;
                    case "CUN_YOU_DOOR": newDevice = new SwitchDevice(); break;
                    case "SMART_BEDSIDE_AND_NEW_RGB_BALL_LIGHT": newDevice = new SwitchDevice(); break;
                    case "DOWN_CEILING_LIGHT": newDevice = new SwitchDevice(); break;
                    case "AIR_CLEANER": newDevice = new SwitchDevice(); break;
                    case "MACHINE_BED": newDevice = new SwitchDevice(); break;
                    case "COLD_WARM_DESK_LIGHT": newDevice = new SwitchDevice(); break;
                    case "DOUBLE_COLOR_DEMO_LIGHT": newDevice = new SwitchDevice(); break;
                    case "ELECTRIC_FAN_WITH_LAMP": newDevice = new SwitchDevice(); break;
                    case "SWEEPING_ROBOT": newDevice = new SwitchDevice(); break;
                    case "RGB_BALL_LIGHT_4": newDevice = new SwitchDevice(); break;
                    case "MONOCHROMATIC_BALL_LIGHT": newDevice = new SwitchDevice(); break;
                    case "MEARICAMERA": newDevice = new SwitchDevice(); break;
                    case "BLADELESS_FAN": newDevice = new SwitchDevice(); break;
                    case "NEW_HUMIDIFIER": newDevice = new SwitchDevice(); break;
                    case "WARM_AIR_BLOWER": newDevice = new SwitchDevice(); break;
                }
            }

            if (newDevice == null) newDevice = new Device();
            return newDevice;
        }


        private static Device CreateDeviceBySwitchName(string deviceName)
        {
            Device newDevice = null;

            var switchName = Constants.DevicesSwitchName.GetDeviceSwitchByName(deviceName);

            if (switchName != null)
            {
                switch (switchName)
                {
                    case "switch": newDevice = new SwitchDevice(); break;
                    case "switches": newDevice = new MultiSwitchDevice(); break;
                    case "state":
                    case "fan":
                    case "lock":
                    case "key": newDevice = new SwitchDevice(); break;

                }
            }

            if (newDevice == null) newDevice = new Device();
            return newDevice;
        }

    }
}
