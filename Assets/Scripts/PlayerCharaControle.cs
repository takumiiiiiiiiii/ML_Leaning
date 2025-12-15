using UnityEngine;
using TMPro;
public class PlayerCharaControle : MonoBehaviour
{
    public float forwardSpeed = 2.0f;//前進速度
    public float rotationSpeed = 100.0f;//回転速度
    private Animator anim;
    private bool runFlg;
    public static int hp = 3;
    public TextMeshProUGUI goalText2;
    public bool goalOn2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = 3;
        anim = GetComponent<Animator>();
        if (goalText2 != null)
        {
            goalText2.enabled = false;
        }

        goalOn2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        if (v > 0.1 || v < -0.1 || h > 0.1 || h < -0.1)
        {
            runFlg = true;
        }
        else
        {
            runFlg = false;
        }
        //anim.SetBool("Run", runFlg);//アニメーターコントローラーのrunに値を代入
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)){
            transform.position += transform.right * forwardSpeed * h * Time.deltaTime;//プレイヤーを移動
            transform.position += transform.forward * forwardSpeed * v * Time.deltaTime;//プレイヤーを移動

        }
        else
        {
            transform.position += transform.forward * forwardSpeed * v * Time.deltaTime;//プレイヤーを移動
            transform.Rotate(0, rotationSpeed * h * Time.deltaTime, 0);
            
        }
       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Goal")
        {
            other.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
            if (goalText2 != null)
            {
                goalText2.enabled = true;
            }
            goalOn2 = true;
        }
        else if(other.gameObject.tag == "enemybullet")
        {
            if (hp <= 0)
            {
                this.gameObject.SetActive(false);
            }
            hp--;
        }
    }
}
