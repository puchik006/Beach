using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "ObjectsToAppearTable", menuName = "ObjectsToAppearTable")]
public class ObjectsToAppearTable: ScriptableObject
{
    public ClickArea ClickArea;
    public List<ObjectToAppear> ObjectsList;

    public ObjectToAppear GetRandomObject()
    {
        List<ObjectToAppear> availableObjects = ObjectsList.FindAll(obj => obj.Quantity > 0);

        if (availableObjects.Count == 0) return null;

        int randomIndex = Random.Range(0, availableObjects.Count);
        ObjectToAppear randomObject = availableObjects[randomIndex];
        randomObject.Quantity--;
        return randomObject;
    }
}