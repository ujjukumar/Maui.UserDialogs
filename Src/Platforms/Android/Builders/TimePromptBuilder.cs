using System;
using Android.App;
using Android.Text.Format;
using Android.Widget;
using Java.Lang;
using TimePicker = Android.Widget.TimePicker;

namespace Maui.UserDialogs.Builders
{
    public static class TimePromptBuilder
    {
        public static Dialog Build(Activity activity, TimePromptConfig config)
        {
            var picker = new TimePicker(activity);
            var builder = new AlertDialog.Builder(activity, config.AndroidStyleId ?? 0)
                .SetCancelable(false)
                .SetTitle(config.Title)
                .SetView(picker);

            if (config.SelectedTime != null)
            {
                picker.Hour = config.SelectedTime.Value.Hours;
                picker.Minute = config.SelectedTime.Value.Minutes;
            }

            var is24Hour = config.Use24HourClock ?? DateFormat.Is24HourFormat (activity);
            picker.SetIs24HourView(new Java.Lang.Boolean(is24Hour));

            if (config.IsCancellable)
            {
                builder.SetNegativeButton(
                    config.CancelText,
                    (sender, args) =>
                    {
                        var ts = new TimeSpan(0, picker.Hour, picker.Minute, 0);
                        config.OnAction?.Invoke(new TimePromptResult(false, ts));
                    }
                );
            }
            builder.SetPositiveButton(
                config.OkText,
                (sender, args) =>
                {
                    var ts = new TimeSpan(0, picker.Hour, picker.Minute, 0);
                    config.OnAction?.Invoke(new TimePromptResult(true, ts));
                }
            );

            return builder.Show();
        }
    }
}