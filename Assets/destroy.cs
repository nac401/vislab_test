using UnityEngine;

public class destroy : MonoBehaviour
{
    public float time_to_death = 2;
    private float death_timer = 0;
    void FixedUpdate()
    {
        death_timer += Time.deltaTime;
        if (death_timer > time_to_death )
        {
            Destroy(this);
        }
    }
}
