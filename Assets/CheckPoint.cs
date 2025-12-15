using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public RaycastAgent agent;
    public int checkPointId;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Onyhea");
            //this.agent.EnterCheckPoint(this.checkPointId);
        }
    }
}
