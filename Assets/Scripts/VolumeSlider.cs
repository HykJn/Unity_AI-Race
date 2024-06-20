using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public enum Type
    {
        BGM, SFX
    }

    public Type type;

    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        if (type == Type.BGM) slider.value = SoundManager.Instance.BGMChannel.volume;
        else slider.value = SoundManager.Instance.SFXCHannel.volume;
    }

    public void SetVolume()
    {
        if(type == Type.BGM) SoundManager.Instance.BGMChannel.volume = slider.value;
        else SoundManager.Instance.SFXCHannel.volume = slider.value;
    }
}