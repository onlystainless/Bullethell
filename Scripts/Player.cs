using UnityEngine;

public class Player : MonoBehaviour 
{
public Bullet bulletPrefab;
private Rigidbody2D _rigidbody;
public float moveSpeed = 5;


    

void Start()
{
   
}


 void Update()
{

    if (Input.GetKey(KeyCode.D))
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        
    }
    else if (Input.GetKey(KeyCode.A))
    {
        transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
        
    }

    else if (Input.GetKey(KeyCode.W))
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

    }
    else if (Input.GetKey(KeyCode.S))
    {
        transform.position += Vector3.up * -moveSpeed * Time.deltaTime;

    }
    else if (Input.GetKeyDown(KeyCode.Space)) 
    {
            Shoot();
    }
    


         void OnParticleCollision(Collision2D collision)
         {

        var collision = system.collision;
        collision.type = ParticleSystemCollisionType.World;
        collision.mode = ParticleSystemCollisionMode.Collision2D;
        collision.lifetimeLoss = 1; 
        if(this.gameObject.tag == "Player") collision.collidesWith = this.gameObject;
        collision.sendCollisionMessages = true;
        collision.enabled = true;

         }
        
    

      void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }

}

}

