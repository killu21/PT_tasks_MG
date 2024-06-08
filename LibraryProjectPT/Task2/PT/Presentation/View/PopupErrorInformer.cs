using Presentation.ViewModel;
using System.Windows;
using Presentation.Model.API;

namespace Presentation.View;

internal class PopupErrorInformer : IErrorInformer
{
    private string _recentMessage;

    public PopupErrorInformer()
    {
        _recentMessage = string.Empty;
    }

    public void InformError(string message)
    {
        _recentMessage = message;

        MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    public void InformSuccess(string message)
    {
        _recentMessage = message;

        MessageBox.Show(message, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
    }
    
    public void CallMessageBox(string message) { 
        MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); 
    }

    public string GetRecentMessage()
    {
        return _recentMessage;
    }
}
