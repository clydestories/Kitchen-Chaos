using System;
using System.Collections.Generic;

public abstract class FiniteStateMachine
{
    private State _currentState;

    private Dictionary<Type, State> _states;

    public FiniteStateMachine(Dictionary<Type, State> states)
    {
        _states = states;
    }

    public void EnterState(Type type)
    {
        if (_states.TryGetValue(type, out var state))
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }

    public void UpdateState()
    {
       _currentState.Update();

        if (_currentState.TryGetNextState(out Type type))
        {
            EnterState(type);
        }
    }
}