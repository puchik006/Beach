using System;
using UnityEngine;

[Serializable]
public class ObjectToAppear
{
    public GameObject Object;
    [Range(0, 10)] public int Quantity;
}
