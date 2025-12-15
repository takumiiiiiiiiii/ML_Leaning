using UnityEngine;

public class addScore : MonoBehaviour
{
    public GameObject destroysound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject gameobject = GameObject.Find("GameManager");
            GameManager gamemanager = gameobject.GetComponent<GameManager>();
            gamemanager.score += 300;
            gamemanager.SetScoreText(gamemanager.score);
            Instantiate(destroysound);
            Destroy(this.gameObject);
        }
    }

}
