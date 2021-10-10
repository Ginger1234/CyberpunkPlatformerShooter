using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
        //Хп врага
       
        public int health;
        public int healthMax;
        private Animator animatorComponent;
         public GameObject TruretObject;
        public TurretBehaviour TurretBehaviourScript;

        // Use this for initialization
        void Start () {
                 TruretObject = GameObject.Find("turret");
                
                TurretBehaviourScript = TruretObject.GetComponent<TurretBehaviour>();
                //Хп становится максимальным при старте
                animatorComponent = gameObject.GetComponent<Animator>();
                health = healthMax;
        }
        
        private IEnumerator Wait()
        {
                yield return new WaitForSeconds(2.0f); // таймер, через 10 секунд
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
       
        // Update is called once per frame
        void Update () {
                
                        
                if (health<=0){
                        Debug.Log("no health");
                        TurretBehaviourScript.alive=false;

                        animatorComponent.SetInteger("state", 3);
                        StartCoroutine(Wait());
                        //Destroy(gameObject);
                        //health = healthMax;
                       // SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);


                  
                }

        
        }
        
        
}