using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DragonCrashers
{
    public class UIUpdateWolf : MonoBehaviour
    {

        public UnitController controller;
        private bool isPrinted;

        [Header("Health Settings")]
        public UnitHealthBehaviour healthBehaviour;
        private bool unitIsAlive;

        [Header("Target Settings")]
        public UnitTargetsBehaviour targetsBehaviour;

        private float timeSinceLastAttack = 0f;
        private const float healthDecreaseInterval = 1f; // Decrease health every second

        private int temp2 = 1;

        private void Start()
        {
            isPrinted = true;
        }

        void Update()
        {

            if (controller.isBattleStarted && !controller.isBattleStoped)
            {
                if (isPrinted)
                {
                    //print("Battle Started");
                    isPrinted = false;
                }
                if (controller.unitIsAlive)
                {
                    // Decrease health over time if no attack
                    timeSinceLastAttack += Time.deltaTime;
                    if (timeSinceLastAttack >= healthDecreaseInterval)
                    {
                        if (healthBehaviour.currentHealth > 0)
                        {
                            // Decrease health by 1 HP
                            healthBehaviour.ChangeHealth(0, 1);
                            timeSinceLastAttack = 0f;
                        }
                    }


                    int temp1 = controller.GivenHealthDamage;

                    if (temp1 != 0 && temp2 != temp1)
                    {
                        temp2 = temp1;
                        healthBehaviour.ChangeHealth(-controller.GivenHealthDamage, 0);
                        //print("witch damage " + -controller.witchDamageGivenValue);

                    }


                }
            }


        }
    }//class
}