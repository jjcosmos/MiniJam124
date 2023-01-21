using System;
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
        ModifyFuelWithFx(1);
    }

    private void Start()
    {
        _fuelTimer = Game.Singleton.Settings.FuelConsumptionSpeed;
    }

    private void Update()
    {
        TickFuelTimer();
    }

    private float _fuelTimer;
    private void TickFuelTimer()
    {
        if (Game.Singleton.GameState != GameState.Racing) return;
        
        _fuelTimer -= Time.deltaTime;
        if (_fuelTimer <= 0f)
        {
            ModifyFuelWithFx(-1);
            _fuelTimer = Game.Singleton.Settings.FuelConsumptionSpeed;
        }
    }

    public int playerCollision { get; private set; }

    public UnityEvent<PlayerInventory> OnCollisionhit;

    public void Collisionhit()
    {
        ModifyFuelWithFx(-Game.Singleton.Settings.WarmersLostOnHit);
        playerCollision--;
        OnCollisionhit.Invoke(this);
    }

    // TODO: Actually add fx
    private void ModifyFuelWithFx(int mod)
    {
        NumberOfhandWarmer += mod;
        NumberOfhandWarmer = Mathf.Clamp(NumberOfhandWarmer, 0, int.MaxValue);
        OnhandWarmerCollected.Invoke(this);
    }
}
