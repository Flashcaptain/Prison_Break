using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : Item
{
    [SerializeField]
    private int _points;

    public BonusItem(string name, float weight, int points) : base(name, weight)
    {
        _points = points;
    }
}
