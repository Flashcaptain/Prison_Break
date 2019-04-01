using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButtonBehaviour : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void HandleClick()
    {
        Inventory._instance.removeByName(transform.GetChild(0).GetComponent<Text>().text);
        player.SetInventoryVisible(false);
    }
}
