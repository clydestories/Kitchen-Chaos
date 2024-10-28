using System.Collections.Generic;

public class CountdownState : State
{
    private GameStateManager _stateManager;

    public CountdownState(List<ITransition> transitions, GameStateManager stateManager) : base(transitions)
    {
        _stateManager = stateManager;
    }

    public override void Enter()
    {
        _stateManager.StartCountdown();
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {

    }
}
