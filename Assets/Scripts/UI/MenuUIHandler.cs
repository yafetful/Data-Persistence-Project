using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
