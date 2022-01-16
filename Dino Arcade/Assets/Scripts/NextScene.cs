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
        Debug.Log("ButtonPress");
        
        if (currentSceneIndex <= SceneManager.sceneCount - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

}
