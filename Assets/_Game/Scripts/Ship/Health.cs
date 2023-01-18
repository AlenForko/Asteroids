using System;
using UnityEngine;

namespace Ship
{
    public class Health : MonoBehaviour
    {
        private const int MIN_HEALTH = 0;

        [SerializeField] private ShipInfo _shipInfo;
        [SerializeField] private UI.UI _ui;


        private void Start()
        {
            _ui.SetHealth(_shipInfo.health);
        }

        public void TakeDamage(int damage)
        {
            _shipInfo.health = Mathf.Max(MIN_HEALTH, _shipInfo.health - damage);
            if (_shipInfo.health <= 0)
            {
                Destroy(gameObject);
            }
            _ui.SetHealth(_shipInfo.health);
        }
    }
}
