﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 人物基类  
/// </summary>
public class C_Player : MonoBehaviour
{
    //出战牌
    [HideInInspector]
    public List<C_CardData> playingCards = new List<C_CardData>();
    
    //手牌
    [HideInInspector]
    public List<C_CardData> handCards = new List<C_CardData>();

    //人物属性
    [HideInInspector] public SRoleInfo roleInfo;

    public virtual void Init()
    {
        roleInfo = new SRoleInfo(100, 10);
    }

    public virtual void DoUpdate(float dt)
    {
        
    }

    //被攻击
    public virtual void Damage(float damage)
    {
        float cHp = roleInfo.Hp - damage;
        if (cHp <= 0) 
        {
            roleInfo.Hp = 0;
            OnDeath();
        }
        else
        {
            roleInfo.Hp = cHp;
            Injure();
        }
    }
    
    //抽卡
    public virtual void FlashCard(C_CardData cardData)
    {
        if (handCards.Contains(cardData))
        {
            return;
        }
        handCards.Add(cardData);
    }
    
    //出战卡片
    public virtual void GoWarCard(C_CardData cardData)
    {
        if (handCards.Contains(cardData))
        {
            handCards.Remove(cardData);
            playingCards.Add(cardData);
        }
    }

    //受伤
    protected virtual void Injure()
    {
        
    }

    //死亡
    protected virtual void OnDeath()
    {
        
    }
    
    

}


public struct SRoleInfo
{
    //血量
    public float Hp;

    //最大血量
    public float MaxHp;
    
    //金币
    public int Coin;

    public SRoleInfo(int hp , int initCoin)
    {
        MaxHp = hp;
        Hp = hp;
        Coin = initCoin;
    }
}