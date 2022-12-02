using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MixerController : MonoBehaviour
{
    public static MixerController MC;
    public AudioMixer mixer;
    public Slider sldMusic;
    public Slider sldFx;
    //public AudioSource sani;

    public void Awake()
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
        /*if(SceneManager.GetActiveScene().buildIndex >= 1 && SceneManager.GetActiveScene().buildIndex < 2)
        {
            if (PlayerController.sanity < 10)
                sani.Play();
            else
                sani.Stop();
        }*/
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
