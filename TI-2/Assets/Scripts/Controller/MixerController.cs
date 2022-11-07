using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider sldMusic;
    public Slider sldFx;
    public void ChangeMusicVolume()
    {
        mixer.SetFloat("Music", (sldMusic.value * 20 - 20));
    }
    
    public void ChangeFxVolume()
    {
        mixer.SetFloat("Fx", (sldFx.value * 20 - 20));
    }
}
