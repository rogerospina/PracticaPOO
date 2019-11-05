using System;

namespace PracticaPOO
{
    public interface ILog
    {
        void Log(string mensaje);
        void LogException(Exception ex);
    }
}