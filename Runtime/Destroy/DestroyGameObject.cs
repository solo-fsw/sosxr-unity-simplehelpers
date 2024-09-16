using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    public class DestroyGameObject : MonoBehaviour
    {
        [SerializeField] private GameObject m_target;
        [SerializeField] private float m_delay = 0.25f;


        public void DestroyAfterDelay()
        {
            if (m_target == null)
            {
                Debug.LogError("No Gameobject has been set to destroy");

                return;
            }

            Destroy(m_target, m_delay);
        }
    }
}