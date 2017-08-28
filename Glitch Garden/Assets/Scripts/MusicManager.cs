using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    void OnEnable() {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }

    void OnLevelLoaded(Scene scene, LoadSceneMode loadSceneMode) {
        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
        if(thisLevelMusic) {
                audioSource.clip = thisLevelMusic;
                audioSource.loop = true;
                audioSource.Play();
        }
    }

    public void ChangeVolume(float volume) {
        audioSource.volume = volume;
    }
}
