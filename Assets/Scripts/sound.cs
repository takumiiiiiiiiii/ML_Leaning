using UnityEngine;

public class sound : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip clip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();//変数「audioSource」にAudioSourceコンポ年とを入れます
        audio.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
