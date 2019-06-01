using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int iD;
    public string type;
    public bool isFlyer;
    public GameObject smoke;
    public float duration;
    public float spawnTime;
    public int maxHealth;
    public int currentHealth;
    public int maxShield;
    public int maxSpeed;
    public int shieldRegen;
    public float weight;
    public string movementType;
    public Vector3 movementTarget;
    public List<Transform> path; // hierarchy objects should be ordered
    public int currentPathTarget = 0;
    public float distanceTolerance;


    private Rigidbody2D enemyRigidBody;
    void OnDeath()
    {
        duration = Time.time-spawnTime;
        Debug.Log("A " + type + " enemy died after " + duration+ " seconds!");
    }

    void OnHurt()
    {

    }
    // Start is called before the first frame update
    void Awake()
    {
        // initialize iD
           // get enemyCounter from level, increment by 1, set this to that.

        // initialize
        spawnTime = Time.time;

        // pull from table to get
          // isFlyer
          // max HP
          // max Shield
          // max Speed
          // shield Regen
          // pathBehavior[][]
          // Weight
          // Distance Tolerance
            distanceTolerance = .3f;

        smoke.SetActive(false);
        MovementInit();
        // call level and tell it that it has another active enemy

        enemyRigidBody = GetComponent<Rigidbody2D>();

    }
    void MovementInit()
    {
        // movementType = pathBehavior[0][0];  //MVP movement model
        movementType = "path";

        if (movementType == "path")
        {
            // grab path stuff
            foreach (Transform child in transform.parent)
            {
                // Debug.Log(child.name);
                if (child.name == "EnemyPath")
                {
                    foreach (Transform grandChild in child)
                    {
                        // Debug.Log(grandChild.name);
                        path.Add(grandChild);
                        // Debug.Log(grandChild.transform.position);
                        // Debug.Log(grandChild.name + " added to path");
                    }
                break;
                }
            }
            // Debug.Log(path.Count);
            // Debug.Log(path[0].name);
            SetMovementTarget(path[0].transform);
        }

    }
    // Update is called once per frame
    void Update()
    {
        SmokeCheck();
        Move();
    }
    void SmokeCheck()
    {
        if(currentHealth<=maxHealth/4)
        {
            smoke.SetActive(true);
        }
        else
        {
            smoke.SetActive(false);
        }
    }
    void Move()
    {
        if(movementType == "path")
        {
            // Debug.Log("move has been called");
            // check and see how close we are to the target
            Vector3 displacement = movementTarget-transform.position;
            if(displacement.magnitude < distanceTolerance)
            {
                int newPathTarget = (currentPathTarget++)%path.Count;
                SetMovementTarget(path[newPathTarget].transform);
            }
            
            displacement.Normalize();

            // enemyRigidBody.MovePosition(transform.position+displacement);
            
            // do the actual movement
            Vector3 newPos = (transform.position+displacement*0.05f);
            transform.position = newPos;

        }
        if(movementType == "mongo")
        {
            // attack logic
        }
    }

    void SetMovementTarget(Transform target)
    {
        movementTarget = target.position;
        Debug.Log("movementTarget updated to "+target.name);
        Debug.Log(movementTarget);
    }

}