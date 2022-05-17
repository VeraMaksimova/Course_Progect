using System;
using System.Collections.Generic;
using System.Text;
using WpfPaging.Windows;
namespace WpfPaging.Services
{
    public interface IDialogService{
        void ShowDialog(string name);
    }
     class DialogService : IDialogService
    {
           public  void ShowDialog(string name)
           {
           var dialog = new DialogWindow();
     
           
          
           var type = Type.GetType($"WpfPaging.Services.{name}");
           dialog.Content = Activator.CreateInstance(type);
           dialog.ShowDialog();
           }
    }//12 58
}
