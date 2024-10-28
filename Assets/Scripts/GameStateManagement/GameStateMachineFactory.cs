using System;
using System.Collections.Generic;

public static class GameStateMachineFactory
{
    public static GameStateMachine CreateGameStateMachine(GameStateManager gameStateManager)
    {
        Dictionary<Type, State> states = new Dictionary<Type, State>()
        {
            [typeof(CountdownState)] = new CountdownState(CreateTransitionFromCountdown(gameStateManager), gameStateManager),
            [typeof(PauseState)] = new PauseState(CreateTransitionFromPause(gameStateManager), gameStateManager),
            [typeof(GameOverState)] = new GameOverState(CreateTransitionFromGameOver(gameStateManager), gameStateManager),
            [typeof(PlayState)] = new PlayState(CreateTransitionFromPlay(gameStateManager), gameStateManager)
        };

        return new GameStateMachine(states);
    }

    private static List<ITransition> CreateTransitionFromCountdown(GameStateManager gameStateManager)
    {
        return new List<ITransition>()
        {
            new TransitionTo<PlayState>(() => gameStateManager.IsCountingDown == false)
        };
    }

    private static List<ITransition> CreateTransitionFromPause(GameStateManager gameStateManager)
    {
        return new List<ITransition>()
        {
            new TransitionTo<PlayState>(() => gameStateManager.IsPaused == false)
        };
    }

    private static List<ITransition> CreateTransitionFromGameOver(GameStateManager gameStateManager)
    {
        return new List<ITransition>();
    }

    private static List<ITransition> CreateTransitionFromPlay(GameStateManager gameStateManager)
    {
        return new List<ITransition>()
        {
            new TransitionTo<GameOverState>(() => gameStateManager.HasLost),
            new TransitionTo<PauseState>(() => gameStateManager.IsPaused == true)
        };
    }
}
