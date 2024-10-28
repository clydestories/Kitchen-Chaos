using System.Collections.Generic;

public class PauseState : State
{
    private GameStateManager _stateManager;

    public PauseState(List<ITransition> transitions, GameStateManager stateManager) : base(transitions)
    {
        _stateManager = stateManager;
    }

    public override void Enter()
    {
        _stateManager.Pause();
    }

    public override void Exit()
    {
        _stateManager.Unpause();
    }

    public override void Update()
    {
        
    }
}
