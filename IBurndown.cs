public interface IBurndown
{
    public bool ShouldContinue { get; set; }
    public void CPUKill(object cpuUsage);
}