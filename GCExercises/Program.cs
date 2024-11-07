

using System;
using System.IO;
using System.Timers;
using Timer = System.Timers.Timer;

namespace GCExercises 
{

    public class TimedLogWriter : IDisposable
    {
        private StreamWriter _writer;
        private Timer _timer;
        private bool _disposed = false;

        public TimedLogWriter(string filePath, double intervalSeconds) 
        {
            _writer = new StreamWriter(filePath, append: true);
            _timer = new Timer(intervalSeconds * 1000);
            _timer.Elapsed += OnTimedEvent;
            _timer.Start();
        }

        public void WriteLog(string message)
        {
            if (_disposed)
                throw new ObjectDisposedException("TimedLogWriter");

            _writer.WriteLine($"{DateTime.Now}: {message}");
            _writer.Flush();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            WriteLog("Auto-log entry");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _timer?.Stop();
                    _timer?.Dispose();
                    _writer?.Dispose();
                    Console.WriteLine("Resources were released.");
                }
                _disposed = true;
            }
        }

        ~TimedLogWriter()
        {
            Dispose(false);
        }
    }

    public class LogWrite : IDisposable
    {
        private FileStream _stream;
        private bool _disposed =  false;

        public LogWrite(string filePath) 
        {
            _stream = new FileStream(filePath , FileMode.OpenOrCreate);
            Console.WriteLine("File was created");
        }

        public void WriteLog(string message) 
        {
            if (_disposed)
                throw new ObjectDisposedException("UnmanagedResourceHolder");

            byte[] data = System.Text.Encoding.UTF8.GetBytes(message+"  "+DateTime.Now);
            _stream.Write(data, 0, data.Length);
            Console.WriteLine("Data written to file");
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
                if(disposing) 
                {
                    _stream?.Dispose();
                    Console.WriteLine("Memory was released");
                }

                _disposed = true;
            }
        }

        ~LogWrite() 
        {
            Dispose(false);
        }
    }
    class Program 
    {
        public static void Main(string[] args)
        {
            using (var logWriter = new LogWrite("log.txt"))
            {
                logWriter.WriteLog("This is the first log entry.");
                logWriter.WriteLog("This is the second log entry.");
            }

            Console.WriteLine("Log entries written and file closed.");
        }
    }
}