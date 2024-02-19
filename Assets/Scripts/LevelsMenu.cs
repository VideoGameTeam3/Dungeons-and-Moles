using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{

    public Button[] buttons;

    private void Awake(){
        int UnlockedLevel=PlayerPrefs.GetInt("UnLockedLevel",1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < UnlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void OpenLevel(int levelId){
        string levelname = "Level-" + levelId;
        SceneManager.LoadScene(levelname);

    }
}
