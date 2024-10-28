using System;

public interface IState
{
    public abstract void Enter();

    public abstract void Update();

    public abstract void Exit();

    public abstract bool TryGetNextState(out Type type);
}
