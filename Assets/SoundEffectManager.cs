using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager Instance;
    private static AudioSource audioSource;
    public AudioClip gemCollectedClip;
    public AudioClip jumpClip;
    public AudioClip gameLostClip;
    public AudioClip gameWinClip;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        } else {
           Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public static void playGemCollectedSound()
    {
        audioSource.PlayOneShot(Instance.gemCollectedClip);
    }
    public static void playJumpSound()
    {
        audioSource.PlayOneShot(Instance.jumpClip);
    }
    public static void playGameLostSound()
    {
        audioSource.PlayOneShot(Instance.gameLostClip);
    }
    public static void playGameWinSound()
    {
        audioSource.PlayOneShot(Instance.gameWinClip);
    }
}