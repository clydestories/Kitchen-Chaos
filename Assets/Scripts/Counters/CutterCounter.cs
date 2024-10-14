public class CutterCounter : ProgressCounter, IUsable
{
    public void Use()
    {
        if (Item != null)
        {
            if (Item.ItemSO.SlicedItem != null)
            {
                Slice();
            }
        }
    }

    private void Slice()
    {
        Item.GetSliced();
        Animator.StartUseAnimation();
        OnProgressUpdate(Item.ItemSO.SlicingToughness - Item.SlicesRemaining, Item.ItemSO.SlicingToughness);
        Item.transform.RotateAround(UnityEngine.Vector3.right, 30);

        if (Item.SlicesRemaining == 0)
        {
            KitchenItem slicedItem = Instantiate(Item.ItemSO.SlicedItem.Item, ItemHolder);
            Destroy(Item.gameObject);
            Item = slicedItem;
        }
    }
}
