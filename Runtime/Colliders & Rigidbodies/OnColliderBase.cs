using SOSXR.EnhancedLogger;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public abstract class OnColliderBase : MonoBehaviour
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


    protected virtual void Awake()
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

        if (!NoColliderIsSetAsTriggers())
        {
            return _initialised = false;
        }

        if (!AtLeastOneColliderHasNonKinematicRigidbody())
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

        this.Error("Not all colliders are found");

        return false;
    }


    private bool NoColliderIsSetAsTriggers()
    {
        /*if (_thisCollider.isTrigger || m_otherCollider.isTrigger) // ^
        {
            this.Error("One of the colliders is falsely set as Trigger");

            return false;
        }*/

        return true;
    }


    private bool AtLeastOneColliderHasNonKinematicRigidbody()
    {
        /*if (m_thisRigidbody != null && m_thisRigidbody.isKinematic || m_otherRididbody != null && m_otherRididbody.isKinematic)
        {
            return true;
        }

        if (_thisCollider.GetComponent<Rigidbody>() && _thisCollider.GetComponent<Rigidbody>().isKinematic || m_otherCollider.GetComponent<Rigidbody>() && m_otherCollider.GetComponent<Rigidbody>().isKinematic)
        {
            return true;
        }*/

        //this.Error("Not enough NonKinematic Rigidbodies for this Trigger to work");

        //return false;
        return true;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider != m_otherCollider)
        {
            return;
        }

        if (!Initialised())
        {
            this.Error("Initalisation has not been successful");

            return;
        }


        CollisionEnter();
    }


    protected abstract void CollisionEnter();


    private void OnCollisionStay(Collision other)
    {
        if (other.collider != m_otherCollider)
        {
            return;
        }

        if (!Initialised())
        {
            this.Error("Initalisation has not been successful");

            return;
        }

        CollisionStay();
    }


    protected abstract void CollisionStay();


    private void OnCollisionExit(Collision other)
    {
        if (other.collider != m_otherCollider)
        {
            return;
        }

        if (!Initialised())
        {
            this.Error("Initalisation has not been successful");

            return;
        }

        CollisionExit();
    }


    protected abstract void CollisionExit();
}