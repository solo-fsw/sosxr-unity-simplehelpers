using SOSXR.EditorTools;
using UnityEngine;


public class Cloner : MonoBehaviour
{
    [SerializeField] private GameObject m_prefab;
    [SerializeField] [DisableEditing] private GameObject m_clonedObject;


    public void Clone()
    {
        if (m_clonedObject != null)
        {
            return;
        }

        m_clonedObject = Instantiate(m_prefab, transform.position, transform.rotation);
    }
}