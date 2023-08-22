using System.Threading;

public class IDGenerator
{
    public static int lastId = 0;

    public int generateId()
    {
        return Interlocked.Increment(ref lastId);
    }

}