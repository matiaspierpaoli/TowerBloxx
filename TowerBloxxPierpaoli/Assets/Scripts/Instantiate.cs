using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Instantiate : MonoBehaviour
{
    [SerializeField] private float lineWidth = .25f;
    [SerializeField] private Rigidbody pivot;
    [SerializeField] private Rigidbody holder;
    [SerializeField] private float countDownIntancer = 1;
    [SerializeField] private Rigidbody[] platforms;
    [SerializeField] private Vector3 pivotOffset = 5 * Vector3.up;
    [SerializeField] private float rePositionDuration = 1;

    private Rigidbody platformBody;
    private LineRenderer line;
    private float lastInstance = 0;
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;

        transform.position = pivotOffset;
    }

    private void LateUpdate()
    {
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;

        line.SetPosition(0, pivot.position);
        line.SetPosition(1, holder.position);

        InstancePlatform();
    }

    public void DetachBuilding()
    {
        if (platformBody != null)
        {
            platformBody.isKinematic = false;
            platformBody.constraints = RigidbodyConstraints.None;
            platformBody.transform.SetParent(null);
            platformBody = null;
            lastInstance = Time.time;
        }
    }

    private void InstancePlatform()
    {
        Random.InitState((int)Time.time);

        if (!platformBody && (Time.time - lastInstance) > countDownIntancer)
        {
            platformBody = Instantiate<Rigidbody>(platforms[Random.Range(0, platforms.Length)], holder.transform, true);
            platformBody.isKinematic = true;
            platformBody.transform.localPosition = Vector3.down;
        }
    }

    public void UpdatePivotPosition(Vector3 pos)
    {
        pos.x = 0;
        pos.z = 0;

        UpdatePositionTask(rePositionDuration, pos + pivotOffset);
    }

    private async void UpdatePositionTask(float duration, Vector3 endValue)
    {
        float time = 0;
        Vector3 startValue = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            await Task.Yield();
        }
        transform.position = endValue;
    }
}
