using System;
using UnityEngine;

namespace Ship
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Laser _laserPrefab;
        [SerializeField] private UI.UI _ui;
        private int laserAmount;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
                laserAmount++;
                _ui.SetLaserText(laserAmount);
            }
                
        }
        
        private void Shoot()
        {
            var trans = transform;
            Instantiate(_laserPrefab, trans.position, trans.rotation);
        }
    }
}
