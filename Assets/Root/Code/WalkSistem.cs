using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class WalkSistem : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D walkableArea;





    private NavMeshAgent NavMeshAgent;

    [SerializeField]  private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public bool moving;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NavMeshAgent=GetComponent<NavMeshAgent>();
        NavMeshAgent.updateRotation = false;
        NavMeshAgent.updateUpAxis = false;


 
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            Move();
        }



         moving = NavMeshAgent.velocity.sqrMagnitude > 0.01f;
        

        if (moving)
        {
            animator.SetBool("Walk",true);
        }
    
        else
        {
            animator.SetBool("Walk", false);

        }



        Vector3 velocity = NavMeshAgent.velocity;

        if (velocity.x > 0.01f)
        {
           
            spriteRenderer.flipX = false;
        }
        else if (velocity.x < -0.01f)
        {
          
            spriteRenderer.flipX = true;
        }
     
    }
    void Move()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (walkableArea.OverlapPoint(mousePosition))
        {
            NavMeshAgent.SetDestination(mousePosition);
        }
    }

   
}
