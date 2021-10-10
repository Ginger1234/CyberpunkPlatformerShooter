using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public HealthBar healthBarScript;
    public GameObject Bar;
    //HealthSystem healthSystem = new HealthSystem(100);
    // Start is called before the first frame update
    void Start()
    {
             Bar = GameObject.Find("HealthBar");
             if (Bar != null) {
                healthBarScript = Bar.GetComponent<HealthBar>();
               // Debug.Log("Bar");
               // if (healthBarScript != null)  Debug.Log("Script");
             }
             else Debug.Log("No Bar");
           

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D Col){
       Destroy (this.gameObject);
        /*if (healthBarScript != null && Bar != null) {
            healthBarScript.HealthSystem_OnHealthChanged()
         }
         else Debug.Log("Noooo");*/
        //add damage to player 
    }
}
