using System;


namespace Maui.UserDialogs
{

    public interface IProgressDialog : IDisposable
    {
        string Title { get; set; }
        int PercentComplete { get; set; }
        bool IsShowing { get; }

        void Show();
        void Hide();
    }
}
