using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace CabinetMaker.Web.Views.Base;

public abstract class ViewModelComponentBase<TViewModel> : ComponentBase, IDisposable
    where TViewModel : ObservableObject
{
    [Inject]
    protected TViewModel ViewModel { get; set; } = null!;

    protected override void OnInitialized()
    {
        ViewModel.PropertyChanged += OnPropertyChanged;
    }

    private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        => InvokeAsync(StateHasChanged);

    public void Dispose()
    {
        ViewModel.PropertyChanged -= OnPropertyChanged;
        GC.SuppressFinalize(this);
    }
}
