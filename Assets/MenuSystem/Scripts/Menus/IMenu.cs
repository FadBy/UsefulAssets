using System;

namespace MenuSystem
{
    public interface IMenu : IState
    {
        void AddSwitchListener(Action<string> listener);
        void RemoveSwitchListener(Action<string> listener);
    }
}