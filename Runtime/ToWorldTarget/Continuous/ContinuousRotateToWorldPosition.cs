using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    /// <summary>
    ///     This uses RotateTowards position.
    ///     Uses real world position (as opposed to localPosition)
    ///     It is set to LateUpdate, so  not for physics.
    /// </summary>
    public class ContinuousRotateToWorldPosition : ContinuousToWorldTargetBase
    {
        [Tooltip("Speed to rotate towards target")]
        [SerializeField] private float m_velocity = 1000f;


        protected override void ToTarget()
        {
            var step = m_velocity * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_target.transform.rotation, step);
        }
    }
}