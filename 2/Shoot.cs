using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
        //Префаб с пулей
        public GameObject bullet;
        //Сила выстрела
        public float force;
        // Use this for initialization
        void Start () {
       
        }
       
        // Update is called once per frame
        void Update () {
                //Если нажимается левая кнопка мыши
                if( Input.GetMouseButtonDown(0) )
                {
                        //Если префаб с пулей указан
                        if (bullet)
                        {
                                //Создаётся объект (объект, точка создания, его ротация)
                                GameObject go = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                                //Придание объекту ускарение с помощью импульса
                                go.GetComponent<Rigidbody>() .AddForce(transform.forward * force, ForceMode.Impulse );
                        }
                }
        }
}