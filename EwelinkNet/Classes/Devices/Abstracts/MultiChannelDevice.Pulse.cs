namespace EwelinkNet.Classes
{
    public partial class MultiChannelDevice
    {
        public class Pulse
        {
            public Pulse(int outlet, string state, int pulseWidth)
            {
                this.outlet = outlet;
                this.state = state;
                this.pulseWidth = pulseWidth;
            }

            public int outlet { get; set; }
            public string state { get; set; }
            public int pulseWidth { get; set; }
        }
    }
}
