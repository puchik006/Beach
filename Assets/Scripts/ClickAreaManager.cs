using UnityEngine;

[RequireComponent(typeof(Transform))]
public class ClickAreaManager : MonoBehaviour
{
    [SerializeField] private ObjectsToAppearTable _objectsToAppearTable;
    private RectTransform _place;
    private ObjectsTableHandler _objectsTableHandler = new();

    private void Awake()
    {
        _place = GetComponent<RectTransform>();
        _objectsTableHandler.Initialize(_objectsToAppearTable);
    }

    private void OnEnable()
    {
        ClickAreaHandler.ClickAreaClicked += OnClickAreaClicked;
    }

    private void OnClickAreaClicked(ClickArea clickArea)
    {
        if (_objectsToAppearTable.ClickArea != clickArea) return;

        GameObject randomObject = _objectsTableHandler.GetRandomObjectFromList(_objectsToAppearTable);

        if (randomObject != null)
        {
            Instantiate(randomObject, Input.mousePosition, Quaternion.identity, _place);
        }
    }

    private void OnDisable()
    {
        ClickAreaHandler.ClickAreaClicked -= OnClickAreaClicked;
    }
}
