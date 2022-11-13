using System;


namespace Maui.UserDialogs
{
    public interface IStandardDialogResult<T>
    {
        bool Ok { get; }
        T Value { get; }
    }
}
