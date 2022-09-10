using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] AudioClip Loser;

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(Loser, Camera.main.transform.position,1f);
        SceneManager.LoadScene("GameOver");
    }   
}
