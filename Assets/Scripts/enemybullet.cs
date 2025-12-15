using UnityEngine;

public class enemybullet : MonoBehaviour
{
    
    public float speed = 3;
    Rigidbody RB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = this.GetComponent<Rigidbody>();
        PlayerCharaControle MV;//呼ぶスクリプトにあだ名をつける
        GameObject obj = GameObject.Find("Player");//Circleというゲームオブジェクトを探す
        if (obj != null)
        {
            MV = obj.GetComponent<PlayerCharaControle>();//スクリプトを取得
            Vector3 Pvec = new Vector3(MV.transform.position.x, transform.position.y, MV.transform.position.z);//プレイヤーの座標を保存
            Vector3 vec = Pvec - this.transform.position;//プレイヤーの位置から敵の位置を引く
            vec = vec.normalized;//正規化
            RB.velocity = vec * speed;//スピードをかける
        }
        
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall"||other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        
    }
}
