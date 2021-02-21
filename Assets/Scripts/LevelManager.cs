using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public AudioSource SFX;
    public AudioClip hitSound;
    public AudioClip winSound;
    public bool stopMusic;
    public levelLoader loader;
    public List<GameObject> emptySlots;
    public List<GameObject> insertedSlots;

    public void Inserted(GameObject other) {
        insertedSlots.Add(other);
        emptySlots.Remove(other);
        SFX.PlayOneShot(winSound, 1);
    }

    public void Extract(GameObject other)
    {
        insertedSlots.Remove(other);
        emptySlots.Add(other);
        loader.LoadNextLevel(SceneManager.GetActiveScene().buildIndex);
        SFX.PlayOneShot(hitSound, 0.8f);
    }

    void Update() {
        if (emptySlots.Count==0) {
            loader.LoadNextLevel(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
    void Awake() {
        // if (startPlaying)
        // {
        //     musicPlayer.PlayMusic();
        // }
        if (stopMusic)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();
        }
    }
}
