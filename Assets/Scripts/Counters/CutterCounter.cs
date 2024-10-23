public class CutterCounter : ProgressCounter, IUsable
{
    public void Use()
    {
        if (CurrentItem != null)
        {
            if (CurrentItem.ItemSO.SlicedItem != null)
            {
                AudioHandler.PlayUseSound();
                Slice();
            }
        }
    }

    private void Slice()
    {
        CurrentItem.GetSliced();
        Animator.StartUseAnimation();
        OnProgressUpdate(CurrentItem.ItemSO.SlicingToughness - CurrentItem.SlicesRemaining, CurrentItem.ItemSO.SlicingToughness);

        if (CurrentItem.SlicesRemaining == 0)
        {
            KitchenItem slicedItem = Instantiate(CurrentItem.ItemSO.SlicedItem.Item, ItemHolder);
            Destroy(CurrentItem.gameObject);
            CurrentItem = slicedItem;
        }
    }
}
