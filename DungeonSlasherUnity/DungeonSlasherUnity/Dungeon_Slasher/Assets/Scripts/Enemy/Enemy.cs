using UnityEngine;

public abstract class Enemy :MonoBehaviour
{
    public abstract void Chase();
    public abstract void Attack();

    public abstract void LoseHealth(float damage);
}
