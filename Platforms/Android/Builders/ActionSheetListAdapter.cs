using Maui.UserDialogs.Infrastructure;
using Android.Content;
using Android.Views;
using Android.Widget;
using View = Android.Views.View;

namespace Maui.UserDialogs.Builders
{
    public class ActionSheetListAdapter : ArrayAdapter<ActionSheetOption>
    {
        readonly ActionSheetConfig config;
        public bool AddMarginForImage { get; set; } = true;


        public ActionSheetListAdapter(Context context, int resource, int textViewResourceId, ActionSheetConfig config) : base(context, resource, textViewResourceId, config.Options)
        {
            this.config = config;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //Use base class to create the View
            var view = base.GetView(position, convertView, parent);
            var textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);

            var item = this.config.Options.ElementAt(position);

            textView.Text = item.Text;
            if (item.ItemIcon != null)
                textView.SetCompoundDrawablesWithIntrinsicBounds(ImageLoader.Load(item.ItemIcon), null, null, null);

            if (this.AddMarginForImage)
            {
                //Add margin between image and text (support various screen densities)
                var dp = (int) (10*parent.Context.Resources.DisplayMetrics.Density + 0.5f);
                textView.CompoundDrawablePadding = dp;
            }
            view.SetBackgroundResource(Extensions.GetSelectableItemBackground(Context));
            return view;
        }
    }
}