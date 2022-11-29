using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MixerController : MonoBehaviour
{
    private static MixerController MC;
    public AudioMixer mixer;
    public Slider sldMusic;
    public Slider sldFx;
    public AudioSource sani;

    public GameObject pause;
    bool Pause = false;
    private void Awake()
    {
        if (MC == null)
        {
            MC = this;
            DontDestroyOnLoad(MC);
        }
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        Pause = !Pause;
        pause.SetActive(Pause);
        GameManager.GM.SetPause(Pause); //teoricamente é pra funciona kjl

        if(SceneManager.GetActiveScene().buildIndex >= 1 && SceneManager.GetActiveScene().buildIndex < 2)
        {
            if (PlayerController.sanity < 10)
                sani.Play();
            else
                sani.Stop();
        }
    }
    public void ChangeMusicVolume()
    {
        mixer.SetFloat("Music", (sldMusic.value * 20 - 20));
    }
    public void ChangeFxVolume()
    {
        mixer.SetFloat("Fx", (sldFx.value * 20 - 20));
    }
}
