using UnityEngine;

public class SInMove : MonoBehaviour
{
    
    public float length = 4.0f;
    public float speed = 2.0f;
    private Vector3 startPos;
    public bool negative = false;
    public bool reverse = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = this.transform.position;
        if (negative)
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(startPos.x, startPos.y, Mathf.Sin(Time.time*speed) * length + startPos.z);
        if (!reverse) {
            transform.position = new Vector3(startPos.x, startPos.y, Mathf.Sin(Time.time * speed) * length + startPos.z);
        }
        else
        {
            transform.position = new Vector3(Mathf.Sin(Time.time * speed) * length+ startPos.x, startPos.y, startPos.z);
        }

    }
}
