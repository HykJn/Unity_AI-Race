using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource BGMChannel;
    public AudioSource SFXCHannel;
    public AudioClip BGM;
    public AudioClip clickSFX, goalSFX;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        PlaySound("BGM");
    }

    public void PlaySound(string clipName)
    {
        switch(clipName)
        {
            case "BGM":
                BGMChannel.PlayOneShot(BGM);
                break;
            case "Click":
                SFXCHannel.PlayOneShot(clickSFX);
                break;
            case "Goal":
                SFXCHannel.PlayOneShot(goalSFX);
                break;
        }
    }
}