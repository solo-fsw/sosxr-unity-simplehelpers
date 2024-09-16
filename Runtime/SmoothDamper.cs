using UnityEngine;


public class SmoothDamper : MonoBehaviour
{
    [SerializeField] private string m_targetTag = "Carrot";
    [SerializeField] private Transform m_followTarget;
    [SerializeField] private bool m_requireMinimumHeight = true;
    [SerializeField] private float m_minimumHeight = 1f;
    [SerializeField] private bool m_requireMaximumHeight = true;
    [SerializeField] private float m_maximumHeight = 4f;
    [SerializeField] private float m_smoothTime = 1.5f;

    private Vector3 _velocity;


    private void LateUpdate()
    {
        FindFollowTarget();
        SmoothFollow();
    }


    private void FindFollowTarget()
    {
        if (m_followTarget == null)
        {
            if (GameObject.FindWithTag(m_targetTag) == null)
            {
                return;
            }

            m_followTarget = GameObject.FindWithTag(m_targetTag).transform;
            Debug.Log("Found follow target!");
        }
    }


    private void SmoothFollow()
    {
        if (m_followTarget == null)
        {
            Debug.LogWarning("No follow target found!");

            return;
        }

        var position = transform.position;

        position = Vector3.SmoothDamp(position, m_followTarget.position, ref _velocity, m_smoothTime);

        position = SetMinimumHeight(position);

        position = SetMaximumHeight(position);

        transform.position = position;
    }


    private Vector3 SetMinimumHeight(Vector3 position)
    {
        if (!m_requireMinimumHeight)
        {
            return position;
        }

        if (position.y < m_minimumHeight)
        {
            position.y = m_minimumHeight;
        }

        return position;
    }


    private Vector3 SetMaximumHeight(Vector3 position)
    {
        if (!m_requireMaximumHeight)
        {
            return position;
        }

        if (position.y > m_maximumHeight)
        {
            position.y = m_maximumHeight;
        }

        return position;
    }
}