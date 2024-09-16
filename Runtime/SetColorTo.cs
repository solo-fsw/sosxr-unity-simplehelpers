using System.Collections.Generic;
using UnityEngine;


public class SetColorTo : MonoBehaviour
{
    [SerializeField] private Color m_color = Color.white;
    [SerializeField] private List<Material> m_materials = new();
    [SerializeField] private bool m_setAtStart = true;
    [SerializeField] private bool m_setAtApllicationQuit = true;


    private void Start()
    {
        if (!m_setAtStart)
        {
            return;
        }

        SetColor();
    }


    private void SetColor()
    {
        m_materials.ForEach(m => m.color = m_color);
        Debug.Log("Setting color to " + m_color + " on List of Materials");
    }


    private void OnApplicationQuit()
    {
        if (!m_setAtApllicationQuit)
        {
            return;
        }

        SetColor();
    }
}