using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour , IInteracteble
{
    public int _id;
    public bool _open = false;
    private int _openAngle = 110;

    [SerializeField]
    private float _doorSpeed = 1;

    public void Open()
    {
        if (_id == 0 || Inventory._instance.HasKey(_id))
        {
            _open = !_open;
        }
    }

    public void Action()
    {
        Open();
    }

    void Update()
    {
        if(_open && transform.rotation.eulerAngles.y < _openAngle)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, _openAngle, 0), _doorSpeed);
        }
        else if (!_open && transform.rotation.eulerAngles.y > 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), _doorSpeed);
        }
    }
}
