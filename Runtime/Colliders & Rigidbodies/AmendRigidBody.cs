using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    [RequireComponent(typeof(Rigidbody))]
    public class AmendRigidBody : MonoBehaviour
    {
        private Rigidbody _rigidbody;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }


        public void SetFreezeAll(bool freeze)
        {
            if (freeze)
            {
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }
            else
            {
                _rigidbody.constraints = RigidbodyConstraints.None;
            }
        }


        public void FreezeAll()
        {
            SetFreezeAll(true);
        }


        public void UnFreezeAll()
        {
            SetFreezeAll(false);
        }


        public void SetKinematic(bool kinematic)
        {
            _rigidbody.isKinematic = kinematic;
        }


        public void IsKinematic()
        {
            SetKinematic(true);
        }


        public void IsNotKinematic()
        {
            SetKinematic(false);
        }


        public void SetGravity(bool gravity)
        {
            _rigidbody.useGravity = gravity;
        }


        public void UseGravity()
        {
            SetGravity(true);
        }


        public void DoNotUseGravity()
        {
            SetGravity(false);
        }
    }
}