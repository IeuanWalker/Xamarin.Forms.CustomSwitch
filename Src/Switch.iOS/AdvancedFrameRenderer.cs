using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using Switch;
using Switch.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AdvancedFrame), typeof(AdvancedFrameRenderer))]
namespace Switch.iOS
{
    public class AdvancedFrameRenderer : FrameRenderer
    {
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            UpdateCornerRadius();
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

        // A very basic way of retrieving same one value for all of the corners
        private double RetrieveCommonCornerRadius(CornerRadius cornerRadius)
        {
            double commonCornerRadius = cornerRadius.TopLeft;
            if (commonCornerRadius <= 0)
            {
                commonCornerRadius = cornerRadius.TopRight;
                if (commonCornerRadius <= 0)
                {
                    commonCornerRadius = cornerRadius.BottomLeft;
                    if (commonCornerRadius <= 0)
                    {
                        commonCornerRadius = cornerRadius.BottomRight;
                    }
                }
            }

            return commonCornerRadius;
        }

        private UIRectCorner RetrieveRoundedCorners(CornerRadius cornerRadius)
        {
            UIRectCorner roundedCorners = default;

            if (cornerRadius.TopLeft > 0)
            {
                roundedCorners |= UIRectCorner.TopLeft;
            }

            if (cornerRadius.TopRight > 0)
            {
                roundedCorners |= UIRectCorner.TopRight;
            }

            if (cornerRadius.BottomLeft > 0)
            {
                roundedCorners |= UIRectCorner.BottomLeft;
            }

            if (cornerRadius.BottomRight > 0)
            {
                roundedCorners |= UIRectCorner.BottomRight;
            }

            return roundedCorners;
        }

        private void UpdateCornerRadius()
        {
            CornerRadius? cornerRadius = (Element as AdvancedFrame)?.CornerRadius;
            if (!cornerRadius.HasValue)
            {
                return;
            }

            double roundedCornerRadius = RetrieveCommonCornerRadius(cornerRadius.Value);
            if (roundedCornerRadius <= 0)
            {
                return;
            }

            UIRectCorner roundedCorners = RetrieveRoundedCorners(cornerRadius.Value);

            UIBezierPath path = UIBezierPath.FromRoundedRect(Bounds, roundedCorners, new CGSize(roundedCornerRadius, roundedCornerRadius));
            CAShapeLayer mask = new CAShapeLayer { Path = path.CGPath };
            NativeView.Layer.Mask = mask;
        }
    }
}