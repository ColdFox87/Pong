using System;
using UnityEngine;

public enum SoundType
{
    BALL,
    GOAL
}

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]

public class SoundManager : MonoBehaviour
{
    [SerializeField] SoundList[] soundList;
    private static SoundManager instance;
    AudioSource audioSource;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

#if UNITY_EDITOR
    void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);

        for(int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }
#endif

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(randomClip, volume);
    }
}

[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds { get => sounds; }
    public string name;
    [SerializeField] AudioClip[] sounds;
}