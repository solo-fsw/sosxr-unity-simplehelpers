using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    public class DisableIfMaxNumberOfIdenticalObjectsInScene : MonoBehaviour
    {
        [SerializeField] private int m_maxObjectsAllowed = 1;


        public void DisableIfTooManyObjectsFound<T>(T comp) where T : Object
        {
            if (FoundTooManyObjectsOfSameType(comp))
            {
                DisableObject(comp);
            }
        }


        private bool FoundTooManyObjectsOfSameType<T>(T comp) where T : Object
        {
            var objectList = FindObjectsOfType<T>();

            return objectList.Length > m_maxObjectsAllowed;
        }


        private static void DisableObject<T>(T comp) where T : Object
        {
            var obj = comp as MonoBehaviour;

            if (obj != null)
            {
                obj.enabled = false;
            }
        }
    }
}