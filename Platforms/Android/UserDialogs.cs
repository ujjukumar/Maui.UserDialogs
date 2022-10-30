using System;
using Maui.UserDialogs.Infrastructure;
using Android.App;
using Application = Android.App.Application;

namespace Maui.UserDialogs
{
    public static partial class UserDialogs
    {
        public static void Init(Func<Activity> topActivityFactory)
        {
            Instance = new UserDialogsImpl(topActivityFactory);
        }


        /// <summary>
        /// Initialize android user dialogs
        /// </summary>
        public static void Init(Application app)
        {
            ActivityLifecycleCallbacks.Register(app);
            Init(() => ActivityLifecycleCallbacks.CurrentTopActivity);
        }


        /// <summary>
        /// Initialize android user dialogs
        /// </summary>
        public static void Init(Activity activity)
        {
            ActivityLifecycleCallbacks.Register(activity);
            Init(() => ActivityLifecycleCallbacks.CurrentTopActivity);
        }


        static IUserDialogs currentInstance;
        public static IUserDialogs Instance
        {
            get
            {
                if (currentInstance == null)
                    throw new ArgumentException("[Maui.UserDialogs] In android, you must call UserDialogs.Init(Activity) from your first activity OR UserDialogs.Init(App) from your custom application OR provide a factory function to get the current top activity via UserDialogs.Init(() => supply top activity)");

                return currentInstance;
            }
            set => currentInstance = value;
        }
    }
}
