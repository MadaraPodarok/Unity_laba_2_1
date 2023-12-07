using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    private Camera cam;
    private NavMeshAgent agent;
    
    private Vector3 move;

    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // мышь
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }
        } else if ((move.x = Input.GetAxis("Horizontal")) != 0 || (move.z = Input.GetAxis("Vertical")) != 0) // клавиатура
        {
            var moveDirection = new Vector3(move.x, 0, move.z);
            var movePosition = transform.position + moveDirection;
            agent.speed = 30;
            agent.SetDestination(movePosition);
        }
        if (Time.timeScale == 0)
        {
            return;
        }
    }
}
