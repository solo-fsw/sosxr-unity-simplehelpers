using System.Collections.Generic;
using SOSXR.Attributes;
using SOSXR.EnhancedLogger;
using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    /// <summary>
    ///     Allows culling excess gameobjects
    /// </summary>
    [ExecuteInEditMode]
    public class Decimator : MonoBehaviour
    {
        public List<GameObject> ObjectsToDecimate;
        [BoxRange(0, 100)] public int Percentage = 10;


        [ContextMenu(nameof(Decimate))]
        private void Decimate()
        {
            Decimate(Percentage);
        }


        private void Decimate(int percentage)
        {
            if (percentage == 0)
            {
                this.Warning("This makes no sense. Decimate more please");

                return;
            }

            var numberOfObjects = ObjectsToDecimate.Count;
            var killCount = numberOfObjects / Percentage;
            var counter = 0;

            for (var i = ObjectsToDecimate.Count - 1; i >= 0; i--)
            {
                if (counter >= killCount)
                {
                    var removeThis = ObjectsToDecimate[i];
                    ObjectsToDecimate.Remove(removeThis);
                    DestroyImmediate(removeThis);
                    counter = 0;
                }

                counter++;
            }
        }
    }
}