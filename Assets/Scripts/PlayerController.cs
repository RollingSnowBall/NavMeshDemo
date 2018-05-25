using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public Camera cam;

    public NavMeshAgent agent;
	public Animator animator;
	public NavMeshData data;

	private NavMeshPath path;

	void Awake(){
		path = new NavMeshPath();
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

//				var sor = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
				print(NavMesh.GetAreaCost(NavMesh.GetAreaFromName ("Walkable")));
				print(NavMesh.GetAreaCost(NavMesh.GetAreaFromName ("TestArea")));
				print(NavMesh.GetAreaFromName ("TestArea"));
//				print ("++++");

				var ss = NavMesh.SamplePosition (hit.point,out h, 1f, NavMesh.AllAreas);
//				Debug.DrawLine(this.transform.position, h.position, Color.red, 100000);
//				print (h.position);
				print (hit.point);
				print ("++++++samp   : " + ss);

				NavMeshHit hit1;
				if (NavMesh.FindClosestEdge (hit.point, out hit1, 123)) {
					DrawCircle (hit.point, hit1.distance, Color.red);
					Debug.DrawRay (hit1.position, Vector3.up, Color.red, 10000);
				}
//				agent.SetDestination(hit.point);
//				animator.SetBool ("IsRun", true);

				//寻找Path
//				NavMesh.CalculatePath(transform.position, hit.point, NavMesh.AllAreas, path);
//				for (int i = 0; i < path.corners.Length - 1; i++) {
////					print (path.corners [i]);
//					Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red, 100000);
//				}


            }
        }

//		NavMeshHit hit1;
//		if (NavMesh.SamplePosition(transform.position, out hit1, 1.0f, NavMesh.AllAreas))
//		{
//			Debug.DrawRay (hit1.position, Vector3.up, Color.red, 10000);
//			Debug.Log (hit1.distance);
////			DrawCircle (transform.position, hit1.distance, Color.red);
//		}

		//获取距离边界的距离
//		NavMeshHit hit1;
//		if (NavMesh.FindClosestEdge (transform.position, out hit1, NavMesh.AllAreas)) {
//			DrawCircle (transform.position, hit1.distance, Color.red);
//			Debug.DrawRay (hit1.position, Vector3.up, Color.red, 10000);
//		} else {
//			print ("+++++FindClosestEdge false");
//		}
    }
		
	void DrawCircle(Vector3 center, float radius, Color color)
	{
		Vector3 prevPos = center + new Vector3(radius, 0, 0);
		for (int i = 0; i < 30; i++)
		{
			float angle = (float)(i + 1) / 30.0f * Mathf.PI * 2.0f;
			Vector3 newPos = center + new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
			Debug.DrawLine(prevPos, newPos, color, 10000);
			prevPos = newPos;
		}
	}
}