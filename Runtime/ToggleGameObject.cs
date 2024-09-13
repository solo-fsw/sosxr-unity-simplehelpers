using UnityEngine;


public class ToggleGameObject : MonoBehaviour
{
    [SerializeField] private GameObject m_gameObject;


    [ContextMenu(nameof(Toggle))]
    public void Toggle()
    {
        if (m_gameObject == null)
        {
            return;
        }

        m_gameObject.SetActive(!m_gameObject.activeInHierarchy);
    }
}