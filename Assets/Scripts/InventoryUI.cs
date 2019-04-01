using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI _instance;

    public GameObject _itemPrefab;
    public GameObject _prefabHolder;
    private Dictionary<string, Pickup> _items;

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }

        _items = new Dictionary<string, Pickup>();
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void RegisterPickUpItem(Pickup i)
    {
        if (!_items.ContainsKey(i._objectName))
        {
            _items.Add(i._objectName, i);
        }
    }

    public void Add(Item i)
    {

        if (_items.ContainsKey(i._name) && !_items[i._name].isInInventory())
        {
            GameObject go = Instantiate(_itemPrefab, transform);
            go.transform.SetParent(_prefabHolder.transform);
            go.GetComponent<Image>().sprite = _items[i._name]._image;
            go.transform.GetChild(0).GetComponent<Text>().text = i._name;
            _items[i._name].setInventoryObj(go);
        }
    }

    public void Remove(Item i)
    {
        if (_items.ContainsKey(i._name))
        {
            _items[i._name].Respawn();
        }
    }
}