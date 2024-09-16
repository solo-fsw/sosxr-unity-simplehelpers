using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    public class CheckedMultiTransformReparenter : MonoBehaviour
    {
        [SerializeField] private Transform[] m_parentTo;
        [SerializeField] private Transform[] m_toParent;
        [SerializeField] private bool m_zeroOut;


        private void Awake()
        {
            if (m_parentTo.Length != m_toParent.Length)
            {
                Debug.LogError("We have a problem. Lists are not of equal length");

                enabled = false;

                return;
            }

            for (var i = 0; i < m_parentTo.Length; i++)
            {
                if (m_parentTo[i].name == m_toParent[i].name)
                {
                    continue;
                }

                Debug.LogError("We have a problem with" + m_parentTo[i].name + " and " + m_toParent[i].name);

                enabled = false;

                break;
            }

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


        [ContextMenu(nameof(ClearParentTo))]
        private void ClearParentTo()
        {
            m_parentTo = new Transform[] { };
        }


        [ContextMenu(nameof(ClearToParent))]
        private void ClearToParent()
        {
            m_toParent = new Transform[] { };
        }
    }
}