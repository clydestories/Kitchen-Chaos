using System;

public class ProgressCounter : HolderCounter
{
    private float _defaultMaxProgress = 1;

    public event Action<float, float, bool> ProgressUpdated;

    public override KitchenItem Interact()
    {
        OnProgressUpdate(0, _defaultMaxProgress, false);
        return base.Interact();
    }

    public override bool TryInteract(KitchenItem item)
    {
        OnProgressUpdate(0, _defaultMaxProgress, true);
        return base.TryInteract(item);
    }

    protected void OnProgressUpdate(float currentProgress, float maxProgress, bool isShowing = true)
    {
        ProgressUpdated?.Invoke(currentProgress, maxProgress, isShowing);
    }
}
