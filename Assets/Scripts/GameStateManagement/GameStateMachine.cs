using System;
using System.Collections.Generic;

public class GameStateMachine : FiniteStateMachine
{
    public GameStateMachine(Dictionary<Type, State> states) : base(states)
    {
    }
}
