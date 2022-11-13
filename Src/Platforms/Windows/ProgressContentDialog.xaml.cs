using Microsoft.UI.Xaml.Controls;

namespace Maui.UserDialogs;

public sealed partial class ProgressContentDialog : ContentDialog
{
    public ProgressContentDialog()
    {
        this.InitializeComponent();

        // needs to set this as per WinUI3
        base.XamlRoot = this.XamlRoot;
    }
}
