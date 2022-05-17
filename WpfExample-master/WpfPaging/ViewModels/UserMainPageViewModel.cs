using DevExpress.Mvvm;
using System;
using System.Windows.Input;
using WpfPaging.Events;
using WpfPaging.Messages;
using WpfPaging.Pages;
using WpfPaging.Services;

using System.Collections.ObjectModel;

namespace WpfPaging.ViewModels
{
    public class UserMainPageViewModel : BindableBase
    {

        private readonly PageService _pageService;


        public UserMainPageViewModel(PageService pageService)
        {
            _pageService = pageService;
        }


        public ICommand ChangePage => new AsyncCommand(async () =>
        {
            _pageService.ChangePage(new Page1());
        });

    }
}
