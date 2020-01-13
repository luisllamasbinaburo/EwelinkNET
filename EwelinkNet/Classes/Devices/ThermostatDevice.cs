using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace EwelinkNet.Classes
{
    public class ThermostatDevice : SwitchDevice
    {

        public string GetTemperature() => @params.currentTemperature;

        public string GetHumidity() => @params.currentHumidity;

    }
}
