using System;
using UnityEngine;

public class Player : MonoBehaviour
{
   private Rigidbody _playerRigidbody;
   private PlayerInventory _inventory;
   private float _moveModifier = 1f;

   [SerializeField] private AudioSource _sliderSource;

   private void Start()
   {
      _playerRigidbody = GetComponent<Rigidbody>();
      _inventory = GetComponent<PlayerInventory>();
      _playerRigidbody.isKinematic = true;
      
      _inventory.OnhandWarmerCollected.AddListener(UpdateMoveModifier);
   }

   private void Update()
   {
      if (Game.Singleton.GameState == GameState.Racing && _playerRigidbody.isKinematic)
      {
         _playerRigidbody.isKinematic = false;
      }
      
      AddForwardForce();
      ProcessSteeringInput();
      UpdateSkidSound();
   }
   
   private void UpdateSkidSound()
   {
      var velocity = _playerRigidbody.velocity.magnitude;
      var scale = velocity / 45f;
      _sliderSource.volume = scale;
      _sliderSource.pitch = 1 + Mathf.Lerp(-.1f, .1f, _sliderSource.volume);
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
      if(Game.Singleton.GameState is GameState.Racing or GameState.CompletedRace)
      {
         var steeringInput = Input.GetAxis("Horizontal");
         _playerRigidbody.transform.Rotate(Vector3.up, steeringInput * Time.deltaTime * Game.Singleton.Settings.PlayerTurnSpeed, Space.Self);
      }
   }
}
