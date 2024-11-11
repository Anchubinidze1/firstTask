using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCExercises
{
    public class FileLogger : IDisposable
    {
        private FileStream _stream;
        private StreamWriter _writer;
        private bool _disposed = false;

        public FileLogger(string url) 
        {
            _stream = new FileStream(url,FileMode.OpenOrCreate,FileAccess.Write);
            _writer = new StreamWriter(_stream);
            Console.WriteLine("File Opened for logging");
        }

        public void LogMessage(string message) 
        {
            if (_disposed) 
            {
                throw new ObjectDisposedException("FileLogger");
            }

            string text = message + " :"+ DateTime.Now;
            _writer.WriteLine(text);
            Console.WriteLine("Log entry written to file");
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) 
        {
            if(!_disposed) 
            {
                if (disposing) 
                {
                    _writer?.Dispose();
                    _stream?.Dispose();
                    Console.WriteLine("File Resources released");
                }

                _disposed = true;
            }
        }

        ~FileLogger() 
        {
            Dispose(false);
        }
    }
}
