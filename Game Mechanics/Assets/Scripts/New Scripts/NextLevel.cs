using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public static void LevelSelect(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
