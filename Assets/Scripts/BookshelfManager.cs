using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookshelfManager : MonoBehaviour
{
    public void LoadScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
