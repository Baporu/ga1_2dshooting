using UnityEngine;

[System.Serializable]
public class ItemSpawnData
{
    [SerializeField] private GameObject _itemPrefab;
    public GameObject ItemPrefab => _itemPrefab;

    [SerializeField] private int _weight;
    public int Weight => _weight;
}