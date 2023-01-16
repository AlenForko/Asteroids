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
        [SerializeField] private IntVariable _healthVar;
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private ScriptableEventIntReference _onHealthChangedEvent;
        
        [Header("Score:")]
        [SerializeField] private TextMeshProUGUI _scoreText;
        
        [Header("Timer:")]
        [SerializeField] private TextMeshProUGUI _timerText;

        private float time;
        
        [Header("Laser:")]
        [SerializeField] private TextMeshProUGUI _laserText;
        
        private void Start()
        {
            SetHealthText($"Health: {_healthVar.Value}");
        }

        private void Update()
        {
            SetTimerText();
        }

        public void OnHealthChanged(IntReference newValue)
        {
            SetHealthText($"Health: {newValue.GetValue()}");
        }

        private void SetHealthText(string text)
        {
            _healthText.text = text;
        }
        
        public void SetScoreText(int amount)
        {
                _scoreText.text = "Score: " + amount;
        }
        
        private void SetTimerText()
        {
            time += Time.deltaTime;
            _timerText.text = "Time: " + Mathf.RoundToInt(time);
        }
        
        public void SetLaserText(int amount)
        {
            _laserText.text = "Laser shots: " + amount;
        }
    }
}
