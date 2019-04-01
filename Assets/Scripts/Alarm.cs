using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField]
    private Door _activator;

    [SerializeField]
    private bool _hasToBe;

    [SerializeField]
    private GameObject _light;

    void Update()
    {
        if (_activator._open == _hasToBe)
        {
            _light.SetActive(true);
        }
    }
}
