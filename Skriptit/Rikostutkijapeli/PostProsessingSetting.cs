using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class PostProsessingSetting : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    public PostProcessLayer postProcessLayer;

    public TMP_Dropdown ambientOcclusionDropdown;
    public TMP_Dropdown bloomDropdown;
    public TMP_Dropdown colorGradingDropdown;
//    public TMP_Dropdown lensDistortionDropdown;
    public TMP_Dropdown vignetteDropdown;
    public TMP_Dropdown antiAliasingDropdown;

    private void Awake()
    {
        int loadAntiAliasingMode = PlayerPrefs.GetInt("AntiAliasingActive", 2);

        if (loadAntiAliasingMode == 0)
        {
            postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
        }
        else if (loadAntiAliasingMode == 1)
        {
            postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
        }
        else if (loadAntiAliasingMode == 2)
        {
            postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
        }
        else if (loadAntiAliasingMode == 3)
        {
            postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
        }
    }

    private void Start()
    {
        ambientOcclusionDropdown.value = PlayerPrefs.GetInt("AmbientOcclusionActive", 1);
        bloomDropdown.value = PlayerPrefs.GetInt("BloomActive", 1);
        colorGradingDropdown.value = PlayerPrefs.GetInt("ColorGradingActive", 1);
//        lensDistortionDropdown.value = PlayerPrefs.GetInt("LensDistortionActive", 1);
        vignetteDropdown.value = PlayerPrefs.GetInt("VignetteActive", 1);
        antiAliasingDropdown.value = PlayerPrefs.GetInt("AntiAliasingActive", 2);
    }

    public void AmbientOcclusionActive(int isActive)
    {
        AmbientOcclusion ambientOcclusion;
        postProcessVolume.profile.TryGetSettings(out ambientOcclusion);

        if (isActive == 0)
        {
            ambientOcclusion.active = false;
        }
        else if (isActive == 1)
        {
            ambientOcclusion.active = true;
        }

        PlayerPrefs.SetInt("AmbientOcclusionActive", isActive);
    }

    public void BloomActive(int isActive)
    {
        Bloom bloom;
        postProcessVolume.profile.TryGetSettings(out bloom);

        if (isActive == 0)
        {
            bloom.active = false;
        }
        else if (isActive == 1)
        {
            bloom.active = true;
        }

        PlayerPrefs.SetInt("BloomActive", isActive);
    }

    public void ColorGradingActive(int isActive)
    {
        ColorGrading colorGrading;
        postProcessVolume.profile.TryGetSettings(out colorGrading);

        if (isActive == 0)
        {
            colorGrading.active = false;
        }
        else if (isActive == 1)
        {
            colorGrading.active = true;
        }

        PlayerPrefs.SetInt("ColorGradingActive", isActive);
    }

    public void LensDistortionActive(int isActive)
    {
        LensDistortion lensDistortion;
        postProcessVolume.profile.TryGetSettings(out lensDistortion);

        if (isActive == 0)
        {
            lensDistortion.active = false;
        }
        else if (isActive == 1)
        {
            lensDistortion.active = true;
        }

        PlayerPrefs.SetInt("LensDistortionActive", isActive);
    }

    public void VignetteActive(int isActive)
    {
        Vignette vignette;
        postProcessVolume.profile.TryGetSettings(out vignette);

        if (isActive == 0)
        {
            vignette.active = false;
        }
        else if (isActive == 1)
        {
            vignette.active = true;
        }

        PlayerPrefs.SetInt("VignetteActive", isActive);
    }

    public void AntiAliasingActive(int isActive)
    {
        if (isActive == 0)
        {
            postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
        }
        else if (isActive == 1)
        {
            postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
        }
        else if (isActive == 2)
        {
            postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
        }
        else if (isActive == 3)
        {
            postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
        }

        PlayerPrefs.SetInt("AntiAliasingActive", isActive);
    }
}
