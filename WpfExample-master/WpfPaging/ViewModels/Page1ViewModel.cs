using DevExpress.Mvvm;
using System;
using System.Windows.Input;
using WpfPaging.Events;
using WpfPaging.Messages;
using WpfPaging.Pages;
using WpfPaging.Services;
using System.Windows;
using WpfPaging.Windows;

//using Experimental.System.Messaging;
//using Prism.Commands;
//using Prism.Mvvm;

namespace WpfPaging.ViewModels
{
    public class Page1ViewModel : BindableBase
    {

        #region Navigate
        private readonly PageService _pageService;
      
        public string LogText { get; set; }

        public Page1ViewModel(PageService pageService)
        {
            _pageService = pageService;
            
        }

        public ICommand ChangePage => new AsyncCommand(async () =>
        {
            _pageService.ChangePage(new LogPage());

            //await _eventBus.Publish(new LeaveFromFirstPageEvent());
        });


        public ICommand ChangePage_MainUser => new AsyncCommand(async () =>
        {
            _pageService.ChangePage(new MainUserPage());

            //await _eventBus.Publish(new LeaveFromFirstPageEvent());
        });

        #endregion

        #region Логин и Пароль
        private string _login = ""; // поле в котором свойство хранит данные
        public string login
        {
            get => _login;  //Возврашщаем само поле
            set
            {
                //Правильно, но длинно
                if (Equals(_login, value)) return;
                _login = value;
                 RaisePropertyChanged(_login);//говно и палки

            }
        }


        private string _password = "";
        public string password
        {
            get => _password;  //Возврашщаем само поле
            set
            {
                //Правильно, но длинно
                if (Equals(_password, value)) return;
                _password = value;
                RaisePropertyChanged(_password);//говно и палки

            }
        }
        #endregion

        #region DialogWindow

        Services.IDialogService __dialogService = new DialogService();

        private DelegateCommand _showDialog;

        public DelegateCommand ShowDialog =>
            _showDialog ?? (_showDialog = new DelegateCommand(ExecuteShowDialog));

        void ExecuteShowDialog()
        {
            __dialogService.ShowDialog("Notification");
        }


        #endregion

        #region Проверка вход
        private DelegateCommand _Check;

        public DelegateCommand Check =>
           _Check ?? (_showDialog = new DelegateCommand(ExecuteCheck));

        void ExecuteCheck()
        {
            if((_login == "admin") && (_password == "admin"))
            {
                _pageService.ChangePage(new AdminPage());

            }
            else
            {
                _pageService.ChangePage(new MainUserPage());

                //ExecuteShowDialog(); //окно ошибки
            }
        }
        #endregion

    }
}
