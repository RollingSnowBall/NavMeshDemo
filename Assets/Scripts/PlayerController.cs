using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public Camera cam;

    public NavMeshAgent agent;
	public Animator animator;
	public NavMeshSurface surface;
	public NavMeshData data;

	void Awake(){
//		agent.SetDestination(Vector3.zero);
//		NavMeshHit hit;
//		var ss = NavMesh.SamplePosition (Vector3.zero, out hit, 1.0f, NavMesh.AllAreas);
	}

	void Start(){
		Instantiate (Resources.Load ("Walls"));
		surface.BuildNavMesh();
	}
    
    // Update is called once per frame
    void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
				Debug.Log ("++++");
				NavMeshHit h;

				var sor = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
//				print(NavMesh.GetAreaCost(NavMesh.GetAreaFromName ("Walkable")));
//				print(NavMesh.GetAreaCost(NavMesh.GetAreaFromName ("Jump")));
//				print(NavMesh.GetAreaFromName ("Jump"));
//				print ("++++");

				var ss = NavMesh.SamplePosition (sor,out h, 1f, (int)NavMesh.GetAreaCost(NavMesh.GetAreaFromName ("Walkable")));
//				Resources.loa
//				Debug.Log (h.distance);
				Debug.Log (sor);
				Debug.Log (ss);
//				Debug.Log (hit.point);
				agent.SetDestination(hit.point);
				animator.SetBool ("IsRun", true);

            }
        }
    }
}