using System;
using System.Collections;
using UnityEngine;

public class StoveCounter : ProgressCounter
{
    private Coroutine _frying;

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
        float currentMaxFryingProgress = Item.ItemSO.CookTime;
        Animator.TurnCounterOn();

        while (Item != null && Item.CookingProgress < currentMaxFryingProgress) 
        {
            Item.GetCooked(Time.deltaTime);
            OnProgressUpdate(Item.CookingProgress, currentMaxFryingProgress);
            yield return null;
        }

        if (Item?.CookingProgress >= currentMaxFryingProgress)
        {
            KitchenItem cookedItem = Instantiate(Item.ItemSO.CookedItemSO.Item, ItemHolder);
            Destroy(Item.gameObject);
            Item = cookedItem;
        }

        Animator.TurnCounterOff();

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
