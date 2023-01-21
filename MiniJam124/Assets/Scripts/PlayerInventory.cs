using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfhandWarmer { get; private set; }

    public UnityEvent<PlayerInventory> OnhandWarmerCollected;

    public void handWarmerCollected()
    {
        NumberOfhandWarmer++;
        OnhandWarmerCollected.Invoke(this);
    }

    public int playerCollision { get; private set; }

    public UnityEvent<PlayerInventory> OnCollisionhit;

    public void Collisionhit()
    {
        playerCollision--;
        OnCollisionhit.Invoke(this);
    }
}
