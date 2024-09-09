using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public abstract void Move();
    public abstract void Attack();
    public abstract void LoseHealth(float damage);

    public abstract void Die();
}