using System.Collections.Generic;

public class GameOverState : State
{
    private GameStateManager _stateManager;

    public GameOverState(List<ITransition> transitions, GameStateManager stateManager) : base(transitions)
    {
        _stateManager = stateManager;
    }

    public override void Enter()
    {
        _stateManager.OnGameOver();
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        
    }
}
