using System.ComponentModel;
using Android.Content;
using Android.Views.Accessibility;
using Android.Widget;
using Java.Lang;
using Switch.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Switch.CustomSwitch), typeof(CustomSwitchRenderer))]

namespace Switch.Android
{
    public class CustomSwitchRenderer : VisualElementRenderer<ContentView>, ICheckable
    {
        public CustomSwitchRenderer(Context context) : base(context)
        {
        }

        /// <inheritdoc />
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals(nameof(CustomSwitch.IsToggled)))
            {
                Toggle();
            }
        }

        /// <inheritdoc />
        public override void OnInitializeAccessibilityEvent(AccessibilityEvent? e)
        {
            if (e != null)
            {
                e.Checked = Checked;
            }

            base.OnInitializeAccessibilityEvent(e);

        }

        /// <inheritdoc />
        public override void OnInitializeAccessibilityNodeInfo(AccessibilityNodeInfo? info)
        {
            if (info != null)
            {
                info.Checkable = true;
                info.Checked = Checked;
            }

            base.OnInitializeAccessibilityNodeInfo(info);
        }


        /// <inheritdoc />
        public void Toggle()
        {
            Checked = !Checked;
        }

        /// <inheritdoc />
        public bool Checked { get; set; }
    }
}