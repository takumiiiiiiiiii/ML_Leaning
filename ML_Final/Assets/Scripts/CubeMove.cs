using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public int oriTimer = 50;
    private int timer = 0;
    private Vector3 oriPos;
    public float moveSpeed = 0.05f;
    public bool colum = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        oriPos = this.gameObject.GetComponent<Transform>().position;
        if (colum)
        {
            this.gameObject.transform.position = new Vector3(oriPos.x, oriPos.y, oriPos.z + moveSpeed);
        }
        else
        {
            this.gameObject.transform.position = new Vector3(oriPos.x + moveSpeed, oriPos.y, oriPos.z );
        }
        
        timer = timer - 1;
        if(timer <= 0)
        {
            timer = oriTimer;
            moveSpeed = moveSpeed * (-1);
        }
    }
}
