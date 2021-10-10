using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public float Range;
    public GameObject Target;
    bool Detected = false;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject Bullet;
    public float FireRate;
    float nextTimeToFire=0;
    public GameObject ShootPoint;
    public float force;
    public bool alive;

    // Start is called before the first frame update
    void Start()
    {
        Range=30;
        Target = GameObject.Find("Player");
        Gun = GameObject.Find("Gun");
        Bullet = Resources.Load<GameObject>("Bullet");
        FireRate =5;
        ShootPoint =GameObject.Find("ShootPoint");
        force =100;



        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive == true){
            Vector2 targetPos = Target.transform.position;
            Direction = targetPos - (Vector2)transform.position;

            RaycastHit2D rayInfo =  Physics2D.Raycast(transform.position, Direction, Range);
            if (rayInfo){
                if (rayInfo.collider.gameObject.tag == "Turret"){
                    if (Detected == false){
                        Detected =true;
                    }
        
                }
                else {
                    if (Detected == true){
                        Detected =false;


                    }
                }
                if (Detected){
                    Gun.transform.right = -Direction;
                    if (Time.time > nextTimeToFire){
                        nextTimeToFire = Time.time+1/FireRate;
                        shoot();
                    }
                }
            }
            void shoot(){
                GameObject BulletIns = Instantiate(Bullet, ShootPoint.transform.position, Quaternion.identity);
                BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * force);
            }
            void OnDrawGizmosSelected(){
                Gizmos.DrawWireSphere(transform.position, Range);
            }  
        }      
    
    }
}
