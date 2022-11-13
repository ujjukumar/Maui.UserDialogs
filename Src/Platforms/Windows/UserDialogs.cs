﻿namespace Maui.UserDialogs.Platforms.Windows;

public static partial class UserDialogs
{
    /// <summary>
    /// Initialize UWP user dialogs
    /// </summary>
    public static void Init(Func<Action, Task> customDispatcher = null)
    {
        Instance = new UserDialogsImpl(customDispatcher);
    }


    static IUserDialogs currentInstance;
    public static IUserDialogs Instance
    {
        get
        {
            currentInstance ??= new UserDialogsImpl();
            return currentInstance;
        }
        set => currentInstance = value;
    }
}