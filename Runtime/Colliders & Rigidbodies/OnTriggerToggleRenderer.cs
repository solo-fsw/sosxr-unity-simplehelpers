using System.Collections.Generic;
using UnityEngine;


public class OnTriggerToggleRenderer : OnTriggerBase
{
    [SerializeField] private List<Renderer> m_renderersToToggle;
    [SerializeField] private bool m_toggleValueOnTriggerEnter;


    private void ToggleRenderers(bool enable)
    {
        foreach (var render in m_renderersToToggle)
        {
            render.enabled = enable;
        }
    }


    protected override void TriggerEnter()
    {
        ToggleRenderers(m_toggleValueOnTriggerEnter);
    }


    protected override void TriggerStay()
    {
        // Do nothing
    }


    protected override void TriggerExit()
    {
        ToggleRenderers(!m_toggleValueOnTriggerEnter);
    }
}