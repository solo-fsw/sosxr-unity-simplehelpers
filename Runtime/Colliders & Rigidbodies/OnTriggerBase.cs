using UnityEngine;


[RequireComponent(typeof(Collider))]
public abstract class OnTriggerBase : MonoBehaviour
{
    [Header("This GameObject")]
    [SerializeField] private Rigidbody m_thisRigidbody;

    [Header("Other GameObject")]
    public bool FindWithTag = true;
    [SerializeField] protected string m_otherColliderTag;
    [SerializeField] protected Collider m_otherCollider;
    [SerializeField] private Rigidbody m_otherRididbody;

    private bool _initialised;
    private Collider _thisCollider;


    private void Awake()
    {
        Initialised();
    }


    private bool Initialised()
    {
        if (_initialised)
        {
            return true;
        }

        if (!HaveColliders())
        {
            return _initialised = false;
        }

        if (!OneColliderIsSetAsTriggers())
        {
            return _initialised = false;
        }

        if (!AtLeastOneColliderHasRigidbody())
        {
            return _initialised = false;
        }

        return _initialised = true;
    }


    private bool HaveColliders()
    {
        if (_thisCollider == null)
        {
            _thisCollider = GetComponent<Collider>();
        }

        if (FindWithTag)
        {
            m_otherCollider = GameObject.FindWithTag(m_otherColliderTag).GetComponent<Collider>();
        }

        if (_thisCollider != null && m_otherCollider != null)
        {
            return true;
        }

        Debug.LogError("Not all colliders are found");

        return false;
    }


    private bool OneColliderIsSetAsTriggers()
    {
        if (_thisCollider.isTrigger || m_otherCollider.isTrigger) // ^
        {
            return true;
        }

        Debug.LogError("We need exactly 1 collider to be marked as Trigger");

        return false;
    }


    private bool AtLeastOneColliderHasRigidbody()
    {
        if (m_thisRigidbody != null || m_otherRididbody != null)
        {
            return true;
        }

        if (_thisCollider.GetComponent<Rigidbody>() || m_otherCollider.GetComponent<Rigidbody>())
        {
            return true;
        }

        Debug.LogError("Not enough Rigidbodies for this Trigger to work");

        return false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other != m_otherCollider)
        {
            return;
        }

        if (!Initialised())
        {
            Debug.LogError("Initalisation has not been successful");

            return;
        }


        TriggerEnter();
    }


    protected abstract void TriggerEnter();


    private void OnTriggerStay(Collider other)
    {
        if (other != m_otherCollider)
        {
            return;
        }

        if (!Initialised())
        {
            Debug.LogError("Initalisation has not been successful");

            return;
        }

        TriggerStay();
    }


    protected abstract void TriggerStay();


    private void OnTriggerExit(Collider other)
    {
        if (other != m_otherCollider)
        {
            return;
        }

        if (!Initialised())
        {
            Debug.LogError("Initalisation has not been successful");

            return;
        }

        TriggerExit();
    }


    protected abstract void TriggerExit();
}