using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickAreaHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ClickArea _clickArea;
    public static Action<ClickArea> ClickAreaClicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickAreaClicked?.Invoke(_clickArea);
    }
}
