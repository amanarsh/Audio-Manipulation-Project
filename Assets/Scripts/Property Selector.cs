using UnityEngine;

public enum AudioProperty
{
    Volume,
    Pitch,
    Reverb,
    Echo
}

public class AudioControlUI : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioReverbZone reverbZone;
    public AudioEchoFilter echoFilter;

    public AudioProperty selectedProperty;

    public void SelectVolume()
    {
        selectedProperty = AudioProperty.Volume;
        Debug.Log("Selected Property: Volume");
    }

    public void SelectPitch()
    {
        selectedProperty = AudioProperty.Pitch;
        Debug.Log("Selected Property: Pitch");
    }

    public void SelectReverb()
    {
        selectedProperty = AudioProperty.Reverb;
        Debug.Log("Selected Property: Reverb");
    }

    public void SelectEcho()
    {
        selectedProperty = AudioProperty.Echo;
        Debug.Log("Selected Property: Echo");
    }

    public void AdjustSelectedProperty(float value)
    {
        switch (selectedProperty)
        {
            case AudioProperty.Volume:
                audioSource.volume = Mathf.Clamp(value, 0f, 1f);
                break;
            case AudioProperty.Pitch:
                audioSource.pitch = Mathf.Clamp(value, 0f, 3f);
                break;
            case AudioProperty.Reverb:
                reverbZone.decayTime = Mathf.Clamp(value * 200f, 1f, 200f); // Scale 0-1 to 1-200
                break;
            case AudioProperty.Echo:
                echoFilter.delay = Mathf.Clamp(value * 1000f, 0f, 500f); // Assuming scale 0-500, modify as needed
                break;
        }
    }
}
