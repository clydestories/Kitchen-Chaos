using System.Collections.Generic;
using System;

public abstract class State : IState
{
    private List<ITransition> _transitions;

    public State(List<ITransition> transitions)
    {
        _transitions = transitions;
    }

    public abstract void Enter();

    public abstract void Update();

    public abstract void Exit();

    public bool TryGetNextState(out Type type)
    {
        foreach (var transition in _transitions)
        {
            if (transition.CanTransit())
            {
                type = transition.NextState;
                return true;
            }
        }

        type = null;
        return false;
    }
}
