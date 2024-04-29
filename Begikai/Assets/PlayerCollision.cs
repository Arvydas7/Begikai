using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public AudioSource audioPlayerSFX;
    public AudioSource audioPlayerBGM;
    private void OnCollisionEnter2D(Collision2D other){
        if (other.transform.tag == "Obstacle"){
            Destroy(gameObject);
            GameManager.Instance.GameOver();
            audioPlayerSFX.Play();
            audioPlayerBGM.Stop();
        }
    }
}
