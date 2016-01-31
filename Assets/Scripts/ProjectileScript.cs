using UnityEngine;


public class ProjectileScript : MonoBehaviour{

    public int damage = 1;
    public float speed = 20;
    public bool isEnemyProjectile = false;

    private Rigidbody2D physic;

    ProjectileScript(){

     /*   if (!toTheRight){

            speed *= -1;
        }*/
        Debug.Log("test");
    }

    void Start(){

        physic = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
        //Debug.Log("test1");
    }

    void FixedUpdate(){

        //var player = GameObject.FindWithTag("Player").GetComponent<>;
        physic.velocity = new Vector2(speed, 0);
        transform.Rotate(0, 0, -10);
    }
}