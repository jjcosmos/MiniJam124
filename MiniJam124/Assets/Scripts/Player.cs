using System;
using UnityEngine;

public class Player : MonoBehaviour
{
   private Rigidbody _playerRigidbody;

   private void Start()
   {
      _playerRigidbody = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      AddForwardForce();
      ProcessSteeringInput();
   }

   private void AddForwardForce()
   {
      if (Game.Singleton.GameState != GameState.Racing) return;
      
      _playerRigidbody.AddForce(transform.forward * (Game.Singleton.Settings.PlayerMoveSpeed * Time.deltaTime));
   }

   private void ProcessSteeringInput()
   {
      if (Game.Singleton.GameState != GameState.Racing) return;

      var steeringInput = Input.GetAxis("Horizontal");
      _playerRigidbody.AddTorque(new Vector3(0f, steeringInput * Time.deltaTime * Game.Singleton.Settings.PlayerTurnSpeed, 0f));
   }
}
