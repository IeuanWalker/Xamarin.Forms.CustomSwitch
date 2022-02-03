namespace Switch
{
    public class AdvancedFrame : Frame
    {
        public new static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(AdvancedFrame), typeof(CornerRadius), typeof(AdvancedFrame));

        public AdvancedFrame()
        {
            // MK Clearing default values (e.g. on iOS it's 5)
            base.CornerRadius = 0;
        }

        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
