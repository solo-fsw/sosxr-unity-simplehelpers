using System;
using UnityEngine;


public class RendererToggler : MonoBehaviour
{
    [SerializeField] private bool m_startDisabled;
    [SerializeField] private bool m_toggleRenderers = true;
    private Renderer[] _renderers = Array.Empty<Renderer>();


    private void Awake()
    {
        _renderers = GetComponentsInChildren<Renderer>();
    }


    private void Start()
    {
        if (m_startDisabled)
        {
            DisableRenderers();
        }
    }


    public void DisableRenderers()
    {
        if (!m_toggleRenderers)
        {
            return;
        }

        foreach (var rend in _renderers)
        {
            rend.enabled = false;
        }
    }


    public void EnableRenderers()
    {
        if (!m_toggleRenderers)
        {
            return;
        }

        foreach (var rend in _renderers)
        {
            rend.enabled = true;
        }
    }


    public void EnableRenderersExcept(Renderer exceptRenderer)
    {
        if (!m_toggleRenderers)
        {
            return;
        }

        foreach (var rend in _renderers)
        {
            if (rend == exceptRenderer)
            {
                continue;
            }

            rend.enabled = true;
        }
    }


    public void DisableRenderersExcept(Renderer exceptRenderer)
    {
        if (!m_toggleRenderers)
        {
            return;
        }

        foreach (var rend in _renderers)
        {
            if (rend == exceptRenderer)
            {
                continue;
            }

            rend.enabled = false;
        }
    }
}