using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Access : Pickup
{
    public int _door;

    protected override Item CreateItem()
    {
        return new AccessItem(_objectName, _weight, _door);
    }
}
