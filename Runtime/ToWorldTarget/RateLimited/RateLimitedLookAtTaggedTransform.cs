using System.Collections;
using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    public class RateLimitedLookAtTaggedTransform : RateLimitedToWorldTargetBase
    {
        [SerializeField] private string m_targetTag = "MainCamera";


        protected override void FindTarget()
        {
            if (Target == null)
            {
                if (GameObject.FindWithTag(m_targetTag) == null)
                {
                    return;
                }

                Target = GameObject.FindWithTag(m_targetTag).transform;
            }

            if (Target != null)
            {
                return;
            }

            Debug.LogError("Cannot find the correct Tagged Target");
        }


        protected override IEnumerator ToTargetCR()
        {
            if (Target == null)
            {
                yield return null;
            }

            for (;;)
            {
                yield return new WaitForSeconds(m_inverseRepeatRate);
                transform.LookAt(Target);
            }
        }
    }
}