using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour {
    /**
    ** Ускорение игрока
    **/
  [Header("Player velocity")]
    // Ось Ox
    public int xVelocity = 3;
    public int FastSpeed = 6;
    public int CurrentSpeed;
    // Ось Oy
    public int yVelocity = 8;

  [SerializeField] private LayerMask ground;

    private Rigidbody2D rigidBody;
    private Collider2D coll;
    private SpriteRenderer spriteRenderer; 
    private Animator animatorComponent;
    public GameObject barObject;
    public HealthBar2 healthBarScript;
    public GameObject TruretObject;
    public TurretBehaviour TurretBehaviourScript;

   

    private void Start() {
      TruretObject = GameObject.Find("turret");
                
      TurretBehaviourScript = TruretObject.GetComponent<TurretBehaviour>();
                
     
      rigidBody = gameObject.GetComponent<Rigidbody2D>();
      
      coll = gameObject.GetComponent<Collider2D>();
      spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      animatorComponent = gameObject.GetComponent<Animator>();
      CurrentSpeed = xVelocity;
      //Находим бар
      barObject = GameObject.Find("HealthBar");
                
      //Получаем бар с найденного объекта
      healthBarScript = barObject.GetComponent<HealthBar2>();
    }
    

    private void Update() {

      if (TurretBehaviourScript.alive==true)
        updatePlayerPosition();
     /* if (healthScript.health <= 0)
          {
              animatorComponent.SetInteger("state", 2);
              Debug.Log("Ded");
        
          }*/
    }
    void OnCollisionEnter2D (Collision2D collision){
      if (collision.transform.tag=="Respawn"){
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
      }
    }
    /*void OnCollisionEnter2D (Collision2D collision)
        {
          if (collision.transform.tag=="Bullet")
          {
            
            Health healthScript = collision.transform.GetComponent<Health>();
            if( healthScript && healthBarScript)
              {
                if (healthScript.health <= 0)
                {
                  animatorComponent.SetInteger("state", 2);
                  Debug.Log("Ded");
                }
              }
              else Debug.Log("no script");
          }

        }*/

    // Обновляем местоположение игрока
    private void updatePlayerPosition() {
      float moveInput = Input.GetAxis("Horizontal");
      float jumpInput = Input.GetAxis("Jump");
      if (coll.IsTouchingLayers(ground)) {
        animatorComponent.SetBool("ground", true);
      }
      else {
        animatorComponent.SetBool("ground", false);
      }
      if (moveInput < 0 ) { // Влево
        rigidBody.velocity = new Vector2(-CurrentSpeed, rigidBody.velocity.y);
        if  (coll.IsTouchingLayers(ground))
        {
          animatorComponent.SetInteger("state", 1); // ходьба
        } 
        spriteRenderer.flipX = true;
      } else if (moveInput > 0) { // Вправо
        rigidBody.velocity = new Vector2(CurrentSpeed, rigidBody.velocity.y);
        if  (coll.IsTouchingLayers(ground))
        {
          animatorComponent.SetInteger("state", 1); // ходьба
        } 
        spriteRenderer.flipX = false;
      } else if (coll.IsTouchingLayers(ground)) {
        rigidBody.velocity = Vector2.zero; // Отключение инерции в стороны
        animatorComponent.SetInteger("state", 0); // Стоим
      }
      if (Input.GetKey(KeyCode.LeftShift)){
        animatorComponent.SetBool("Run", true); //бег
        CurrentSpeed = FastSpeed;
      }
      else {
        animatorComponent.SetBool("Run", false);
        CurrentSpeed = xVelocity;
      }

      if (jumpInput > 0 && coll.IsTouchingLayers(ground)) { 
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, yVelocity);
        animatorComponent.SetInteger("state", 2);
      }
    }
}
