using System;
using System.Collections;
using UnityEngine;

public class StoveCounter : HolderCounter
{
    private Coroutine _frying;
    private float _currentMaxFryingProgress;

    public event Action<float, float> FryingProgressUpdated;

    public override bool TryInteract(KitchenItem item)
    {
        if (Item == null)
        {
            PlaceItem(item);

            if (Item.ItemSO.CookedItemSO != null)
            {
                if (_frying != null)
                {
                    StopCoroutine(_frying);
                }

                _frying = StartCoroutine(Frying());
            }

            return true;
        }

        return false;
    }

    private IEnumerator Frying()
    {
        _currentMaxFryingProgress = Item.ItemSO.CookTime;

        while (Item != null && Item.CookingProgress < _currentMaxFryingProgress) 
        {
            Item.GetCooked(Time.deltaTime);
            FryingProgressUpdated?.Invoke(Item.CookingProgress, _currentMaxFryingProgress);
            yield return null;
        }

        if (Item?.CookingProgress >= _currentMaxFryingProgress)
        {
            KitchenItem cookedItem = Instantiate(Item.ItemSO.CookedItemSO.Item, ItemHolder);
            Destroy(Item.gameObject);
            Item = cookedItem;
        }

        _currentMaxFryingProgress = 0;

        if (Item?.ItemSO.CookedItemSO != null)
        {
            _frying = StartCoroutine(Frying());
        }
        else
        {
            _frying = null;
        }
    }
}
