using UnityEngine;

public class EnemyBullet_ML : MonoBehaviour
{
    public float speed = 3;
    Rigidbody RB;

    public RaycastAgent agent;
    public int checkPointId;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = GameObject.Find("EnemyAgent");//Circleというゲームオブジェクトを探す
        agent = obj.GetComponent<RaycastAgent>();
        if (other.gameObject.tag == "Player")
        {
            agent.HitBullet();
            Destroy(this.gameObject);
        }

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = this.GetComponent<Rigidbody>();
        PlayerCharaControle MV;//呼ぶスクリプトにあだ名をつける
        GameObject obj = GameObject.Find("EnemyAgent");//Circleというゲームオブジェクトを探す
        if (obj != null)
        {
            //MV = obj.GetComponent<PlayerCharaControle>();//スクリプトを取得
            Vector3 Pvec = new Vector3(obj.transform.position.x, transform.position.y, obj.transform.position.z);//プレイヤーの座標を保存
            Vector3 vec = Pvec - this.transform.position;//プレイヤーの位置から敵の位置を引く
            vec = vec.normalized;//正規化
            RB.velocity = vec * speed;//スピードをかける
        }
        
    }
}
