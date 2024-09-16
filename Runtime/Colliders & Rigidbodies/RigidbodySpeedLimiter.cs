using UnityEngine;


public class RigidbodySpeedLimiter : MonoBehaviour
{
    [SerializeField] private bool m_limitSpeed = true;
    [SerializeField] private float m_maxSpeed = 1f;

    [SerializeField] private Rigidbody m_rigidbody;

    private float _timer;


    private void Awake()
    {
        if (m_rigidbody == null)
        {
            m_rigidbody = GetComponent<Rigidbody>();
        }
    }


    private void FixedUpdate()
    {
        if (m_rigidbody == null)
        {
            Debug.LogError("No Rigidbody was found");
        }

        if (m_limitSpeed == false)
        {
            return;
        }

        if (m_rigidbody.velocity.magnitude > m_maxSpeed)
        {
            m_rigidbody.velocity = Vector3.Lerp(m_rigidbody.velocity, new Vector3(0, 0, 0), _timer);
            _timer += Time.fixedDeltaTime;
        }
        else
        {
            _timer = 0;
        }
    }
}