using SOSXR.EnhancedLogger;
using UnityEngine;


/// <summary>
///     Because Netcode for GameObjects is a pain when it comes to setting the Active Scene, we need to set the lighting
///     settings manually.
/// </summary>
public class SetLightingSettings : MonoBehaviour
{
    [SerializeField] private Material m_skyboxMaterial;
    [Tooltip("Set to below 0 to not change the ambient intensity")]
    [SerializeField] [Range(-1f, 8f)] private float m_intensityMultiplier = 3f;


    private void Awake()
    {
        SetSkybox();

        SetAmbientIntensity();
    }


    public void SetSkybox()
    {
        if (m_skyboxMaterial == null)
        {
            this.Warning("Cannot change the skybox because it's null, it this intentional?");

            return;
        }

        RenderSettings.skybox = m_skyboxMaterial;
    }


    public void SetAmbientIntensity()
    {
        if (m_intensityMultiplier < 0)
        {
            this.Info("Apparently we're not changing the ambient intensity, since it was set to below 0.");

            return;
        }

        RenderSettings.ambientIntensity = m_intensityMultiplier;
    }
}