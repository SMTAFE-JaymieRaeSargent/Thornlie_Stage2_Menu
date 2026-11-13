using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class AudioAsset : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    public AudioSliderOptions[] audioSliderOptions = new AudioSliderOptions[3];    

    public void ChangeVolume(int mixerIndex)
    {
        audioSliderOptions[mixerIndex].volume = audioSliderOptions[mixerIndex].slider.value;
        _mixer.SetFloat(audioSliderOptions[mixerIndex].channelName, audioSliderOptions[mixerIndex].volume);
        audioSliderOptions[mixerIndex].percentText.text = $"{Mathf.Clamp01((audioSliderOptions[mixerIndex].volume+80)/100):P0}";
    }

    private void Start()
    {

        for (int currentAudioChannel = 0; currentAudioChannel < audioSliderOptions.Length; currentAudioChannel++)
        {
            audioSliderOptions[currentAudioChannel].slider.value = audioSliderOptions[currentAudioChannel].volume;
            ChangeVolume(currentAudioChannel);
        }
    }
}
[System.Serializable] 
public struct AudioSliderOptions
{
    public Slider slider;
    public TMP_Text percentText;
    public float volume;
    public string channelName;
}
