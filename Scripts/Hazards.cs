using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Hazards : MonoBehaviour
{
    public AudioSource respawnSFX;

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        respawnSFX.Play();
        AddToScore.score = 0;
    }

}
