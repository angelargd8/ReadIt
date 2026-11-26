using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BookshelfManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;

    [Header("Scene")]
    [SerializeField] private string sceneName;

    public void PlaySoundAndChangeScene()
    {
        StartCoroutine(ChangeSceneAfterSound());
    }

    private IEnumerator ChangeSceneAfterSound()
    {
        // Reproducir sonido
        audioSource.Play();

        // Esperar a que termine el sonido
        yield return new WaitForSeconds(audioSource.clip.length);

        // Cambiar de escena
        SceneManager.LoadScene(sceneName);
    }
}
