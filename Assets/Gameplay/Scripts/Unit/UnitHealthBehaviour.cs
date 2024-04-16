using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utilities.Inspector;

namespace DragonCrashers
{

    public class UnitHealthBehaviour : MonoBehaviour
    {

        [Header("Health Info")]
        [SerializeField]
        [ReadOnly] public int currentHealth;

        [Header("Events")]
        public UnityEvent<int> healthDifferenceEvent;
        public UnityEvent healthIsZeroEvent;

        private int maxHealth;

        //Delegate for external systems to detect (IE: Unit's UI)
        public delegate void HealthChangedEventHandler(int newHealthAmount);
        public event HealthChangedEventHandler HealthChangedEvent;


        public void SetupCurrentHealth(int totalHealth)
        {
            currentHealth = totalHealth;
            maxHealth = totalHealth;
        }

        public void ChangeHealth(int healthDifference, int decreasehealth)
        {
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
                //print("max");
            }
            currentHealth = currentHealth + healthDifference;
            currentHealth = currentHealth - decreasehealth;
            //print(currentHealth);
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                HealthIsZeroEvent();
            }
            if (healthDifference != 0)
            {
                healthDifferenceEvent.Invoke(healthDifference);
            }
            if (decreasehealth != 0)
            {
                healthDifferenceEvent.Invoke(-decreasehealth);
            }
            DelegateEventHealthChanged();
        }

        public int GetCurrentHealth()
        {
            return currentHealth;
        }

        void HealthIsZeroEvent()
        {
            healthIsZeroEvent.Invoke();
        }

        void DelegateEventHealthChanged()
        {
            if(HealthChangedEvent != null)
            {
                HealthChangedEvent(currentHealth);
            }
        }

    }
}