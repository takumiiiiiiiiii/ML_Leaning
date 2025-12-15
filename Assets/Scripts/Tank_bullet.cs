using UnityEngine;

public class Tank_bullet : MonoBehaviour
{
    public float Rspeed = 1;
    public GameObject bullet;
    public float  disbullet = 3;
    private AudioSource audio;
    public AudioClip clip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();//変数「audioSource」にAudioSourceコンポ年とを入れます
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            transform.Rotate(0, -Rspeed,0);
        }
        else if (Input.GetKey(KeyCode.L)) {
            transform.Rotate(0, Rspeed, 0);
        }
        //Vector3 shotpos = this.transform.position + new Vector3(Mathf.Cos(transform.rotation.x)*disbullet, 0, Mathf.Sin(transform.rotation.y)*disbullet);
        Vector3 shotpos = this.transform.position + transform.forward * disbullet;
        if (Input.GetKeyDown(KeyCode.E))
        {
            audio.PlayOneShot(clip);
            Instantiate(bullet,shotpos,Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            //rb.linearVelocity = this.transform.forward * shotspeed;
            rb.velocity = new Vector3(50,0,0);

        }

    }
    private void FixedUpdate()
    {
        
    }
}
