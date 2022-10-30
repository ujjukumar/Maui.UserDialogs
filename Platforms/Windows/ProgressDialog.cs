using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Command = Maui.UserDialogs.Platforms.Windows.Infrastructure.Command;
using Visibility = Microsoft.UI.Xaml.Visibility;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace Maui.UserDialogs.Platforms.Windows;

public class ProgressDialog : IProgressDialog, INotifyPropertyChanged
{
    readonly ProgressDialogConfig config;
    ProgressContentDialog dialog;

    readonly Func<Action, Task> dispatcher;

    public ProgressDialog(ProgressDialogConfig config, Func<Action, Task> dispatcher = null)
    {
        this.config = config;
        Cancel = new Command(() => config.OnCancel?.Invoke());

        this.dispatcher = dispatcher ?? new Func<Action, Task>(x => CoreApplication
            .MainView
            .CoreWindow
            .Dispatcher
            .RunAsync(CoreDispatcherPriority.Normal, () => x())
            .AsTask()
        );
    }


    public bool IsShowing { get; private set; }


    int percent;
    public int PercentComplete
    {
        get { return percent; }
        set
        {
            if (value > 100)
                percent = 100;
            else if (value < 0)
                percent = 0;
            else
                percent = value;
            Change();
            Change("PercentCompleteString");
        }
    }

    public string PercentCompleteString
    {
        get { return percent + "%"; }
    }


    public string CancelText => config.CancelText;
    public bool IsIndeterministic => !config.IsDeterministic;
    public Visibility TextPercentVisibility => config.IsDeterministic ? Visibility.Visible : Visibility.Collapsed;


    string title;
    public string Title
    {
        get { return title; }
        set
        {
            title = value;
            Change();
        }
    }


    public void Dispose()
    {
        Hide();
    }


    public void Hide()
    {
        if (!IsShowing)
            return;

        IsShowing = false;
        Dispatch(() => dialog.Hide());
    }


    public void Show()
    {
        if (IsShowing)
            return;

        IsShowing = true;
        Dispatch(() =>
        {
            if (dialog == null)
                dialog = new ProgressContentDialog { DataContext = this };

            _ = dialog.ShowAsync();
        });
    }


    void Change([CallerMemberName] string property = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }


    public ICommand Cancel { get; }
    public Visibility CancelVisibility => config.OnCancel == null
        ? Visibility.Collapsed
        : Visibility.Visible;


    public event PropertyChangedEventHandler PropertyChanged;


    protected virtual void Dispatch(Action action)
    {
        dispatcher.Invoke(action);
    }
}
