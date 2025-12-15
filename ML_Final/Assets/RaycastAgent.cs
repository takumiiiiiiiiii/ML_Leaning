
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
public class RaycastAgent : Agent
{
    Rigidbody rBody;
    int lastCheckPoint;
    int checkPointCount;

    public float bulletHit = -0.1f;
    public GameObject EnemyBullet;

    private int Timer = 0;
    public int AliveTime;
    //ゲームオブジェクト生成時
    
    //物理系
    //
    public float friction = 0.4f;
    public float speeed = 0.8f;
    public override void Initialize()
    {
        this.rBody = GetComponent<Rigidbody>();
    }

    public bool isLearning = false;
    //エピソード開始時
    public override void OnEpisodeBegin()
    {
        if (isLearning) {
            Timer = 0;
            float bulletx = Random.Range(-5, 5);
            float bulletz = Random.Range(-5, 5);
            Vector3 SpqwnPoint = new Vector3(bulletx, 0.37f, bulletz);
            GameObject EV = Instantiate(EnemyBullet, SpqwnPoint, Quaternion.identity);
            float distance = Vector3.Distance(this.transform.position, EV.transform.position);
            do
            {
                float Playerx = Random.Range(-10, 10);
                float Playerz = Random.Range(-10, 10);
                Vector3 PlayerPoint = new Vector3(Playerx, 0.37f, Playerz);
                this.transform.position = PlayerPoint;
                distance = Vector3.Distance(this.transform.position, EV.transform.position);
            } while (distance < 3);
            rBody.velocity = Vector3.zero;
        }

    }
    private void Update()
    {
       
    }
    //観察取得時に呼ばれる
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.z);
    }
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        Timer++;
        //RaycastAgentに力を加える
        Vector3 dirToGo = Vector3.zero;
        Vector3 rotateDir = Vector3.zero;
        int action = actionBuffers.DiscreteActions[0];
        if (action == 1) dirToGo = transform.forward;
        if (action == 2) dirToGo = transform.forward * -1.0f;
        if (action == 3) rotateDir = transform.up * -1.0f;
        if (action == 4) rotateDir = transform.up;
        if (action == 5) dirToGo = -transform.transform.right;
        if (action == 6) dirToGo = transform.right;
        if(action == 7)
        this.transform.Rotate(rotateDir, Time.deltaTime * 200f);
        Vector3 reverseForce = -rBody.velocity * friction;
        this.rBody.AddForce(dirToGo * speeed+reverseForce, ForceMode.VelocityChange);
        //this.rBody.AddForce(dirToGo * 0.4f, ForceMode.VelocityChange);
        double Objectforce = rBody.velocity.magnitude;
        if (isLearning)
        {
            if (Objectforce < 0.0001)
            {
                Debug.Log("Force" + Objectforce);
                AddReward(0.005f);
            }
            if (Timer == AliveTime)
            {
                Debug.Log("AddReward");
                AddReward(1.0f);

                EndEpisode();
            }
        }
    }
    public void ShootBullet()
    {

    }
    public void HitBullet()
    {
        //AddReward(bulletHit);
        EndEpisode();
    }

    public override void Heuristic(in ActionBuffers actionBuffers)
    {
        var actionsOut = actionBuffers.DiscreteActions;
        actionsOut[0] = 0;

        if (Input.GetKey(KeyCode.UpArrow)) actionsOut[0] = 1;
        if (Input.GetKey(KeyCode.DownArrow)) actionsOut[0] = 2;
        if (Input.GetKey(KeyCode.LeftArrow)) actionsOut[0] = 3;
        if (Input.GetKey(KeyCode.RightArrow)) actionsOut[0] = 4;
        if (Input.GetKey(KeyCode.A)) actionsOut[0] = 5;
        if (Input.GetKey(KeyCode.D)) actionsOut[0] = 6;
    }


}

