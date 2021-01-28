using System;
using Microsoft.AspNetCore.Components;

namespace AppStateAwareComponents.Shared
{
public abstract class AppStateAwareComponentBase : ComponentBase, IDisposable
{
    [Inject]
    protected AppState AppState { get; private set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        AppState.AppStateChanged += AppStateChanged;
    }

    protected abstract Boolean HandleAppStateChanged(String propertyName, AppState state);

    private async void AppStateChanged(String propertyName, AppState state)
    {
        Boolean changesOccured = HandleAppStateChanged(propertyName, state);
        if (changesOccured == true)
        {
            await InvokeAsync(StateHasChanged);
        }
    }

    public void Dispose()
    {
        AppState.AppStateChanged -= AppStateChanged;
    }
}
}