using System.Collections.Generic;
using System.Linq;
using SOSXR.EditorTools;
using SOSXR.EnhancedLogger;
using UnityEngine;


public class FindGameObjectsWithTag : MonoBehaviour
{
    [SerializeField] [TagSelector] private string m_tag;

    [DisableEditing] [SerializeField] private List<GameObject> m_gameObjects;


    public List<GameObject> GameObjects
    {
        get => m_gameObjects;
        private set => m_gameObjects = value;
    }


    private void Start()
    {
        GameObjects = GameObject.FindGameObjectsWithTag(m_tag).ToList();
        this.Info($"Found {GameObjects.Count} GameObjects with tag {m_tag}");
    }
}