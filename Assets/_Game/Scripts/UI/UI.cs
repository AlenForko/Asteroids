using System;
using DefaultNamespace.ScriptableEvents;
using TMPro;
using UnityEngine;
using Variables;

namespace UI
{
    public class UI : MonoBehaviour
    {
        [Header("Health:")] 
        [SerializeField] private ShipInfo _shipInfo;
        [SerializeField] private TextMeshProUGUI _healthText;

        [Header("Score:")]
        [SerializeField] private TextMeshProUGUI _scoreText;
        
        [Header("Timer:")]
        [SerializeField] private TextMeshProUGUI _timerText;

        private float _time;
        
        [Header("Laser:")]
        [SerializeField] private TextMeshProUGUI _laserText;

        private void Update()
        {
            SetTimerText();
        }
        
        public void SetScoreText(int amount)
        {
            _scoreText.text = "Score: " + amount;
        }
        
        private void SetTimerText()
        {
            _time += Time.deltaTime;
            _timerText.text = "Time: " + Mathf.RoundToInt(_time);
        }
        
        public void SetLaserText(int amount)
        {
            _laserText.text = "Laser shots: " + amount;
        }

        public void SetHealth(int amount)
        {
            _healthText.text = "Health: " + amount;
        }
    }
}
