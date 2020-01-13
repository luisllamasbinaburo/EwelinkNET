# EwelinkNET

EwelinkNET is an API writen in .NET Standard to interact directly with eWeLink API using your regular credentials.
Compatible with Windows, Linux and MAC.


## Key features
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
var ewelink = new Ewelink(Email, Password, Region);
var credentials = await ewelink.GetCredentials();
```

And later restore with
```c#
ewelink.RestoreCredenditalsFromFile();
```

### Get Devices
```c#
var ewelink = new Ewelink(Email, Password, Region);
await ewelink.GetCredentials();
await ewelink.GetDevices();
```



## Todo
- [x] Get credentials
- [x] Get devices
- [x] Set on/off
- [x] Get measurements
- [x] Websockets listening
- [x] Zeroconf (LAN mode)
- [ ] Add more devices
- [ ] Improve tests
