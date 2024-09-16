using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    public class AddOrRemoveCollider : MonoBehaviour
    {
        [SerializeField] private TypeOfCollider _colliderType = TypeOfCollider.MeshCollider;
        private Collider _collider;


        private void Awake()
        {
            GameObjectAlreadyHasAttachedCollider();
        }


        private bool GameObjectAlreadyHasAttachedCollider()
        {
            if (GetComponent<Collider>() == null)
            {
                return false;
            }

            _collider = GetComponent<Collider>();

            return true;
        }


        public void AddColliderOfType()
        {
            if (GameObjectAlreadyHasAttachedCollider())
            {
                return;
            }

            if (_colliderType == TypeOfCollider.MeshCollider)
            {
                _collider = gameObject.AddComponent<MeshCollider>();
            }
            else if (_colliderType == TypeOfCollider.BoxCollider)
            {
                _collider = gameObject.AddComponent<BoxCollider>();
            }
            else
            {
                Debug.LogError("ColliderType does not exist");
            }
        }


        public void RemoveCollider()
        {
            if (GameObjectAlreadyHasAttachedCollider())
            {
                Destroy(_collider);
            }
        }
    }
}