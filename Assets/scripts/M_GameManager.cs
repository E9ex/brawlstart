using UnityEngine;
using UnityEngine.Events;

public class M_GameManager : Singleton<M_GameManager>
{
    public UnityAction onLevelStart;
    public UnityAction onLevelEnd;


    [ContextMenu("START")]
    public void LevelStart()
    {
        onLevelStart?.Invoke();
    }

    [ContextMenu("END")]
    public void LevelEnd()
    {
        onLevelEnd?.Invoke();
    }
}
