using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : Pickup
{
    public int _points;

    protected override Item CreateItem()
    {
        return new BonusItem(_objectName, _weight, _points);
    }

}
