using UnityEngine;

public class Bullet: MonoBehaviour
{
    public int hp = 2;
    Rigidbody RB;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = this.GetComponent<Rigidbody>();
        Tank_bullet MV;//呼ぶスクリプトにあだ名をつける
        GameObject obj = GameObject.Find("Player");//Circleというゲームオブジェクトを探す
        MV = obj.GetComponent<Tank_bullet>();//スクリプトを取得
        //Vector3 Pvec = new Vector3(MV.transform.position.x, transform.position.y, MV.transform.position.z);//プレイヤーの座標を保存
        //Vector3 vec = Pvec - this.transform.position;//プレイヤーの位置から敵の位置を引く
        //vec = vec.normalized;//正規化
        RB.AddForce(MV.transform.forward* speed);
        //RB.linearVelocity = new Vector3(10,0,0) * speed;//スピードをかける
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="wall")
        {
            hp--;
            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        
    }

}
