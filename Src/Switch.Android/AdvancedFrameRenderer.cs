
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Switch;
using Switch.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FrameRenderer = Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer;

[assembly: ExportRenderer(typeof(AdvancedFrame), typeof(AdvancedFrameRenderer))]
namespace Switch.Droid
{
    public class AdvancedFrameRenderer : FrameRenderer
    {
        public AdvancedFrameRenderer(Context context)
            : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && Control != null)
            {
                UpdateCornerRadius();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(AdvancedFrame.CornerRadius) ||
                e.PropertyName == nameof(AdvancedFrame))
            {
                UpdateCornerRadius();
            }
        }

        private void UpdateCornerRadius()
        {
            if (Control.Background is GradientDrawable backgroundGradient)
            {
                CornerRadius? cornerRadius = (Element as AdvancedFrame)?.CornerRadius;
                if (!cornerRadius.HasValue)
                {
                    return;
                }

                float topLeftCorner = Context.ToPixels(cornerRadius.Value.TopLeft);
                float topRightCorner = Context.ToPixels(cornerRadius.Value.TopRight);
                float bottomLeftCorner = Context.ToPixels(cornerRadius.Value.BottomLeft);
                float bottomRightCorner = Context.ToPixels(cornerRadius.Value.BottomRight);

                float[] cornerRadii = {
                    topLeftCorner,
                    topLeftCorner,

                    topRightCorner,
                    topRightCorner,

                    bottomRightCorner,
                    bottomRightCorner,

                    bottomLeftCorner,
                    bottomLeftCorner,
                };

                backgroundGradient.SetCornerRadii(cornerRadii);
            }
        }
    }
}