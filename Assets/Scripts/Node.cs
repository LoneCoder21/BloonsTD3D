using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
	public Color hoverColor;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]

	private Renderer renderer;
	private Color startColor;

	BuildManager buildManager;

	void Start()
	{
		renderer = GetComponent<Renderer>();
		startColor = renderer.material.color;

		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition()
	{
		Vector3 center = renderer.bounds.center;
		Vector3 extents = renderer.bounds.extents;
		Vector3 bottomCenter = new Vector3(center.x, center.y + extents.y, center.z);
		return bottomCenter;
	}

	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (turret != null || buildManager.selectedTower == null)
		{
			return;
		}
		//placing turret here
		turret = (GameObject)Instantiate(buildManager.selectedTower, GetBuildPosition(), transform.rotation);
	}

	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		renderer.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		renderer.material.color = startColor;
	}
}