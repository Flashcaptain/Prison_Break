using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _range = 2;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _runSpeed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private GameObject _inventoryMenu;

    private bool _UI;

    void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SetInventoryVisible(!InventoryUI._instance.gameObject.activeSelf);
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, moveHorizontal * _rotationSpeed, 0));

        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, 0, moveVertical);

        if (Input.GetButton("Sprint"))
        {
            _rigidbody.AddRelativeForce(movement * _runSpeed);
        }
        else
        {
            _rigidbody.AddRelativeForce(movement * _speed);
        }
    }

    public void SetInventoryVisible(bool value)
    {
        InventoryUI._instance.gameObject.SetActive(value);
        Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
    }

    void Interact()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _range))
        {
            IInteracteble i = hit.collider.gameObject.GetComponent<IInteracteble>();
            if (i != null)
            {
                i.Action();
            }
        }
    }
}
