﻿using System;
using UIKit;


namespace Maui.UserDialogs
{
    public static partial class UserDialogs
    {
        /// <summary>
        /// OPTIONAL: Initialize iOS user dialogs with your top viewcontroll function
        /// </summary>
        public static void Init(Func<UIViewController> viewControllerFunc = null)
        {
            Instance = new UserDialogsImpl(viewControllerFunc);
        }


        static IUserDialogs currentInstance;
        public static IUserDialogs Instance
        {
            get
            {
                currentInstance = currentInstance ?? new UserDialogsImpl();
                return currentInstance;
            }
            set => currentInstance = value;
        }
    }
}
