using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _myMixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject); 
        //}

        //else
        //{
        //    // Nếu đã có AudioManager khác tồn tại, hủy game object này đi
        //    Destroy(gameObject);
        //}
    }

    public void SetMusicVolume()
    {
        float volume = _musicSlider.value;
        _myMixer.SetFloat("MusicMixer", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume()
    {
        float volume = _sfxSlider.value;
        _myMixer.SetFloat("SFXMixer", Mathf.Log10(volume) * 20);
    }


}
