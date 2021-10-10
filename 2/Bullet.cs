using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
        //Величина урона
        public int damage;
        //Объект со скриптом бара
        public GameObject barObject;
        public HealthBar2 healthBarScript;
        public GameObject TruretObject;
        public TurretBehaviour TurretBehaviourScript;
        // Use this for initialization
        void Start () {
                //Находим бар
                TruretObject = GameObject.Find("turret");
                
                TurretBehaviourScript = TruretObject.GetComponent<TurretBehaviour>();
                barObject = GameObject.Find("HealthBar");
                
                //Получаем бар с найденного объекта
                healthBarScript = barObject.GetComponent<HealthBar2>();
        }
       
        // Update is called once per frame
        void Update () {
       
        }
       
        void OnCollisionEnter2D (Collision2D collision)
        {
                        //Отправляет сообщение в лог с тегом врага
                if (TurretBehaviourScript.alive==true){
                        //Проверка тега объекта
                        if (collision.transform.tag=="PlayerTag")
                        {
                                //Получаем скрипт Health с объекта коллизии
                                Health healthScript = collision.transform.GetComponent<Health>();
                                //Если мы смогли получить оба скрипта
                                if( healthScript && healthBarScript)
                                {
                                        //Делаем урон врагу
                                        healthScript.health -= damage;
                                        //Если хп стало меньше нуля, то ставим 0
                                        if (healthScript.health < 0)
                                        {
                                        // collision.transform.GetComponent<Animator>().SetInteger("state", 3);
                                                healthScript.health = 0;
                                                Debug.Log("Dead");
                
                                        }
                                        Debug.Log(healthScript.health);
                                        //Отправляем в бар инормацию об хп и хп максимальном врага
                                        healthBarScript.health = healthScript.health;
                                        healthBarScript.healthMax = healthScript.healthMax;
                                        //Показывавем бар
                                        barObject.transform.localScale = new Vector3((float)healthScript.health/healthScript.healthMax, 1,1);
                                
                                        healthBarScript.showBar = true;
                                }
                                //Если у нас нет скриптов
                                else
                                {
                                
                                        Debug.Log("No scripts");
                                }
                        }
                        
                        //Удаляем объект
                        Destroy(gameObject);
                }        
        }
}