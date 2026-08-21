using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class WalkSistem : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D walkableArea;



    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 1.2f;

    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 5f;

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


        float t = Mathf.InverseLerp(minY, maxY, transform.position.y);
        float targetScale = Mathf.Lerp(minScale, maxScale, t);
        transform.localScale = new Vector3(targetScale, targetScale, targetScale);
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            Move();
        }



         moving = NavMeshAgent.velocity.sqrMagnitude > 0.01f;
            //Resize();

        if (moving)
        {
            animator.SetBool("Walk",true);
        }
        // animación caminar
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
