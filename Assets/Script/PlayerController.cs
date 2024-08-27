using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //重力
    Rigidbody2D rigidbody2D;
    //ジャンプするときの力
    float jumpForce = 680.0f;
    //アニメーション
    Animator animator;
    //歩くときの力
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;



    // Start is called before the first frame update
    void Start()
    {
        //フレームカウント
        Application.targetFrameRate = 60;
        //Rididbodyをコンポーネント
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプする
        if(Input.GetKeyDown(KeyCode.Space)&&this.rigidbody2D.velocity.y==0)
        {
            //アニメーション変更
            this.animator.SetTrigger("JumpTrigger");
            this.rigidbody2D.AddForce(transform.up*this.jumpForce);
        }
        //左右に移動
        int key = 0;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            key = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            key = -1;
        }

        //プレイヤー速度1
        float speedx=Mathf.Abs(this.rigidbody2D.velocity.x);
        //スピード制限
        if(speedx<this.maxWalkSpeed)
        {
            this.rigidbody2D.AddForce(transform.right*key*this.walkForce);
        }

        //動く方向で反転させる
        if(key!=0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if(this.transform.position.y==0)
        {
            this.animator.speed = speedx / 0.75f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }



        if (transform.position.y<-10||transform.position.x<-3||transform.position.x>3)
        {
            SceneManager.LoadScene("GameScenes");
        }

        //画面上に出ないようにする
        else if(transform.position.y>27)
        {
            this.transform.position=new Vector3(transform.position.x,27,transform.position.z);
        }
    }

    //ゴールに到着
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Goal");
        SceneManager.LoadScene("ClearScene");
    }
}
