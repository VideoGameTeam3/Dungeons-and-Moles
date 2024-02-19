using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class skipmenu : MonoBehaviour
{
    [SerializeField] int SkipTo = 2;

    public void PlayGame(){

        SceneManager.LoadSceneAsync(SkipTo);

    }
   
}
