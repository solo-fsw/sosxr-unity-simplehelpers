using System;
using System.Collections.Generic;
using UnityEngine;


public class RendererDefaultColorManager : MonoBehaviour
{
    [SerializeField] private bool m_setDefaultColor;
    [SerializeField] private Color m_defaultColor = Color.white;
    [SerializeField] private bool m_changeAlpha = false;


    [SerializeField] private List<Renderer> m_excludeColoringRenderers;

    private Renderer[] _renderers = Array.Empty<Renderer>();


    private void Awake()
    {
        _renderers = GetComponentsInChildren<Renderer>();
    }


    private void Start()
    {
        if (!m_setDefaultColor)
        {
            return;
        }

        foreach (var rend in _renderers)
        {
            if (m_excludeColoringRenderers.Contains(rend))
            {
                continue;
            }

            foreach (var sharedMaterial in rend.sharedMaterials)
            {
                if (!m_changeAlpha)
                {
                    var color = m_defaultColor;
                    color.a = sharedMaterial.color.a;
                    sharedMaterial.color = color;
                }
                else
                {
                    sharedMaterial.color = m_defaultColor;
                }
            }
        }
    }
}