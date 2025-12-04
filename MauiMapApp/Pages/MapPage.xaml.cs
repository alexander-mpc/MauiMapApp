#if iOS
using Microsoft.Maui.Maps.Platform; // Workaround for Linker to keep events from map handler
#endif

namespace MauiMapApp.Pages;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
		InitializeComponent();
    }
}