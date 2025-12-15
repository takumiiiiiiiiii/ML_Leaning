using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    public Color crrColor,goalColor;
    private AudioSource audio;
    public AudioClip clip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();//変数「audioSource」にAudioSourceコンポ年とを入れます
        if (goalColor == null)
        {
            goalColor = new Color(1, 0, 0, 1);
        }
        crrColor = this.gameObject.GetComponent<Renderer>().material.color;
        if (crrColor == null)
        {
            crrColor = new Color(0, 0, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("gloal");
            audio.PlayOneShot(clip);
            this.gameObject.GetComponent<Renderer>().material.color = goalColor;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            this.gameObject.GetComponent<Renderer>().material.color = crrColor;

        }
    }
}
