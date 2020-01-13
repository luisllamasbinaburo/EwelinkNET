namespace EwelinkNet.Classes
{
    public partial class MultiChannelDevice
    {
        public class OutletState
        {
            public OutletState(int outlet, string @switch)
            {
                this.outlet = outlet;
                this.@switch = @switch;
            }

            public int outlet { get; set; }
            public string @switch { get; set; }
        }
    }
}
