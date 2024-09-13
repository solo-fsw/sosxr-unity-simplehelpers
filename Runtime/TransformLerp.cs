using UnityEngine;


public class TransformLerp : MonoBehaviour
{
    [SerializeField] private Transform m_transform;
    [SerializeField] private bool m_useLocalPosition;
    [SerializeField] private Vector3 m_moveToPosition;
    [SerializeField] private float m_moveSpeed = 1f;
    private bool _enabled = false;
    private bool _lerpToNew = false;
    private bool _lerpToStart = false;
    private Vector3 _startPosition;


    private void Start()
    {
        if (m_useLocalPosition)
        {
            _startPosition = m_transform.localPosition;
        }
        else
        {
            _startPosition = m_transform.position;
        }
    }


    [ContextMenu(nameof(LerpToNewPosition))]
    public void LerpToNewPosition()
    {
        _enabled = true;
        _lerpToStart = false;
        _lerpToNew = true;
    }


    [ContextMenu(nameof(LerpToNewPosition))]
    public void LerpToStartPosition()
    {
        _enabled = true;
        _lerpToStart = true;
        _lerpToNew = false;
    }


    [ContextMenu(nameof(StopLerping))]
    public void StopLerping()
    {
        _enabled = false;
        _lerpToStart = false;
        _lerpToNew = false;
    }


    private void Update()
    {
        if (!_enabled)
        {
            return;
        }

        if (_lerpToNew)
        {
            if (m_useLocalPosition)
            {
                m_transform.localPosition = Vector3.Lerp(m_transform.localPosition, m_moveToPosition, Time.deltaTime * m_moveSpeed);
            }
            else
            {
                m_transform.position = Vector3.Lerp(m_transform.position, m_moveToPosition, Time.deltaTime * m_moveSpeed);
            }
        }

        else if (_lerpToStart)
        {
            if (m_useLocalPosition)
            {
                m_transform.localPosition = Vector3.Lerp(m_transform.localPosition, _startPosition, Time.deltaTime * m_moveSpeed);
            }
            else
            {
                m_transform.position = Vector3.Lerp(m_transform.position, _startPosition, Time.deltaTime * m_moveSpeed);
            }
        }
    }
}