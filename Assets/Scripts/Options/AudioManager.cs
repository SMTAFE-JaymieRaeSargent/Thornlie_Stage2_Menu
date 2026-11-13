using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManagerInstance;

    private void Awake()
    {        
        // if we do not have a audioManagerInstance Connected
        if (audioManagerInstance == null)
        {
            // Connect our Reference
            audioManagerInstance = this;
        }
        // MURDER the imposters....THERE CAN ONLY BE ONE !!!!
        else if (audioManagerInstance != null && audioManagerInstance != this)
        {
            Destroy(this.gameObject);
        }

        // Never kill this object when we change scene
        DontDestroyOnLoad(this.gameObject);
    }

    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioSource _sfxSource;
    [SerializeField] AudioClip _music;

    public void PlayMusic(AudioClip music)
    {
        if (_musicSource != null && music != null)
        {
            _musicSource.clip = music;
            _musicSource.loop = true;
            _musicSource.Play();
        }
    }
    public void PlaySFX(AudioClip sound)
    {
        if (_sfxSource != null && sound != null)
        {
            _sfxSource.PlayOneShot(sound);
        }
    }
    private void Start()
    {
        PlayMusic(_music);
    }
}
