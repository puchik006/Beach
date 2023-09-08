using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Transform))]
public class ClickAreaManager : MonoBehaviour
{
    [SerializeField] private ObjectsToAppearTable _objectsToAppearTable;
    private RectTransform _place;

    private List<int> _ojectsQty = new();

    private void Awake()
    {
        _place = GetComponent<RectTransform>();
        ClickAreaHandler.ClickAreaClicked += OnClickAreaClicked;
    }

    private void OnEnable()
    {
        _ojectsQty.Clear();
        _objectsToAppearTable.ObjectsList.ForEach(e => _ojectsQty.Add(e.Quantity));
        Debug.Log(_ojectsQty.Count);
    }

    private void OnClickAreaClicked(ClickArea clickArea)
    {
        GameObject randomObject = GetRandomObjectFromList();

        if (randomObject != null)
        {
            Instantiate(randomObject, Input.mousePosition, Quaternion.identity, _place);
        }
    }

    private GameObject GetRandomObjectFromList()
    {
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, _objectsToAppearTable.ObjectsList.Count());
        } while (randomIndex < _ojectsQty.Count && _ojectsQty[randomIndex] <= 0);

        if (randomIndex < _ojectsQty.Count && _ojectsQty[randomIndex] > 0)
        {
            _ojectsQty[randomIndex]--;
            return _objectsToAppearTable.ObjectsList[randomIndex].Object;
        }
        else
        {
            return null;
        }
    }
}
