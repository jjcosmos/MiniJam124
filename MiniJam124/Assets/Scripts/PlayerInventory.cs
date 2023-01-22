using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfhandWarmer { get; private set; }

    public UnityEvent<PlayerInventory> OnhandWarmerCollected;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioClip _hurtClip;

    public void handWarmerCollected()
    {
        _source.PlayOneShot(_clip);
        ModifyFuelWithFx(1);
    }

    private void Start()
    {
        ResetFuelTimer();
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
            ResetFuelTimer();
        }
    }

    private void ResetFuelTimer()
    {
        _fuelTimer = Game.Singleton.Settings.FuelConsumptionSpeed;
    }

    public int playerCollision { get; private set; }

    public UnityEvent<PlayerInventory> OnCollisionhit;

    public void Collisionhit()
    {
        ModifyFuelWithFx(-Game.Singleton.Settings.WarmersLostOnHit);
        _source.PlayOneShot(_hurtClip);
        playerCollision--;
        OnCollisionhit.Invoke(this);
    }

    // TODO: Actually add fx
    private void ModifyFuelWithFx(int mod)
    {
        ResetFuelTimer();
        NumberOfhandWarmer += mod;
        NumberOfhandWarmer = Mathf.Clamp(NumberOfhandWarmer, 0, int.MaxValue);
        OnhandWarmerCollected.Invoke(this);
    }
}
