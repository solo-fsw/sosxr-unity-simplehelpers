using UnityEngine;
using UnityEngine.Events;


public class OnDisableUnityEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent m_eventToFire;


    private void OnDisable()
    {
        m_eventToFire?.Invoke();
    }
}