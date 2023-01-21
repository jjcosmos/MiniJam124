
    using System;
    using UnityEngine;

    public class Game : MonoBehaviour
    {
        public static Game Singleton;
        public Player CurrentPlayer;

        private void Awake()
        {
            if (!Singleton)
            {
                Singleton = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
