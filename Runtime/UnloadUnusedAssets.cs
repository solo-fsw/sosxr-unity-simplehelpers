using System.Collections;
using UnityEngine;


public class UnloadUnusedAssets : MonoBehaviour
{
    [SerializeField] [Range(-1, 60 * 5)] private float m_autoUnloadInterval = 10f;
    private Coroutine _unloadCoroutine;


    private void OnEnable()
    {
        if (m_autoUnloadInterval <= 0)
        {
            Debug.Log("Interval is 0 or less, so not auto-looping the unloading of unused assets");

            return;
        }

        if (_unloadCoroutine != null)
        {
            StopCoroutine(_unloadCoroutine);
        }

        _unloadCoroutine = StartCoroutine(UnloadCR());
    }


    private IEnumerator UnloadCR()
    {
        for (;;)
        {
            yield return new WaitForSeconds(m_autoUnloadInterval);
            UnloadUnusedAssetsFromGame();
        }
    }


    [ContextMenu(nameof(UnloadUnusedAssetsFromGame))]
    public void UnloadUnusedAssetsFromGame()
    {
        Resources.UnloadUnusedAssets();
        Debug.Log("Unloaded unused assets");
    }


    private void OnDisable()
    {
        StopAllCoroutines();
    }
}