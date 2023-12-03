using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _timeSlowdown;

    public float GetSlowdownValue() => _timeSlowdown;
}
