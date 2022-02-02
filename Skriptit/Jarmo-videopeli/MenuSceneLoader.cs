using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class MenuSceneLoader : MonoBehaviour
{
    [SerializeField] TMP_InputField SceneInputField;

    public void SubmitSceneName()
    {
        LoadScene(SceneInputField.text);
        SceneInputField.text = "";
        SceneInputField.Select();
        SceneInputField.ActivateInputField();
    }

    private void LoadScene(string sceneName)
    {
        LevelManager.Instance.LoadLevel(sceneName);
        UIManager.Instance.TurnOffMenuUI();
    }
}
