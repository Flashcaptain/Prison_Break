using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, IInteracteble
{
    public string _objectName;
    public float _weight;
    public Sprite _image;
    private GameObject _inventoryObject;

    void Start()
    {
        InventoryUI._instance.RegisterPickUpItem(this);
    }

    public void Action()
    {
        if (Inventory._instance.AddItem(CreateItem()))
        {
            gameObject.SetActive(false);
        }
    }

    public bool isInInventory()
    {
        return _inventoryObject != null;
    }

    public void setInventoryObj(GameObject go)
    {
        _inventoryObject = go;
    }

    public void removeInventoryObject()
    {
        Destroy(_inventoryObject);
        _inventoryObject = null;
    }

    public void Respawn()
    {
        removeInventoryObject();
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        gameObject.SetActive(true);
    }

    protected abstract Item CreateItem();
}