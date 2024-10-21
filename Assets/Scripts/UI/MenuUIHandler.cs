using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMPro.TMP_InputField playerNameInputField;
    // Start is called before the first frame update

    void SetPlayerName(){
        DataManager.Instance.SetPlayerName(playerNameInputField.text);
        Debug.Log("Player Name: " + DataManager.Instance.playerName);
    }
    public void StartGame(){
        SetPlayerName();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void ExitGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
