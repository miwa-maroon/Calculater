using UniRx;
using UnityEngine;

public class model : MonoBehaviour
{

    public IReadOnlyReactiveProperty<int> Count => _count;

    public readonly int MaxCount = 100;

    private readonly IntReactiveProperty _count = new IntReactiveProperty(0);

    public void SetCount(int value)
    {
        value = Mathf.Clamp(value, 0, MaxCount);
        _count.Value = value;
    }

    private void OnDestroy() {
        _count.Dispose();
    }
    
}
