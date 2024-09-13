using UnityEngine;
using UnityEngine.Events;


public class OnEnableUnityEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent m_eventToFire;


    private void OnEnable()
    {
        m_eventToFire?.Invoke();
    }
}