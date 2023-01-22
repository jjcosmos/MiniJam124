using System;
using UnityEngine;

public class Player : MonoBehaviour
{
   private Rigidbody _playerRigidbody;
   private PlayerInventory _inventory;
   private float _moveModifier = 1f;

   private void Start()
   {
      _playerRigidbody = GetComponent<Rigidbody>();
      _inventory = GetComponent<PlayerInventory>();
      
      _inventory.OnhandWarmerCollected.AddListener(UpdateMoveModifier);
   }

   private void Update()
   {
      AddForwardForce();
      ProcessSteeringInput();
   }

   private void UpdateMoveModifier(PlayerInventory i)
   {
      _moveModifier = Mathf.Clamp(i.NumberOfhandWarmer, 0, Game.Singleton.Settings.MaxWarmersForMult) *
                      (Game.Singleton.Settings.HandwarmerBoostRatio * Game.Singleton.Settings.PlayerMoveSpeed);
      //Debug.Log($"Setting move modifier to {_moveModifier} from {i.NumberOfhandWarmer} warmers");
   }

   private void AddForwardForce()
   {
      if (Game.Singleton.GameState != GameState.Racing) return;
      
      _playerRigidbody.AddForce(transform.forward * ((Game.Singleton.Settings.PlayerMoveSpeed + _moveModifier) * Time.deltaTime));
   }

   private void ProcessSteeringInput()
   {
      if (Game.Singleton.GameState == GameState.CompletedRace)
      {
         var lookAt = Game.Singleton.ProgressTracker.LookAtTriggerZonePosition();
         lookAt.z = transform.position.z;
         //transform.right = (lookAt - transform.position).normalized;
      }
      else if(Game.Singleton.GameState == GameState.Racing)
      {
         var steeringInput = Input.GetAxis("Horizontal");
         _playerRigidbody.transform.Rotate(Vector3.up, steeringInput * Time.deltaTime * Game.Singleton.Settings.PlayerTurnSpeed, Space.Self);
      }
   }
}
