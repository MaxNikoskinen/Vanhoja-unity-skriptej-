using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VSyncSetting : MonoBehaviour 
{
    [SerializeField] private TMP_Dropdown vSyncDropdown;

    private void Start()
    {
        vSyncDropdown.value = PlayerPrefs.GetInt("VSyncMode", 1);
    }

    public void SetVsync(int vsyncIndex)
	{
		QualitySettings.vSyncCount = vsyncIndex;
        PlayerPrefs.SetInt("VSyncMode", vsyncIndex);
    }
}
