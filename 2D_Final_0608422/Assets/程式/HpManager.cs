﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;  //引用 系統集合 API 裡面包含協同程序

public class HpManager : MonoBehaviour
{
    [Header("血條")]
    public Image bar;
    [Header("傷害數值")]
    public RectTransform rectDamage;
    [Header("傷害指定位置")]
    public float x_;
    public float y_;

    /// <summary>
    /// 輸入血量與血量最大值並更新血條
    /// </summary>
    /// <param name="hp">當前血量</param>
    /// <param name="hpBar">血量最大值</param>
    public void UpdateHpBar(float hp,float hpMax)
    {
        //血條.填滿數值=當前血量/血量最大值
        bar.fillAmount = hp / hpMax;
    }
    public IEnumerator ShowDamage(float damage)
    {
        RectTransform rect = Instantiate(rectDamage, transform);       //生成傷害數值在血條系統內
        rect.anchoredPosition = new Vector2(x_, y_);                   //指定座標
        rect.GetComponent<Text>().text = damage.ToString();            //更新數值
        float y = rect.anchoredPosition.y;
        while (y < 400)
        {
            y += 20;
            rect.anchoredPosition = new Vector2(0, y);
            yield return  new WaitForSeconds(0.2f);
            
        }
        Destroy(rect.gameObject, 0.5f);                                //刪除傷害數值物件
    }
}
