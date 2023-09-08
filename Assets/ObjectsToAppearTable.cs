using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "ObjectsToAppearTable", menuName = "ObjectsToAppearTable")]
public class ObjectsToAppearTable: ScriptableObject
{
    [SerializeField] private ClickArea _clickArea;
    [SerializeField] private List<ObjectToAppear> _objectsList;
    public ClickArea ClickArea => _clickArea;
    public List<ObjectToAppear> ObjectsList => _objectsList;
}