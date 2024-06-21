
using Leap;
using Leap.Unity;
using UnityEngine;

public class HandVolumeControl : MonoBehaviour
{
    public LeapProvider leapProvider;
    public AudioSource audioSource;

    private void OnEnable()
    {
        if (leapProvider != null)
        {
            leapProvider.OnUpdateFrame += OnUpdateFrame;
        }
        else
        {
            Debug.LogError("LeapProvider not assigned");
        }
    }

    private void OnDisable()
    {
        if (leapProvider != null)
        {
            leapProvider.OnUpdateFrame -= OnUpdateFrame;
        }
    }

    void OnUpdateFrame(Frame frame)
    {
        Hand rightHand = frame.GetHand(Chirality.Right);

        if (rightHand != null)
        {
            float handHeight = rightHand.PalmPosition.y;
            Debug.Log("Hand Height: " + handHeight); // Log the hand height

            audioSource.volume = Mathf.Clamp(handHeight, 0f, 1f); // Directly use the hand height for volume
            Debug.Log("Volume: " + audioSource.volume); // Log the volume
        }
    }
}
