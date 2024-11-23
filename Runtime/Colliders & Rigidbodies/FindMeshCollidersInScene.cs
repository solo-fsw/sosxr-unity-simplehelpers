using UnityEngine;


public class FindMeshCollidersInScene : FindCollidersInScene
{
    [ContextMenu(nameof(FindAllColliders))]
    protected override void FindAllColliders()
    {
        m_allColliders = FindObjectsByType<MeshCollider>(FindObjectsSortMode.None);
    }
}