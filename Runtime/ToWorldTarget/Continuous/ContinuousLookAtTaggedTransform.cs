using UnityEngine;
using UnityEngine.Serialization;


namespace SOSXR.SimpleHelpers
{
    public class ContinuousLookAtTaggedTransform : ContinuousToWorldTargetBase
    {
        [FormerlySerializedAs("TargetTag")] [SerializeField] private string m_targetTag = "MainCamera";


        protected override void ToTarget()
        {
            transform.LookAt(m_target);
        }


        protected override void FindTarget()
        {
            if (m_target == null)
            {
                m_target = GameObject.FindWithTag(m_targetTag).transform;
            }

            ;

            if (m_target != null)
            {
                return;
            }

            Debug.LogError("Cannot find the correct Tagged Target");
        }
    }
}