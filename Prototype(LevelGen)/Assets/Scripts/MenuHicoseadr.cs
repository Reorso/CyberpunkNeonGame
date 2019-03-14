using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://answers.unity.com/questions/1091527/how-to-calculate-the-vertices-of-an-icosphere.html

public class MenuHicoseadr : MonoBehaviour
{
	public float displacement = 0.1f;
	public int n = 5;
	public float radius = 10;
    public GameObject prefab;
	public bool recalculate = false;
	bool saved = true;
	List<Vector3> vertices;
	int[] triangles;
	List<GameObject> ogg;
	public Material material;
	public float width = 0.1f;

	void FixedUpdate(){
		if(saved = recalculate){
			foreach (GameObject g in ogg) {
				Destroy(g);
			}
			ogg.Clear();

			saved = !saved;
			CalculateRadiusDistance();
		}
	}

	void Start(){
		ogg = new List<GameObject>();
		Icosehadro();
		Lines();

	}

    public void Icosehadro()
    {
        int nn = n * 4;
        int vertexNum = (nn * nn / 16) * 24;
		vertices = new List<Vector3>();
        triangles = new int[vertexNum];

        Quaternion[] init_vectors = new Quaternion[24];
        // 0
        init_vectors[0] = new Quaternion(0, 1, 0, 0);   //the triangle vertical to (1,1,1)
        init_vectors[1] = new Quaternion(0, 0, 1, 0);
        init_vectors[2] = new Quaternion(1, 0, 0, 0);
        // 1
        init_vectors[3] = new Quaternion(0, -1, 0, 0);  //to (1,-1,1)
        init_vectors[4] = new Quaternion(1, 0, 0, 0);
        init_vectors[5] = new Quaternion(0, 0, 1, 0);
        // 2
        init_vectors[6] = new Quaternion(0, 1, 0, 0);   //to (-1,1,1)
        init_vectors[7] = new Quaternion(-1, 0, 0, 0);
        init_vectors[8] = new Quaternion(0, 0, 1, 0);
        // 3
        init_vectors[9] = new Quaternion(0, -1, 0, 0);  //to (-1,-1,1)
        init_vectors[10] = new Quaternion(0, 0, 1, 0);
        init_vectors[11] = new Quaternion(-1, 0, 0, 0);
        // 4
        init_vectors[12] = new Quaternion(0, 1, 0, 0);  //to (1,1,-1)
        init_vectors[13] = new Quaternion(1, 0, 0, 0);
        init_vectors[14] = new Quaternion(0, 0, -1, 0);
        // 5
        init_vectors[15] = new Quaternion(0, 1, 0, 0); //to (-1,1,-1)
        init_vectors[16] = new Quaternion(0, 0, -1, 0);
        init_vectors[17] = new Quaternion(-1, 0, 0, 0);
        // 6
        init_vectors[18] = new Quaternion(0, -1, 0, 0); //to (-1,-1,-1)
        init_vectors[19] = new Quaternion(-1, 0, 0, 0);
        init_vectors[20] = new Quaternion(0, 0, -1, 0);
        // 7
        init_vectors[21] = new Quaternion(0, -1, 0, 0);  //to (1,-1,-1)
        init_vectors[22] = new Quaternion(0, 0, -1, 0);
        init_vectors[23] = new Quaternion(1, 0, 0, 0);

        int j = 0;  //index on vectors[]

        for (int i = 0; i < 24; i += 3)
        {
            /*
			 *                   c _________d
			 *    ^ /\           /\        /
			 *   / /  \         /  \      /
			 *  p /    \       /    \    /
			 *   /      \     /      \  /
			 *  /________\   /________\/
			 *     q->       a         b
			 */
            for (int p = 0; p < n; p++)
            {
                //edge index 1
                Quaternion edge_p1 = Quaternion.Lerp(init_vectors[i], init_vectors[i + 2], (float)p / n);
                Quaternion edge_p2 = Quaternion.Lerp(init_vectors[i + 1], init_vectors[i + 2], (float)p / n);
                Quaternion edge_p3 = Quaternion.Lerp(init_vectors[i], init_vectors[i + 2], (float)(p + 1) / n);
                Quaternion edge_p4 = Quaternion.Lerp(init_vectors[i + 1], init_vectors[i + 2], (float)(p + 1) / n);

                for (int q = 0; q < (n - p); q++)
                {
                    //edge index 2
                    Quaternion a = Quaternion.Lerp(edge_p1, edge_p2, (float)q / (n - p));
                    Quaternion b = Quaternion.Lerp(edge_p1, edge_p2, (float)(q + 1) / (n - p));
                    Quaternion c, d;
                    if (edge_p3 == edge_p4)
                    {
                        c = edge_p3;
                        d = edge_p3;
                    }
                    else
                    {
                        c = Quaternion.Lerp(edge_p3, edge_p4, (float)q / (n - p - 1));
                        d = Quaternion.Lerp(edge_p3, edge_p4, (float)(q + 1) / (n - p - 1));
                    }

                    triangles[j] = j;
                    vertices.Add(new Vector3(a.x, a.y, a.z));
					j++;
                    triangles[j] = j;
                    vertices.Add(new Vector3(b.x, b.y, b.z));
					j++;
                    triangles[j] = j;
                    vertices.Add(new Vector3(c.x, c.y, c.z));
					j++;
                    if (q < n - p - 1)
                    {
                        triangles[j] = j;
						vertices.Add(new Vector3(c.x, c.y, c.z));
						j++;
                        triangles[j] = j;
						vertices.Add(new Vector3(b.x, b.y, b.z));
						j++;
                        triangles[j] = j;
						vertices.Add(new Vector3(d.x, d.y, d.z));
						j++;
                    }
                }
            }
        }
		//CleanUp();
		CalculateRadiusDistance();

    }
	void CalculateRadiusDistance()
	{
		int jhonny = 0;

        foreach (Vector3 v in vertices)
        {
			vertices[jhonny] = vertices[jhonny] + (Random.onUnitSphere * displacement);
			vertices[jhonny] = vertices[jhonny].normalized * radius;
            GameObject coso = Instantiate(prefab);
			coso.transform.parent = this.transform;
			coso.transform.localPosition = vertices[jhonny];
			ogg.Add(coso);
			jhonny++;
        }
	}

	void CleanUp()
	{
        for(int jhonny = 0; jhonny < triangles[1] * 3; jhonny++)
        {
			//print(jhonny);
			for (int j = 0; j < jhonny; j++) {
				if(vertices[jhonny] == vertices[j]){
					vertices.RemoveAt(j);
				}
			}
        }
	}

	void Lines(){
		for(int i = 0; i < triangles.Length; i += 3){
			DrawLine(vertices[i], vertices[i+1]);
			DrawLine(vertices[i+1], vertices[i+2]);
			DrawLine(vertices[i+2], vertices[i]);
		}
	}

 void DrawLine(Vector3 start, Vector3 end)
         {
             GameObject myLine = new GameObject();
			 myLine.transform.parent = this.transform;
             myLine.transform.localPosition = start;
             myLine.AddComponent<LineRenderer>();
             LineRenderer lr = myLine.GetComponent<LineRenderer>();
             lr.material = material;
             lr.SetWidth(width, width);
             lr.SetPosition(0, -transform.InverseTransformPoint(start));
             lr.SetPosition(1, -transform.InverseTransformPoint(end));
         }
}