using CommunityToolkit.Mvvm.Input;
using MauiMapApp.Models;

namespace MauiMapApp.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}