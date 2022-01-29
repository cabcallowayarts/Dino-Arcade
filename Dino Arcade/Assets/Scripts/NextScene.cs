using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private int currentSceneIndex;

    void Start()
    {
         currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    
    public void OnButtonPress()
    {
        
        
        if (currentSceneIndex <= SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("ButtonPress");
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

}
