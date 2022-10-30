using System;
using Android.App;
using Android.Graphics;
using Maui.UserDialogs.Infrastructure;
using Android.Content;
using Color = Android.Graphics.Color;

namespace Maui.UserDialogs
{
    public static class Extensions
    {

        public static Color ToNative(this System.Drawing.Color This) => new Color(This.R, This.G, This.B, This.A);

        public static Bitmap LoadBitmap(string resourceName)
        {
            //new DrawableBitmap(res.GetDrawable(id));
            return null;
        }

        public static void SafeRunOnUi(this Activity activity, Action action) => activity.RunOnUiThread(() =>
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Log.Error("", ex.ToString());
            }
        });


        public static AndroidHUD.MaskType ToNative(this MaskType maskType)
        {
            switch (maskType)
            {
                case MaskType.Black:
                    return AndroidHUD.MaskType.Black;

                case MaskType.Clear:
                    return AndroidHUD.MaskType.Clear;

                case MaskType.Gradient:
                    Console.WriteLine("Warning - Gradient mask type is not supported on android");
                    return AndroidHUD.MaskType.Black;

                case MaskType.None:
                    return AndroidHUD.MaskType.None;

                default:
                    throw new ArgumentException("Invalid Mask Type");
            }
        }

        static int selectableItemBackground = 0;
        public static int GetSelectableItemBackground(Context context)
        {
            if (selectableItemBackground == 0)
            {
                var outValue = new Android.Util.TypedValue();
                context.Theme.ResolveAttribute(Android.Resource.Attribute.SelectableItemBackground, outValue, true);
                selectableItemBackground = outValue.ResourceId;
            }
            return selectableItemBackground;
        }
    }
}