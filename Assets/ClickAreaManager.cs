using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Transform))]
public class ClickAreaManager : MonoBehaviour
{
    [SerializeField] private ObjectsToAppearTable _objectsToAppearTable;
    private RectTransform _place;

    private void Awake()
    {
        _place = GetComponent<RectTransform>();
        ClickAreaHandler.ClickAreaClicked += OnClickAreaClicked;
    }

    private void OnClickAreaClicked(ClickArea clickArea)
    {
        Instantiate(_objectsToAppearTable.ObjectsList[0].Object,GetRandomPositionInsideBounds(),Quaternion.identity,_place);
    }

    private Vector3 GetRandomPositionInsideBounds()
    {
        Vector2 boundsMin = _place.rect.min;
        Vector2 boundsMax = _place.rect.max;

        // Get the position in local space
        Vector3 localPosition = new Vector3(
            Random.Range(boundsMin.x, boundsMax.x),
            Random.Range(boundsMin.y, boundsMax.y),
            0f
        );

        // Convert local position to global position
        Vector3 globalPosition = _place.TransformPoint(localPosition);

        return globalPosition;
    }
}
