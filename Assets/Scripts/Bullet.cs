using UnityEngine;

public class Bullet : MonoBehaviour {
	private Transform target;

	public float speed = 10f;
	public int damage = 50;

	public void Seek(Transform _target)
	{
		target = _target;
	}

	void Update() {
		print(speed);
		print(damage);
		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);
		transform.Rotate(0, -90, 0);
	}

	void HitTarget()
	{
		Damage(target);	
		Destroy(gameObject);
	}

	void Damage(Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();

		if (e != null)
		{
			e.TakeDamage(damage);
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
	}
}
