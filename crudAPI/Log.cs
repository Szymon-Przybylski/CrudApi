using System;

namespace crudAPI
{

    public interface ILog
    {
        void Info(string s);
    }
    
    public class Log : ILog
    {
        public void Info(string s)
        {
            Console.WriteLine(s);
        }
    }
}