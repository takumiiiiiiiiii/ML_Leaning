using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject destroysound;
    private GameObject target;
    public GameObject bullet;
    public int hp = 1;
    public float shottime = 0;
    public float shotmax = 199;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        shottime += Time.deltaTime;
        if (shottime >= shotmax)
        {
            Instantiate(bullet,this.transform.position,Quaternion.identity);
            shottime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            HPdown();
            Destroy(other.gameObject);
        }
    }

    void HPdown()
    {
        hp--;
        if (hp <= 0)
        {
            GameObject gameobject = GameObject.Find("GameManager");
            GameManager gamemanager= gameobject.GetComponent<GameManager>();
            gamemanager.score+=200;
            gamemanager.SetScoreText(gamemanager.score);
            Instantiate(destroysound);
            Destroy(this.gameObject);
        }
    }
}
