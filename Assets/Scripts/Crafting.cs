using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField]
    private List<string> _craftableItems;

    [SerializeField]
    private List<GameObject> _craftables;

    void OnTriggerEnter(Collider TEnter)
    {
        Bonus bonus = TEnter.GetComponent<Bonus>();
        if (bonus == null)
        {
            return;
        }
        Debug.Log(bonus._objectName);

        for (int i = 0; i < _craftableItems.Count; i++)
        {
            if (bonus._objectName == _craftableItems[i])
            {
                Debug.Log("yes");
                Instantiate(_craftables[i], transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0));
                Destroy(TEnter.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
