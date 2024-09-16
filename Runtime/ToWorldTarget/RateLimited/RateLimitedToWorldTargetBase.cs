using System.Collections;
using SOSXR.EditorTools;
using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    public abstract class RateLimitedToWorldTargetBase : MonoBehaviour
    {
        [SerializeField] private bool m_requiresTarget = true;
        [SerializeField] [BoxRange(0.001f, 1f)] protected float m_inverseRepeatRate = 0.1f;

        private Coroutine _coroutine;
        protected Transform Target;

        public float InverseRepeatRate
        {
            get => m_inverseRepeatRate;
            set => m_inverseRepeatRate = value;
        }


        private void Update()
        {
            if (m_requiresTarget && Target == null)
            {
                FindTarget();
            }

            if (Target == null)
            {
                return;
            }

            _coroutine ??= StartCoroutine(ToTargetCR());
        }


        protected virtual void FindTarget()
        {
        }


        protected abstract IEnumerator ToTargetCR();


        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}