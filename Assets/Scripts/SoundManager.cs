using System;
using UnityEngine;

public enum SoundType {
    BALL,
    GOAL
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] Sound[] sounds;

    void OnEnable()
    {
        GameEvents.OnBallHit += OnBallHitHandler;
        GameEvents.OnGoalScored += OnGoalScoredHandler;
    }

    void OnDisable()
    {
        GameEvents.OnBallHit -= OnBallHitHandler;
        GameEvents.OnGoalScored -= OnGoalScoredHandler;
    }

    void Start() => audioSource = gameObject.GetComponent<AudioSource>();

    void PlaySound(SoundType soundType)
    {
        AudioClip clip = sounds[(int)soundType].Clip;
        audioSource.PlayOneShot(clip);
    }

    void OnBallHitHandler() => PlaySound(SoundType.BALL);
    void OnGoalScoredHandler(int _) => PlaySound(SoundType.GOAL);
}

[Serializable]
public struct Sound
{
    public string Name;
    public readonly AudioClip Clip => clip;
    [SerializeField] AudioClip clip;
}