using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    public static Inventory _instance;

    private List<Item> _items;
    public float _maximumWeight = 10.0f;
    public float _totalWeight;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }

        _items = new List<Item>();
    }

    public bool AddItem(Item item)
    {
        if (_totalWeight + item._weight > _maximumWeight)
        {
            return false;
        }
        else
        {
            _items.Add(item);
            InventoryUI._instance.Add(item);
            _totalWeight += item._weight;
            return true;
        }
    }

    public void removeItem(Item item)
    {
        if (_items.Remove(item))
        {
            InventoryUI._instance.Remove(item);
            _totalWeight -= item._weight;
        }
    }

    public void removeByName(string name)
    {
        foreach (Item i in _items)
        {
            if (i._name == name)
            {
                removeItem(i);
                break;
            }
        }
    }

    public bool HasKey(int id)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i] is AccessItem)
            {
                AccessItem it = (AccessItem)_items[i];
                if (it._door == id)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void printToConsole()
    {
        foreach (Item i in _items)
        {
            Debug.Log(i._name + "--" + i._weight);
        }

        Debug.Log("Total Weight:" + _totalWeight);
    }
}