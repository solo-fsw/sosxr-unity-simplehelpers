using SOSXR.EditorTools;
using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    public class GameObjectFinderAndTransformMatcher : MonoBehaviour
    {
        [TagSelector] [SerializeField] private string m_gameObjectTag = "MainCamera";

        private GameObject _foundObject;


        private void Update()
        {
            if (_foundObject == null)
            {
                if (GameObject.FindWithTag(m_gameObjectTag) != null)
                {
                    _foundObject = GameObject.FindWithTag(m_gameObjectTag);
                }
            }

            if (_foundObject != null)
            {
                transform.parent = _foundObject.transform;
            }

            enabled = false;
        }
    }
}