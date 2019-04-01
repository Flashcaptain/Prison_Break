using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessItem : Item
{
    public int _door;

    public AccessItem(string name, float weight, int door) : base(name, weight)
    {
        _door = door;
    }
}