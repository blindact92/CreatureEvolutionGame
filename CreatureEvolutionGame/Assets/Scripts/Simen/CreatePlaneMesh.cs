using UnityEngine;
using System.Collections;

public class CreatePlaneMesh : MonoBehaviour {

//	public float width = 50, height = 50;
//
//	// Use this for initialization
//	void Start () {
//		MeshFilter mf = GetComponent<MeshFilter> ();
//		Mesh mesh = new Mesh ();
//		mf.mesh = mesh;
//
//		//Vertices
//		Vector3[] vertices = new Vector3[4] {
//			new Vector3 (0, 0, 0), new Vector3 (width, 0, 0), new Vector3 (0, height, 0), new Vector3 (width, height, 0)
//		};
//
//		//Triangles
//		int [] tri = new int[6];
//
//		tri [0] = 0;
//		tri [1] = 2;
//		tri [2] = 1;
//
//		tri [3] = 2;
//		tri [4] = 3;
//		tri [5] = 1;
//
//		//Normals (for displaying it in game)
//		Vector3[] normals = new Vector3[4];
//
//		normals [0] = Vector3.forward;
//		normals [1] = Vector3.forward;
//		normals [2] = Vector3.forward;
//		normals [3] = Vector3.forward;
//
//		//UVs (how textures are displayed)
//		Vector2[] uv = new Vector2[4];
//
//		uv [0] = new Vector2 (0, 0);
//		uv [1] = new Vector2 (1, 0);
//		uv [2] = new Vector2 (0, 1);
//		uv [3] = new Vector2 (1, 1);
//
//
//		//Assign arrays
//		mesh.vertices = vertices;
//		mesh.triangles = tri;
//		mesh.normals = normals;
//		mesh.uv = uv;
//
//	}


	void Start () {
	// You can change that line to provide another MeshFilter
	MeshFilter filter = gameObject.AddComponent< MeshFilter >();
	Mesh mesh = filter.mesh;
	mesh.Clear();

	float length = 1f;
	float width = 1f;
	float height = 1f;

	#region Vertices
	Vector3 p0 = new Vector3( -length * .5f,	-width * .5f, height * .5f );
	Vector3 p1 = new Vector3( length * .5f, 	-width * .5f, height * .5f );
	Vector3 p2 = new Vector3( length * .5f, 	-width * .5f, -height * .5f );
	Vector3 p3 = new Vector3( -length * .5f,	-width * .5f, -height * .5f );	

	Vector3 p4 = new Vector3( -length * .5f,	width * .5f,  height * .5f );
	Vector3 p5 = new Vector3( length * .5f, 	width * .5f,  height * .5f );
	Vector3 p6 = new Vector3( length * .5f, 	width * .5f,  -height * .5f );
	Vector3 p7 = new Vector3( -length * .5f,	width * .5f,  -height * .5f );

	Vector3[] vertices = new Vector3[]
	{
		// Bottom
		p0, p1, p2, p3,

		// Left
		p7, p4, p0, p3,

		// Front
		p4, p5, p1, p0,

		// Back
		p6, p7, p3, p2,

		// Right
		p5, p6, p2, p1,

		// Top
		p7, p6, p5, p4
	};
	#endregion

	#region Normales
	Vector3 up 	= Vector3.up;
	Vector3 down 	= Vector3.down;
	Vector3 front 	= Vector3.forward;
	Vector3 back 	= Vector3.back;
	Vector3 left 	= Vector3.left;
	Vector3 right 	= Vector3.right;

	Vector3[] normales = new Vector3[]
	{
		// Bottom
		down, down, down, down,

		// Left
		left, left, left, left,

		// Front
		front, front, front, front,

		// Back
		back, back, back, back,

		// Right
		right, right, right, right,

		// Top
		up, up, up, up
	};
	#endregion	

	#region UVs
	Vector2 _00 = new Vector2( 0f, 0f );
	Vector2 _10 = new Vector2( 1f, 0f );
	Vector2 _01 = new Vector2( 0f, 1f );
	Vector2 _11 = new Vector2( 1f, 1f );

	Vector2[] uvs = new Vector2[]
	{
		// Bottom
		_11, _01, _00, _10,

		// Left
		_11, _01, _00, _10,

		// Front
		_11, _01, _00, _10,

		// Back
		_11, _01, _00, _10,

		// Right
		_11, _01, _00, _10,

		// Top
		_11, _01, _00, _10,
	};
	#endregion

	#region Triangles
	int[] triangles = new int[]
	{
		// Bottom
		3, 1, 0,
		3, 2, 1,			

		// Left
		3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
		3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,

		// Front
		3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
		3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,

		// Back
		3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
		3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,

		// Right
		3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
		3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,

		// Top
		3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
		3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,

	};
	#endregion

	mesh.vertices = vertices;
	mesh.normals = normales;
	mesh.uv = uvs;
	mesh.triangles = triangles;

	mesh.RecalculateBounds();
	mesh.Optimize();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
