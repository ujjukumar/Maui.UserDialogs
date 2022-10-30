using Microsoft.UI.Xaml.Controls;
using Button = Microsoft.UI.Xaml.Controls.Button;

namespace Maui.UserDialogs;

public sealed partial class DatePickerControl
{
    public DatePickerControl()
    {
        this.InitializeComponent();
    }

    public Button OkButton => this.btnOk;
    public Button CancelButton => this.btnCancel;
    public CalendarView DatePicker => this.datePicker;
}
