using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
 


    
        [SerializeField] private Health playerHealth;
        [SerializeField] private Health totalhealthBar;
        [SerializeField] private Image currenthealthBar;
        //[SerializeField] private Health fillAount;
        


        private void Start()
        {
            //totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
        }
        private void Update()
        {
            currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
        }

    
}
