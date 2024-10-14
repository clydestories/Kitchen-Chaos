using System;
using System.Collections;
using UnityEngine;

public class StoveCounter : ProgressCounter
{
    private Coroutine _frying;

    public override bool TryInteract(KitchenItem item)
    {
        if (CurrentItem == null)
        {
            PlaceItem(item);

            if (CurrentItem.ItemSO.CookedItemSO != null)
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
        float currentMaxFryingProgress = CurrentItem.ItemSO.CookTime;
        Animator.TurnCounterOn();

        while (CurrentItem != null && CurrentItem.CookingProgress < currentMaxFryingProgress) 
        {
            CurrentItem.GetCooked(Time.deltaTime);
            OnProgressUpdate(CurrentItem.CookingProgress, currentMaxFryingProgress);
            yield return null;
        }

        if (CurrentItem?.CookingProgress >= currentMaxFryingProgress)
        {
            KitchenItem cookedItem = Instantiate(CurrentItem.ItemSO.CookedItemSO.Item, ItemHolder);
            Destroy(CurrentItem.gameObject);
            CurrentItem = cookedItem;
        }

        Animator.TurnCounterOff();

        if (CurrentItem?.ItemSO.CookedItemSO != null)
        {
            _frying = StartCoroutine(Frying());
        }
        else
        {
            _frying = null;
        }
    }
}
