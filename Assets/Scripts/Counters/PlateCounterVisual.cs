using System.Collections.Generic;
using UnityEngine;

public class PlateCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject _visualPrefab;
    [SerializeField] private Transform _holder;
    [SerializeField] private float _visualYOffset;

    private List<GameObject> _visuals = new();

    public void UpdateVisualsAmount(int amount)
    {
        if (amount > _visuals.Count)
        {
            AddVisual();
        }
        else
        {
            RemoveVisual();
        }
    }

    private void AddVisual()
    {
        GameObject newVisual = Instantiate(_visualPrefab, _holder);
        newVisual.transform.parent = _holder;
        newVisual.transform.localPosition = new Vector3(0, _visuals.Count * _visualYOffset, 0);
        _visuals.Add(newVisual);
    }

    private void RemoveVisual()
    {
        Destroy(_visuals[_visuals.Count - 1].gameObject);
        _visuals.RemoveAt(_visuals.Count - 1);
    }
}
