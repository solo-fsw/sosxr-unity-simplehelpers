using System;
using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    public class Move : MonoBehaviour, ITargetReceiver
    {
        [SerializeField] private ActionToTake m_actionToTake = ActionToTake.MoveTowards;
        [SerializeField] private GameObject m_target;

        // Movement Properties
        [SerializeField] [Range(0f, 500f)] private float m_velocity = 5f;
        [SerializeField] [Range(0f, 360f)] private float m_rotationSpeed = 180f;
        [SerializeField] [Range(0f, 10f)] private float m_springForce = 1f;
        [SerializeField] [Range(0f, 1f)] private float m_damping = 0.98f;

        // Offset Movement Properties
        [SerializeField] private Vector3 m_offset = Vector3.zero;
        [SerializeField] private Vector3[] m_bezierPoints = new Vector3[4];

        // Local Space Movement Properties
        [SerializeField] [Range(0f, 100f)] private float m_localMoveSpeed = 5f;
        [SerializeField] [Range(0f, 100f)] private float m_orbitRadius = 5f;
        [SerializeField] [Range(0f, 100f)] private float m_orbitSpeed = 50f;
        [SerializeField] [Range(0f, 1f)] private float m_amplitude = 0.01f;
        [SerializeField] [Range(0f, 1f)] private float m_frequency = 0.01f;
        [SerializeField] private Vector3 m_bounceStartPoint = Vector3.zero;
        [SerializeField] private Vector3 m_bounceEndPoint = Vector3.zero;
        [SerializeField] [Range(0f, 10f)] private float m_bounceSpeed = 2f;

        // Height Constraints
        [SerializeField] private float m_minimumHeight = 1f;
        [SerializeField] private float m_maximumHeight = 4f;
        [SerializeField] private float m_smoothTime = 1.5f;

        private float m_bezierT = 0f;
        private float m_orbitAngle = 0f;
        private float m_time;
        private bool m_bouncingTowardsEnd = true;
        private Vector3 velocity;

        public GameObject Target
        {
            get => m_target;
            set => m_target = value;
        }


        private void LateUpdate()
        {
            switch (m_actionToTake)
            {
                case ActionToTake.ParentTo:
                    ParentTo();

                    break;
                case ActionToTake.SyncTransform:
                    SyncTransform();

                    break;
                case ActionToTake.MoveTowards:
                    MoveTowards();

                    break;
                case ActionToTake.LookAt:
                    LookAtTarget();

                    break;
                case ActionToTake.RotateTowards:
                    RotateTowards();

                    break;
                case ActionToTake.SmoothMoveTowards:
                    SmoothMoveTowards();

                    break;
                case ActionToTake.MoveByOffset:
                    MoveByOffset();

                    break;
                case ActionToTake.MoveAlongPath:
                    MoveAlongPath();

                    break;
                case ActionToTake.MoveInLocalSpace:
                    MoveInLocalSpace();

                    break;
                case ActionToTake.MoveInCircle:
                    MoveInCircle();

                    break;
                case ActionToTake.MoveSinusoidally:
                    MoveSinusoidally();

                    break;
                case ActionToTake.BounceBackAndForth:
                    BounceBackAndForth();

                    break;
                case ActionToTake.MoveWithElasticity:
                    MoveWithElasticity();

                    break;
                case ActionToTake.SmoothFollow:
                    SmoothFollow();

                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }


        public void ParentTo()
        {
            if (m_target == null)
            {
                return;
            }

            transform.SetParent(m_target.transform);
            transform.rotation = Quaternion.identity;
            transform.localPosition = Vector3.zero;
        }


        public void SyncTransform()
        {
            if (m_target == null)
            {
                return;
            }

            transform.position = m_target.transform.position;
            transform.rotation = m_target.transform.rotation;
        }


        public void MoveTowards()
        {
            if (m_target == null)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, m_target.transform.position, m_velocity * Time.deltaTime);
        }


        public void LookAtTarget()
        {
            if (m_target == null)
            {
                return;
            }

            transform.LookAt(m_target.transform);
        }


        public void RotateTowards()
        {
            if (m_target == null)
            {
                return;
            }

            var targetRotation = Quaternion.LookRotation(m_target.transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, m_rotationSpeed * Time.deltaTime);
        }


        public void SmoothMoveTowards()
        {
            if (m_target == null)
            {
                return;
            }

            transform.position = Vector3.Lerp(transform.position, m_target.transform.position, m_velocity * Time.deltaTime);
        }


        public void MoveByOffset()
        {
            transform.position += m_offset * Time.deltaTime;
        }


        public void MoveAlongPath()
        {
            if (m_bezierPoints.Length < 4)
            {
                return;
            }

            transform.position = GetBezierPoint(m_bezierPoints, m_bezierT);
            m_bezierT += m_velocity * Time.deltaTime;

            if (m_bezierT > 1f)
            {
                m_bezierT = 0f;
            }
        }


        public void MoveInLocalSpace()
        {
            transform.Translate(Vector3.forward * (m_localMoveSpeed * Time.deltaTime), Space.Self);
        }


        public void MoveInCircle()
        {
            if (m_target == null)
            {
                return;
            }

            m_orbitAngle = (m_orbitAngle + m_orbitSpeed * Time.deltaTime) % 360f;
            transform.position = new Vector3(Mathf.Cos(Mathf.Deg2Rad * m_orbitAngle) * m_orbitRadius, transform.position.y, Mathf.Sin(Mathf.Deg2Rad * m_orbitAngle) * m_orbitRadius) + m_target.transform.position;
        }


        public void MoveSinusoidally()
        {
            m_time += Time.deltaTime;

            // Different phase shifts for each axis to create interesting 3D motion
            var xOffset = Mathf.Sin(m_time * m_frequency) * m_amplitude;
            var yOffset = Mathf.Sin(m_time * m_frequency + Mathf.PI / 2) * m_amplitude;
            var zOffset = Mathf.Sin(m_time * m_frequency + Mathf.PI) * m_amplitude;

            transform.position = new Vector3(
                transform.position.x + xOffset,
                transform.position.y + yOffset,
                transform.position.z + zOffset);
        }


        public void BounceBackAndForth()
        {
            transform.position = Vector3.Lerp(transform.position, m_bouncingTowardsEnd ? m_bounceEndPoint : m_bounceStartPoint, m_bounceSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, m_bounceEndPoint) < 0.1f || Vector3.Distance(transform.position, m_bounceStartPoint) < 0.1f)
            {
                m_bouncingTowardsEnd = !m_bouncingTowardsEnd;
            }
        }


        public void MoveWithElasticity()
        {
            if (m_target == null)
            {
                return;
            }

            var direction = m_target.transform.position - transform.position;
            var springForce = direction.normalized * m_springForce;
            transform.position += springForce * Time.deltaTime;
            m_velocity *= m_damping;
            transform.position += direction.normalized * (m_velocity * Time.deltaTime);

            if (Vector3.Distance(transform.position, m_target.transform.position) < 0.01f)
            {
                m_velocity = 0f;
                transform.position = m_target.transform.position;
            }
        }


        private void SmoothFollow()
        {
            if (m_target == null)
            {
                return;
            }

            transform.position = ConstrainHeight(Vector3.SmoothDamp(transform.position, m_target.transform.position, ref velocity, m_smoothTime));
        }


        private Vector3 ConstrainHeight(Vector3 position)
        {
            if (position.y < m_minimumHeight)
            {
                position.y = m_minimumHeight;
            }

            if (position.y > m_maximumHeight)
            {
                position.y = m_maximumHeight;
            }

            return position;
        }


        // Bezier Curve Method
        private Vector3 GetBezierPoint(Vector3[] points, float t)
        {
            var u = 1 - t;
            var tt = t * t;
            var uu = u * u;
            var p = uu * points[0] + 2 * u * t * points[1] + tt * points[2];

            return p;
        }
    }


    public enum ActionToTake
    {
        ParentTo,
        SyncTransform,
        MoveTowards,
        LookAt,
        RotateTowards,
        SmoothMoveTowards,
        MoveByOffset,
        MoveAlongPath,
        MoveInLocalSpace,
        MoveInCircle,
        MoveSinusoidally,
        BounceBackAndForth,
        MoveWithElasticity,
        SmoothFollow
    }
}