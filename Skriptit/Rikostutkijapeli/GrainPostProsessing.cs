using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GrainPostProsessing : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;

    public bool disableOnStart = true;

    void Start()
    {
        Grain grain;
        postProcessVolume.profile.TryGetSettings(out grain);

        if (disableOnStart == true)
        {
            grain.active = false;
        }
        else if (disableOnStart == false)
        {
            grain.active = true;
        }
    }

    public void DisableGrain()
    {
        Grain grain;
        postProcessVolume.profile.TryGetSettings(out grain);
        grain.active = false;
    }

    public void EnableGrain()
    {
        Grain grain;
        postProcessVolume.profile.TryGetSettings(out grain);
        grain.active = true;
    }
}
