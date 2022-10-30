using Button = Microsoft.UI.Xaml.Controls.Button;

namespace Maui.UserDialogs;

public sealed partial class TimePickerControl
{
    public TimePickerControl()
    {
        this.InitializeComponent();
    }


    public Button OkButton => this.btnOk;
    public Button CancelButton => this.btnCancel;
    public Microsoft.UI.Xaml.Controls.TimePicker TimePicker => this.timePicker;
}
