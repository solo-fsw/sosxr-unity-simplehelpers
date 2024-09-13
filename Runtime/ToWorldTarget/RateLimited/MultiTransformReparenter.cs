using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    public class MultiTransformReparenter : MonoBehaviour
    {
        [SerializeField] private Transform[] m_parentTo;

        [SerializeField] private Transform[] m_toParent;

        [SerializeField] private bool m_zeroOut;


        private void Start()
        {
            Parenting();
        }


        private void Parenting()
        {
            for (var i = m_parentTo.Length - 1; i >= 0; i--)
            {
                m_toParent[i].localPosition = m_parentTo[i].localPosition;

                m_toParent[i].parent = m_parentTo[i];

                if (m_zeroOut)
                {
                    m_toParent[i].localPosition = new Vector3();
                    m_toParent[i].localRotation = new Quaternion();
                    m_toParent[i].localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }
}