using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class FindGameObjectsWithTag : MonoBehaviour
{
    [SerializeField] private string m_tag;

    [Header("Do not edit in Inspector")] [SerializeField] private List<GameObject> m_gameObjects;


    public List<GameObject> GameObjects
    {
        get => m_gameObjects;
        private set => m_gameObjects = value;
    }


    private void Start()
    {
        GameObjects = GameObject.FindGameObjectsWithTag(m_tag).ToList();
        Debug.Log($"Found {GameObjects.Count} GameObjects with tag {m_tag}");
    }
}