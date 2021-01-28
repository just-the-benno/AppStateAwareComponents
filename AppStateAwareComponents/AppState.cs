using System;

namespace AppStateAwareComponents
{
    public delegate void AppStateChangedHandler(String propertyName, AppState state);

public class AppState
{
    private Int32 _clickCounter = 0;

    public Int32 ClickCounter
    {
        get => _clickCounter;
        set
        {
            _clickCounter = value;
            AppStateChanged?.Invoke(nameof(ClickCounter), this);
        }
    }

    public event AppStateChangedHandler AppStateChanged;
}
}