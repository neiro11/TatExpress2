using Android.Content;
using Android.Graphics.Drawables;
using TatExpress2;
using TatExpress2.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace TatExpress2.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Remove the underline from the Entry control
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}
