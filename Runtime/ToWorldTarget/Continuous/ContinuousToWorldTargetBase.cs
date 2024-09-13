using SOSXR.EnhancedLogger;
using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    public abstract class ContinuousToWorldTargetBase : MonoBehaviour
    {
        [SerializeField] protected Transform m_target;


        private void Awake()
        {
            if (m_target == null)
            {
                m_target = transform;
            }
        }


        private void LateUpdate()
        {
            if (m_target == null || m_target.gameObject.activeInHierarchy != true)
            {
                FindTarget();

                return;
            }

            ToTarget();
        }


        protected virtual void FindTarget()
        {
            this.Info(nameof(FindTarget));
        }


        protected abstract void ToTarget();
    }
}