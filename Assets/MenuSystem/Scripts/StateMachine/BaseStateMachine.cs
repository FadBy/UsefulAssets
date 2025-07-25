using System.Collections.Generic;
using System.Linq;
using Logger;

public abstract class BaseStateMachine : IStateMachine
{
    protected List<IState> States = new List<IState>();

    public IState InitialState { get; protected set; }

    public IState CurrentState { get; protected set; }

    public virtual void SwitchTo(IState state)
    {
        CurrentState?.SwitchOff();
        CurrentState = state;
        CurrentState?.SwitchOn();
    }
    
    public void SwitchTo(string stateName)
    {
        var state = GetState(stateName);
        if (state == null)
        {
            GameLogger.Instance.LogError("StateMachine", $"State {stateName} not found");
            return;
        }

        SwitchTo(state);
    }

    protected virtual IState GetState(string stateName)
    {
        return States.FirstOrDefault(state => state?.Name == stateName);
    }
}