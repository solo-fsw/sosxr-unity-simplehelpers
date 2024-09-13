using UnityEngine;


public class QuitApplication : MonoBehaviour
{
    [SerializeField] private bool m_quitApplication = true;
    [SerializeField] private float m_quitDelay = 7.5f;


    private void Start()
    {
        if (m_quitApplication != true)
        {
            return;
        }

        if (m_quitDelay < 0)
        {
            m_quitDelay = 0;
        }

        Invoke(nameof(QuitApplication), m_quitDelay);
    }


    public void Quit()
    {
        Application.Quit();
    }
}