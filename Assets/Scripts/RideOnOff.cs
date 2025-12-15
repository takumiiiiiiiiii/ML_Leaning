using UnityEngine;

public class RideOnOff : MonoBehaviour
{
    private string objName;
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
        //子オブジェクトにする
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //子オブジェクトを解除する
            other.transform.parent = null;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        //子オブジェクトにする
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = this.transform;
        }

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //子オブジェクトを解除する
            other.transform.parent = null;
        }
    }
}
