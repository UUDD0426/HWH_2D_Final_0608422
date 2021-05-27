using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [Header("移動速度"), Range(0, 300)]
    public float speed = 10.5f;
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("變形元件")]
    public Transform tra;
    [Header("動畫元件")]
    public Animator ani;
    [Header("偵測範圍")]
    public float rangeAttack = 2.5f;
    [Header("音效來源")]
    public AudioSource aud;
    [Header("攻擊音效")]
    public AudioClip soundAttack;
    [Header("血量")]
    public float hp = 200;
    private float hpMax;
   // [Header("血量系統")]
   // public HpManager hpManager;
    [Header("攻擊力"), Range(0, 1000)]
    public float attack = 20;
    private bool isDead = false;




    /// <summary>
    /// 移動
    /// </summary>

    private void Move()
    {
        if (isDead) return;                  //如果死亡就跳出
        float h = joystick.Horizontal;
        


        //變形元件,位移(水平*速度*一幀的時間,垂直*速度*一幀的時間,0)
        tra.Translate(h * speed * Time.deltaTime, 0,0);

        ani.SetFloat("水平", h);
        

    }
    /* public void Attack()
     {
         if (isDead) return;                  //如果死亡就跳出
         //音效來源,撥放一次(音效片段,音量)
         aud.PlayOneShot(soundAttack, 0.5f);

         //2D物理 圓形碰撞(中心點,半徑,方向,距離,圖層編號)
         RaycastHit2D hit = Physics2D.CircleCast(transform.position, rangeAttack, -transform.up, 0, 1 << 8);

         //如果 碰到物件存在 並且 碰到的物件 標籤 為道具 就取得道具腳本並呼叫掉落道具方法
          if (hit && hit.collider.tag == "敵人") hit.collider.GetComponent<Enemy>().Hit(attack + attackWeapon);

     }*/
   /* public void Hit(float damage)
    {
        hp -= damage;                        //扣除傷害值
        hpManager.UpdateHpBar(hp, hpMax);     //更新血條
        StartCoroutine(hpManager.ShowDamage(damage));
        if (hp <= 0) Dead();                 //如果血量<=0就死亡
    }
    private void Dead()
    {
        hp = 0;
        isDead = true;
        Invoke("Replsy", 2);                      //延遲呼叫("方法名稱",延遲時間)
    }
    private void Replay()
    {
        SceneManager.LoadScene("遊戲場景");
    }*/
    void Start()
    {
        hpMax = hp;
    }
    //public float attackWeapon;

    void Update()
    {
        Move();
    }
    private void OnDrawGizmos()
    {
        //指定圖示顏色(紅,綠,藍,透明)
        Gizmos.color = new Color(1, 0, 0, 0.4f);
        //繪製圖示 球體(中心點,半徑)
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }
}
