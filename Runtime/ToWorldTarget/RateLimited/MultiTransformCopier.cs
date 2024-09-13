using SOSXR.EnhancedLogger;
using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    public class MultiTransformCopier : MonoBehaviour
    {
        public Transform[] CopyFrom;

        public Transform[] CopyTo;

        [Header("Choose as few as possible")]
        [SerializeField] private bool m_copyLocalPosition = true;
        [SerializeField] private bool m_copyLocalRotation = true;
        [SerializeField] private bool m_copyLocalScale = false;

        [Header("Choose One")]
        [SerializeField] private bool m_runOnUpdate = true;
        [SerializeField] private bool m_runOnFixedUpdate;
        [SerializeField] private bool m_runOnLateUpdate;


        private void Start()
        {
            if (CopyFrom.Length != CopyTo.Length)
            {
                this.Error("We have a problem. Lists are not of equal length");

                enabled = false;

                return;
            }

            for (var i = 0; i < CopyFrom.Length; i++)
            {
                if (CopyFrom[i].name == CopyTo[i].name)
                {
                    continue;
                }

                this.Error("We have a problem with", CopyFrom[i].name, "and", CopyTo[i].name);

                enabled = false;

                break;
            }
        }


        private void FixedUpdate()
        {
            if (!m_runOnFixedUpdate)
            {
                return;
            }

            CopyPosition();

            CopyRotation();

            CopyScale();
        }


        private void Update()
        {
            if (!m_runOnUpdate)
            {
                return;
            }

            CopyPosition();

            CopyRotation();

            CopyScale();
        }


        private void LateUpdate()
        {
            if (!m_runOnLateUpdate)
            {
                return;
            }

            CopyPosition();

            CopyRotation();

            CopyScale();
        }


        private void CopyPosition()
        {
            if (!m_copyLocalPosition)
            {
                return;
            }

            for (var i = 0; i < CopyFrom.Length; i++)
            {
                CopyTo[i].localPosition = CopyFrom[i].localPosition;
            }
        }


        private void CopyRotation()
        {
            if (!m_copyLocalRotation)
            {
                return;
            }

            for (var i = 0; i < CopyFrom.Length; i++)
            {
                CopyTo[i].localRotation = CopyFrom[i].localRotation;
            }
        }


        private void CopyScale()
        {
            if (!m_copyLocalScale)
            {
                return;
            }

            for (var i = 0; i < CopyFrom.Length; i++)
            {
                CopyTo[i].localScale = CopyFrom[i].localScale;
            }
        }


        [ContextMenu(nameof(ClearFromList))]
        private void ClearFromList()
        {
            CopyFrom = new Transform[] { };
        }


        [ContextMenu(nameof(ClearToList))]
        private void ClearToList()
        {
            CopyTo = new Transform[] { };
        }
    }
}