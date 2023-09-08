using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectsTableHandler
{
    private List<int> _ojectsQty = new List<int>();
    private List<int> _availableIndexes = new List<int>();

    public void Initialize(ObjectsToAppearTable objectsTable)
    {
        _ojectsQty.Clear();
        _availableIndexes.Clear();

        for (int i = 0; i < objectsTable.ObjectsList.Count; i++)
        {
            int quantity = objectsTable.ObjectsList[i].Quantity;
            _ojectsQty.Add(quantity);
            _availableIndexes.Add(i);
        }
    }

    public GameObject GetRandomObjectFromList(ObjectsToAppearTable objectsTable)
    {
        if (_availableIndexes.Count == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, _availableIndexes.Count);
        int selectedIndex = _availableIndexes[randomIndex];
        _ojectsQty[selectedIndex]--;

        if (_ojectsQty[selectedIndex] <= 0)
        {
            _availableIndexes.RemoveAt(randomIndex);
        }

        return objectsTable.ObjectsList[selectedIndex].Object;
    }
}