/*
 * Created following a tutorial by Brackeys
 * https://www.youtube.com/watch?v=6OT43pvUyfY
 */
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public string name;

    public float volume;
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}