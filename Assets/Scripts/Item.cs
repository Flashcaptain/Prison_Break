using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
	public string _name;
    
    public float _weight;

    public Item(string name,float weight)
	{
        _name = name;
        _weight = weight;
	}
}
