using System;
using System.Collections.Generic;
using System.Text;

namespace EwelinkNet.Classes.Events
{
    public class EventWebsocketMessage : EventArgs
    {

        public object Message { get; set; }
    }
}
