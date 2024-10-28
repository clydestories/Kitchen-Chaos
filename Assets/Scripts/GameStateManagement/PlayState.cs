using System.Collections.Generic;

public class PlayState : State
{
    private GameStateManager _stateManager;

    public PlayState(List<ITransition> transitions, GameStateManager stateManager) : base(transitions)
    {
        _stateManager = stateManager;
    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        
    }
}
