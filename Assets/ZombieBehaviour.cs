using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    Animator animator;
    float time, emissionTime;
    int hitted;
    ParticleSystem ps;
    ParticleSystem.EmissionModule emission;
    private float time3;
    public static bool zombieAttack=false;
    private int trigger;
    private float time2;
    private object counter;

    // Use this for initialization
    void Start()
    {
//        Camera.main.GetComponent<Rigidbody>().isKinematic = false;
        animator = GetComponent<Animator>();
        ps = GetComponent<ParticleSystem>();
        emission = ps.emission;
        emission.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(zombieAttack);
        if (PlayerScriptScene3.bossFight)
            Destroy(gameObject);
        if (hitted == 3 && Mathf.Abs(transform.position.z - Camera.main.transform.position.z) < 2  ) zombieAttack = false;
        if (PlayerScriptScene3.score < 0 && zombieAttack && transform.position.z-Camera.main.transform.position.z<2)
        {              
            
            Camera.main.GetComponent<BoxCollider>().enabled = false;
            animator.SetBool("DeathClose", true);
            transform.position= Vector3.MoveTowards(transform.position, new Vector3(-0.31f, 0.7f, transform.position.z),0.02f);
Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(-0.31f, 0.41f, transform.position.z-0.2f), 0.2f);
           
        Camera.main.transform.eulerAngles = Vector3.MoveTowards(Camera.main.transform.eulerAngles, new Vector3(-90f,0, 0), 1.3f);
            Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, 0, 0);
            if(Mathf.Abs (Camera.main.transform.eulerAngles.x+90)<2)
                Camera.main.transform.eulerAngles = new Vector3(-90, 0, 0);

        }

        if (hitted == 3 && !zombieAttack)
            GetComponent<CapsuleCollider>().enabled = false;
        if (hitted==3&& Mathf.Abs( transform.position.z-Camera.main.transform.position.z)<1)
        {
          
            time2 += Time.deltaTime;
           
        }
        if (time2 >= 0.9f)
        {
            time2 = 0;
            zombieAttack = false;
        }
    if(zombieAttack && Mathf.Abs( transform.position.z-Camera.main.transform.position.z)<1  )
        {
        
            time3 += Time.deltaTime;
            if (time3 >=2f)
            {
                PlayerScriptScene3.score -= 5;
                time3 = 0;
            }

        }
      //  Debug.Log(PlayerScript.score +" "+ time3);
        if (!zombieAttack)
            //     transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * 3);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Camera.main.transform.position.x,0.31f, Camera.main.transform.position.z), 0.02f);


        if (emission.enabled)
        { emissionTime += Time.deltaTime; }
        if (emissionTime >= 0.5f)
        {
            emissionTime = 0;
            emission.enabled = false;

        }
        if (hitted==1||hitted==2)
        { time += Time.deltaTime; }
        if (time >= 0.75f)
        {
            time = 0;
            animator.SetInteger("Hitted", 0);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
 
        if (other.gameObject.tag == "zombieZone")
        {
            time3 = 0;
            
            //      Camera.main.GetComponent<Rigidbody>().isKinematic = false;
            zombieAttack = true;

            PlayerScriptScene3.score -= 1;

            animator.SetBool("Attack", true);
         //   Camera.main.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            emission.enabled= true;
            hitted++;
            if (hitted > 3)
            { hitted= 3;

             
            }

            animator.SetInteger("Hitted",hitted);
        }


    }
}

