using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float maxspeed = 10.0f;
    public float speed = 2.0f;
    private Rigidbody rB;
    private AudioSource audio;
    public AudioClip clip;
    public GameObject audioobj;
    // Start is called once before the fir
    // st execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI goalText;
    public bool goalOn;
    void Start()
    {
        rB = GetComponent<Rigidbody>();
        goalText = GameObject.Find("Goal").GetComponent<TextMeshProUGUI>();
        goalText.enabled = false;
        goalOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //rB.AddForce(x * speed, 0, z * speed, ForceMode.Impulse);
        if(Mathf.Abs(rB.velocity.x) < maxspeed)
        {
            rB.AddForce(x * speed, 0, 0, ForceMode.Impulse);
            
        }
        else
        {
            rB.velocity = new Vector3(x * maxspeed, 0, 0);
        }
        if (Mathf.Abs(rB.velocity.z) < maxspeed)
        {
            rB.AddForce(0, 0, z * speed, ForceMode.Impulse);
        }
        else
        {
            rB.velocity = new Vector3(0, 0, z * maxspeed);
        }
        //rB.linearVelocity = new Vector3(x * speed,0,z*speed);
        //Debug.Log(rB.linearVelocity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Goal")
        {
            audio = gameObject.AddComponent<AudioSource>();//変数「audioSource」にAudioSourceコンポ年とを入れます
            audio.PlayOneShot(clip);
            this.gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0,0);
            goalText.enabled = true;
            goalOn = true;
        }else if(other.gameObject.tag == "Enemy")
        {
            Instantiate(audioobj);
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemybullet")
        {

            Instantiate(audioobj);
            this.gameObject.SetActive(false);
        }
    }
}

