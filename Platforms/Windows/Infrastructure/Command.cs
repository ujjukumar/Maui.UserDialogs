using System.Windows.Input;


namespace Maui.UserDialogs.Platforms.Windows.Infrastructure;

public class Command : ICommand
{
    public event EventHandler CanExecuteChanged;
    readonly Action action;

    public Command(Action action)
    {
        this.action = action;
    }


    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        action();
    }
}
