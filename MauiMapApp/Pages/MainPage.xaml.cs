using MauiMapApp.Models;
using MauiMapApp.PageModels;

namespace MauiMapApp.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}