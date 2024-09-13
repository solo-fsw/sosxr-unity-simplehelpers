using SOSXR.Attributes;
using SOSXR.EnhancedLogger;
using UnityEngine;


public class RotateTowardsTaggedObject : MonoBehaviour
{
    [TagSelector] [SerializeField] private string m_tagToRotateTo = "MainCamera";

    [SerializeField] private Vector3Int m_rotationOffset = new(0, 180, 0);
    private readonly int _everyXframes = 10;
    private readonly float _speed = 10;

    private Transform _target;
    private int _counter;

    public Vector3Int RotationOffset
    {
        get => m_rotationOffset;
        set
        {
            m_rotationOffset = value;
            this.Info("Set RotationOffset to", value);
        }
    }


    private void Awake()
    {
        FoundTransform();
    }


    private bool FoundTransform()
    {
        if (_target != null)
        {
            return true;
        }

        var go = GameObject.FindGameObjectWithTag(m_tagToRotateTo);

        if (go != null)
        {
            _target = go.transform;

            return true;
        }

        return false;
    }


    private void Update()
    {
        _counter++;

        if (_counter <= _everyXframes)
        {
            return;
        }

        if (FoundTransform())
        {
            var directionToTarget = _target.position - transform.position;

            if (directionToTarget == Vector3.zero)
            {
                directionToTarget = new Vector3(.01f, .01f, .01f);
                this.Info("Set directionToTarget manually because it was at zero");
            }

            var lookRotation = Quaternion.LookRotation(directionToTarget);
            var adjustmentRotation = Quaternion.Euler(m_rotationOffset);
            lookRotation *= adjustmentRotation;

            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * _speed);
        }

        _counter = 0;
    }
}