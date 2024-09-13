using UnityEngine;


public class FindCollidersInScene : MonoBehaviour
{
    [SerializeField] protected Collider[] m_allColliders;


    [ContextMenu(nameof(FindAllColliders))]
    protected virtual void FindAllColliders()
    {
        m_allColliders = FindObjectsOfType<Collider>();
    }


    [ContextMenu(nameof(DeleteAllColliders))]
    private void DeleteAllColliders()
    {
        foreach (var coll in m_allColliders)
        {
            DestroyImmediate(coll);
        }
    }
}