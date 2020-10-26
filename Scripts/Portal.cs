using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public Animator transition;

    public AudioSource portalSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (AddToScore.score >= 3)
        {
            LoadNextLevel();
            portalSFX.Play();
        }
        else
        {
            return;
        }
    }

    private void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
