using System.Windows.Input;
using Command = Maui.UserDialogs.Platforms.Windows.Infrastructure.Command;
using Visibility = Microsoft.UI.Xaml.Visibility;

namespace Maui.UserDialogs.Platforms.Windows;

public class ActionSheetOptionViewModel
{
    public ActionSheetOptionViewModel(bool visible, string text, Action action, string image = null)
    {
        Text = text;
        Action = new Command(action);
        Visible = visible ? Visibility.Visible : Visibility.Collapsed;
        ItemIcon = image;
    }


    public Visibility Visible { get; }
    public string Text { get; }
    public ICommand Action { get; }
    public string ItemIcon { get; }
}
