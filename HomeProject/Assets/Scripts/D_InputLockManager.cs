// InputLockManager.cs
using UnityEngine;

public static class D_InputLockManager
{
    private static int lockCount;
    private static int timerlockCount;

    public static bool IsLocked => lockCount > 0;
    public static bool IstimerLocked => timerlockCount > 0;

    public static void Lock()
    {
        lockCount++;
    }

    public static void Unlock()
    {
        lockCount = Mathf.Max(0, lockCount - 1);
    }

    public static void Ltimerock()
    {
        timerlockCount++;
    }

    public static void timerUnlock()
    {
        lockCount = Mathf.Max(0, timerlockCount - 1);
    }
}