using System.Diagnostics;
using System.Threading;

public class Burndown : IBurndown
{
    private bool _shouldContinue;

    public bool ShouldContinue 
    { 
        get 
        {
            return _shouldContinue;
        } 
        set 
        {
            _shouldContinue = value;
        } 
    }

    public Burndown()
    {
        _shouldContinue = true;
    }

    public void CPUKill(object cpuUsage)
    {        
        Stopwatch watch = new Stopwatch();
        watch.Start();
        while (_shouldContinue)
        {
            if (watch.ElapsedMilliseconds > (int)cpuUsage)
            {
                Thread.Sleep(100 - (int)cpuUsage);
                watch.Reset();
                watch.Start();
            }
        }            
    }
}