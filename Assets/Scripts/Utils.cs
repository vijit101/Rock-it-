using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utils{
    public static void reloadcurrentscene()
    {
        int currentidx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentidx);
    }
    public static void loadnextscene()
    {
        int currentidx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((currentidx + 1)%SceneManager.sceneCountInBuildSettings);
    }
}

