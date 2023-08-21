# EwelinkNET

EwelinkNET is an API writen in .NET Standard to interact directly with eWeLink API using your regular credentials.
Compatible with Windows, Linux and MAC.


### Key features
- Set on/off devices
- Read data measurements (humidity, temperature...)
- Listen for devices events (through websockets)
- Work online mode or offline  (a.k.a. LAN mode or Zeroconf)
- Compatible with Windows, Linux and MAC.


## Basic usage

```c#
var ewelink = new Ewelink(Email, Password, Region);
await ewelink.GetCredentials();
await ewelink.GetDevices();

var device = ewelink.Devices.First(x=> x.deviceid == deviceId) as SwitchDevice;
device.TurnOn();
```

### Get Credentials

Use Email, Password and Region to get Ewelink credentials, that includes required information to perform actions.
```c#
var ewelink = new Ewelink(Email, Password, Region);
var credentials = await ewelink.GetCredentials();
```

Alternately, you can save credentials to avoid login.
```c#
ewelink.StoreCredenditalsFromFile();
```

And later restore with,
```c#
ewelink.RestoreCredenditalsFromFile();
```

### Custom API_ID

EwelinkNET uses a hardcoded API_ID and API_SECRET to authenticate. But Ewelink is changing their Auth process. So you can log into official https://dev.ewelink.cc/ and generate your own API_ID and API_SECRET

```c#
var ewelink = new Ewelink(Email, Password, YOUR_API_ID, YOUR_API_SECRET, Region);
var credentials = await ewelink.GetCredentials();
```

### Get Devices

Get Devices registered in you Ewelink account.
```c#
var ewelink = new Ewelink(Email, Password, Region);
await ewelink.GetCredentials();
await ewelink.GetDevices();
```

Devices are converted to one of the following classes.
- SwitchDevice
- MultiSwitchDevice
- ThermostatDevice
- RFBridgeDevice
- CurtainDevice

All of them are derived classes of generic `Device` class.

### Interact with devices

Each class provides there own methods to perform actions or retrieve measurement.
For example, `ThermostatDevice` provides
- TurnOn()
- TurnOff()
- Toggle()
- GetTemperature()
- GetHumidity()

And, `MultiSwitchDevice` provides
- TurnOn()
- TurnOn(int channel)
- TurnOff()
- TurnOff(int channel)

### Listen to device changes

Changes in devices status are obtain through websocket connection, and provided events.
```c#
ewelink.OnDeviceChanged += (s, e) => Console.WriteLine(e.AsJson());
ewelink.OpenWebSocket();
```

Loaded devices states are updated accordly with new state.

### Zeroconf (LAN mode)

It's possible to interact with eWelink devices throught LAN mode, without the need of internet connection or access to eWelink cloud.
- TurnOnLAN()
- TurnOffLAN()

For LAN mode to work, a ArpTable (and list or the Mac - Ip relationship) has to be provided, to allow find the device Ip.
```c#
ewelink.RestoreArpTableFromFile();
```


## Todo
- [x] Get credentials
- [x] Get devices
- [x] Set on/off
- [x] Get measurements
- [x] Websockets listening
- [x] Zeroconf (LAN mode)
- [ ] Add/test more devices
- [ ] Async/sync version
- [ ] Improve documentation/examples
- [ ] Improve tests
