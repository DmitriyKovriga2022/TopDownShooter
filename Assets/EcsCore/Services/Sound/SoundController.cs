using UnityEngine;

public static class SoundController
{
    public static AudioSource PlayClipAtPosition(AudioClip clip, Vector3 position)
    {
        GameObject go = new GameObject("OneShotAudio: " + clip.name);
        go.transform.position = position;
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = 1;// PlayerPrefs.GetFloat("SoundVolume");
        source.Play();
        Object.Destroy(go, source.clip.length);
        return source;
    }

    public static AudioSource PlayClipAtPosition(AudioClip clip, Vector3 position, float volume)
    {
        GameObject go = new GameObject("OneShotAudio: " + clip.name);
        go.transform.position = position;
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.Play();
        Object.Destroy(go, source.clip.length);
        return source;
    }
}
