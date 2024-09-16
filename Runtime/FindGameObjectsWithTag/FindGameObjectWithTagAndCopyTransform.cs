using SOSXR.EditorTools;
using UnityEngine;


public class FindGameObjectWithTagAndCopyTransform : MonoBehaviour
{
    [SerializeField] [TagSelector] private string m_tag = "MainCamera";

    [SerializeField] [DisableEditing] private GameObject TaggedGameObject;

    [SerializeField] [Range(1, 10)] private int m_everyXFrames = 3;
    private int _frameCounter;


    private void Update()
    {
        _frameCounter++;

        if (_frameCounter < m_everyXFrames)
        {
            return;
        }

        if (TaggedGameObject == null)
        {
            TaggedGameObject = GameObject.FindWithTag(m_tag);
        }
        else
        {
            transform.position = TaggedGameObject.transform.position;
            transform.rotation = TaggedGameObject.transform.rotation;
            // this.Info("Copied transform from " + TaggedGameObject.name);
        }

        _frameCounter = 0;
    }
}