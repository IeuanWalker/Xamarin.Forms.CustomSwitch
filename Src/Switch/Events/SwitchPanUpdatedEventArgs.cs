using Switch.Enums;
using System;

namespace Switch.Events
{
    public class SwitchPanUpdatedEventArgs : EventArgs
    {
        public double xRef { get; set; }
        public bool IsToggled { get; set; }
        public double TranslateX { get; set; }
        public double Percentage { get; set; }
        public PanStatusEnum Status { get; set; }
    }
}
