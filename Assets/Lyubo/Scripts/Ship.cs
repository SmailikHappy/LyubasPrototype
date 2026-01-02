using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    private float m_speed = 0.5f;

    void OnCollisionEnter(Collision other_collider)
    {
        Debug.Log("Ship collided with: " + other_collider.gameObject.name, other_collider.gameObject);

        if (other_collider.transform.TryGetComponent<WeaponScript>(out WeaponScript weapon))
        {
            if (weapon.IsBroken) return;
            weapon.Break();
            Destroy(this.gameObject);
        }

        if (other_collider.transform.parent == null) return;

        if (other_collider.transform.parent.TryGetComponent<Base>(
            out Base baseComponent))
        {
            baseComponent.TakeDamage(1);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        Vector3 targetPosition = GameHandler.Instance.Base.transform.position;
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * m_speed * Time.deltaTime;
    }
}
