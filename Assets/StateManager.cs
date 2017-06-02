using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class StateManager : MonoBehaviour
{
    static string lastScene;
    static StateManager managerInstance = null;

    VRTK_SDKManager manager;

    void Start()
    {
        Debug.Log("main start");
        if (managerInstance == null)
        {
            DontDestroyOnLoad(gameObject);
            managerInstance = this;
            manager = FindObjectOfType<VRTK_SDKManager>();
            SceneManager.LoadScene("main");
        }
    }

    float time = 0f;
    float pressTimeToReturn = 1.5f;

    void Update()
    {
        if (VRTK_SDK_Bridge.IsStartMenuPressedOnIndex(VRTK_SDK_Bridge.GetControllerIndex(VRTK_SDK_Bridge.GetControllerLeftHand(true))) ||
           VRTK_SDK_Bridge.IsStartMenuPressedOnIndex(VRTK_SDK_Bridge.GetControllerIndex(VRTK_SDK_Bridge.GetControllerRightHand(true))))
        {
            time += Time.deltaTime;
        }
        else
            time = 0f;
        if (time > pressTimeToReturn)
        {
            GoBack();
        }
    }

    public static void LoadNextScene(string sceneName)
    {
        managerInstance.StartCoroutine(managerInstance.LoadNext(sceneName));
        
    }

    IEnumerator ChangeToLoading(string sceneName)
    {
        SceneManager.LoadScene("loading");
        yield return 0;        
    }

    IEnumerator LoadNext(string sceneName)
    {
        yield return ChangeToLoading(sceneName);
        lastScene = sceneName;
        SceneManager.LoadSceneAsync(sceneName);
    }

    void GoBack()
    {
        LoadNextScene(lastScene);
    }
}
