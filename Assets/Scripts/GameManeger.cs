using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    //残機
    public int life;
    public GameObject ballPrefab;
    //残機のテキスト
    public TextMeshProUGUI textBalls;
    public TextMeshProUGUI textscore;
    private bool inGame;
    public  int score = 0;
    //ボールの出現位置
    public Vector3 ballposition;
    //ゲームオーバーテキスト
    public TextMeshProUGUI textGameover;
    private void Start()
    {
        SetScoreText(score);
        score = 0;
        
        //テキストを非表示
        textGameover.enabled = false;
        //textBalls = GameObject.Find("tank").GetComponent<TextMeshProUGUI>();
        SetBallText(life);
        inGame = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (inGame)
        {
            SetBallText(life);
            //ゲームシーン中にボールがなかった場合は
            GameObject ballObj = GameObject.Find("Player");
            if (ballObj == null)
            {
                life--;
                
                if (life > 0)
                {
                    GameObject newBall = Instantiate(ballPrefab);
                    newBall.name = ballPrefab.name;
                    newBall.transform.position = ballposition;

                }
                else
                {
                    inGame = false;
                    life = 0;
                    //テキストを表示
                    textGameover.enabled = true;
                }
            }
        }
    }

    private void SetBallText(int life)
    {
        textBalls.text = "HP:" + PlayerCharaControle.hp.ToString();
        
    }
    public void SetScoreText(int score)
    {
        textscore.text = "Score:" + score.ToString();
    }
}
