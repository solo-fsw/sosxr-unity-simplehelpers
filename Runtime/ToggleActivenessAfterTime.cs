using System.Collections;
using UnityEngine;


public class ToggleActivenessAfterTime : MonoBehaviour
{
    [SerializeField] private GameObject m_target;
    [SerializeField] private float m_delay;
    [SerializeField] private bool m_enable;


    private void OnEnable()
    {
        StartCoroutine(ToggleActivenessCR());
    }


    private IEnumerator ToggleActivenessCR()
    {
        if (m_target == null)
        {
            yield break;
        }

        yield return new WaitForSeconds(m_delay);
        m_target.SetActive(m_enable);
    }
}