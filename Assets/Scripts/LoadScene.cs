using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Button targetButton; // on button click, transition to the scene with the index of sceneIndex
    public int sceneIndex;

    void Awake()
    {

        try
        {
            targetButton.onClick.AddListener(ChangeScene);
        }
        catch (Exception e)
        {
            Debug.LogError("sceneAdvanceOnButton script on " + gameObject.name + " must have a targeted Button!");
            print(e);
        }

    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
