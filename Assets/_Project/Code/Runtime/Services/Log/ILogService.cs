namespace _Project.Code.Runtime.Services.Log
{
    public interface ILogService
    {
       public void Log(string message);
       public void LogWarning(string message);
       public void LogError(string message);
    }
}