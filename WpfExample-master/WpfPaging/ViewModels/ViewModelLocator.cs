using Microsoft.Extensions.DependencyInjection;
using WpfPaging.Services;
using WpfPaging.ViewModels;

namespace WpfPaging
{
    public class ViewModelLocator
    {
        private static ServiceProvider _provider;

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddTransient<MainViewModel>();
            services.AddTransient<Page1ViewModel>();
            services.AddScoped<LogPageViewModel>();
            services.AddScoped<SuccsessPageViewModel>();
            services.AddScoped<UserMainPageViewModel>();
            services.AddScoped<AdminPageViewModel>();

            services.AddSingleton<PageService>();
            services.AddSingleton<EventBus>();
            services.AddSingleton<MessageBus>();
            services.AddSingleton<SuccsessPageViewModel>();
            services.AddSingleton<UserMainPageViewModel>();
            services.AddSingleton<AdminPageViewModel>();

            _provider = services.BuildServiceProvider();

            foreach (var item in services)
            {
                _provider.GetRequiredService(item.ServiceType);
            }
        }

        public MainViewModel MainViewModel => _provider.GetRequiredService<MainViewModel>();
        public LogPageViewModel LogPageViewModel => _provider.GetRequiredService<LogPageViewModel>();
        public Page1ViewModel Page1ViewModel => _provider.GetRequiredService<Page1ViewModel>();
        public SuccsessPageViewModel SuccsessPageViewModel => _provider.GetRequiredService<SuccsessPageViewModel>();

        public UserMainPageViewModel UserMainPageViewModel => _provider.GetRequiredService<UserMainPageViewModel>();
        public AdminPageViewModel AdminPageViewModel => _provider.GetRequiredService<AdminPageViewModel>();
    }
}
