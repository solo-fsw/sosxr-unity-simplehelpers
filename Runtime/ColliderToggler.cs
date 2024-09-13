using System;
using UnityEngine;


public class ColliderToggler : MonoBehaviour
{
    [SerializeField] private bool m_startDisabled;
    [SerializeField] private bool m_toggleColliders = true;
    private Collider[] _colliders = Array.Empty<Collider>();


    private void Awake()
    {
        _colliders = GetComponentsInChildren<Collider>();
    }


    private void Start()
    {
        if (m_startDisabled)
        {
            DisableColliders();
        }
    }


    public void DisableColliders()
    {
        if (!m_toggleColliders)
        {
            return;
        }

        foreach (var col in _colliders)
        {
            col.enabled = false;
        }
    }


    public void EnableColliders()
    {
        if (!m_toggleColliders)
        {
            return;
        }

        foreach (var col in _colliders)
        {
            col.enabled = true;
        }
    }
}