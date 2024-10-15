using System.Collections;
using UnityEngine;

public class PlatingCounter : ContainerCouner
{
    [SerializeField] private int _maxPlatesCount;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private PlateCounterVisual _visualController;

    private int _currentPlatesCount;
    private Coroutine _spawning;

    private void Start()
    {
        if (_spawning != null)
        {
            StopCoroutine(_spawning);
        }

        _spawning = StartCoroutine(SpawningPlates());
    }

    public override KitchenItem Interact()
    {
        if (_currentPlatesCount > 0)
        {
            _currentPlatesCount--;

            if (_spawning != null)
            {
                StopCoroutine(_spawning);
            }

            _spawning = StartCoroutine(SpawningPlates());
            _visualController.UpdateVisualsAmount(_currentPlatesCount);
            return base.Interact();
        }

        return null;
    }

    private IEnumerator SpawningPlates()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (_currentPlatesCount < _maxPlatesCount)
        {
            yield return wait;
            SpawnPlate();
        }

        _spawning = null;
    }

    private void SpawnPlate()
    {
        _currentPlatesCount++;
        _visualController.UpdateVisualsAmount(_currentPlatesCount);
    }
}
