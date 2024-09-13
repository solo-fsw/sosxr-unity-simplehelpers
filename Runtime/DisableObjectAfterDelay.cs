using UnityEngine;


public class DisableObjectAfterDelay : MonoBehaviour
{
    [SerializeField] private GameObject m_objectToDisable;
    [SerializeField] private float m_disableAfter = 1f;


    public void DisableAfterDelay()
    {
        Invoke(nameof(DisableObject), m_disableAfter);
    }


    private void DisableObject()
    {
        if (m_objectToDisable != null)
        {
            m_objectToDisable.SetActive(false);
        }
    }
}