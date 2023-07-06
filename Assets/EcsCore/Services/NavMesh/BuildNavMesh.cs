using NavMeshPlus.Components;
using System.Collections;
using UnityEngine;

public class BuildNavMesh : MonoBehaviour
{
	[SerializeField] private NavMeshSurface Surface2D;

	public void Build()
	{
		AsyncOperation asyncLoad = Surface2D.BuildNavMeshAsync();
	}
}