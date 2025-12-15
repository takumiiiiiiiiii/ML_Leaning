using UnityEngine;

public class break_wall : MonoBehaviour
{
    public GameObject destroysound;
    public int hp = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            HPdown();
            Destroy(collision.gameObject);
        }
    }
    void HPdown()
    {
        hp--;
        if (hp <= 0)
        {
            GameObject gameobject = GameObject.Find("GameManager");
            GameManager gamemanager = gameobject.GetComponent<GameManager>();
            gamemanager.score += 10;
            gamemanager.SetScoreText(gamemanager.score);
            Instantiate(destroysound);
            Destroy(this.gameObject);

        }
    }
}
