using Maui.UserDialogs.Platforms.Windows;
using Microsoft.UI.Xaml.Controls;

namespace Maui.UserDialogs;

public sealed partial class ActionSheetContentDialog : ContentDialog {

    public ActionSheetContentDialog() {
        this.InitializeComponent();
        this.List.SelectionChanged += (sender, args) => {
            var vm = this.List.SelectedItem as ActionSheetOptionViewModel;
            vm?.Action?.Execute(null);

            // needs to set this as per WinUI3
            base.XamlRoot = this.XamlRoot;
        };
    }
}
