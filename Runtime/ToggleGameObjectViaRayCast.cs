using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    public class ToggleGameObjectViaRayCast : MonoBehaviour
    {
        [SerializeField] private GameObject m_gameObjectToToggle;
        [SerializeField] private GameObject m_raycastTarget;
        public float RaycastDistance = 1f;

        public RaycastHit Hit { get; private set; }


        private void Update()
        {
            var ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out var hit, RaycastDistance))
            {
                Hit = hit;

                if (hit.transform.gameObject == m_raycastTarget)
                {
                    Debug.Log("We hit our target!");
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
                    m_gameObjectToToggle.SetActive(true);
                }
                else
                {
                    Debug.Log("We hit something else!");
                    m_gameObjectToToggle.SetActive(false);
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.blue);
                }
            }
            else
            {
                Debug.Log("We hit nothing!");
                m_gameObjectToToggle.SetActive(false);
                Debug.DrawRay(ray.origin, ray.direction * RaycastDistance, Color.red);
                Hit = new RaycastHit();
            }
        }
    }
}