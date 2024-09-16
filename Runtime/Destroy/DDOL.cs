using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    /// <summary>
    ///     Attach to gameobject, and enable bool dontDestroy, to make sure it stays loaded between scenes
    /// </summary>
    public class DDOL : MonoBehaviour
    {
        [SerializeField] private bool m_doNotDestroyOnLoad = true;


        private void Awake()
        {
            if (m_doNotDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
                Debug.Log("This GameObject will not be destroyed on scene load");
            }
        }
    }
}