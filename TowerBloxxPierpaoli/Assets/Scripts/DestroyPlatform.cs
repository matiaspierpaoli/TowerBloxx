using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    [SerializeField] private string tagID;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagID))
        {
            Destroy(collision.gameObject);
        }
    }
}
