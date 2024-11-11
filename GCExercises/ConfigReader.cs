using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCExercises
{
    public class ConfigReader : IDisposable
    {
        private FileStream _stream;
        private StreamReader _reader;
        private Dictionary<string, string> _config;
        private bool _disposed;

        public ConfigReader(string filePath) 
        {
            _stream = new FileStream(filePath,FileMode.OpenOrCreate,FileAccess.Read);
            _reader = new StreamReader(_stream);
            _config = new Dictionary<string, string>();

            while(_reader.Peek() >= 0) 
            {
                string text = _reader.ReadLine();

                string key = text.Substring(0,text.IndexOf('='));
                string value = text.Substring(text.IndexOf("=")+1, (text.Length-key.Length)-1);

                _config.Add(key, value);
            }

            Console.WriteLine("File is open and is read by stream reader");
        }

        public string GetConfigValue(string key) 
        {
            return _config[key];
        }



        public void Dispose()
        {
            Dispose(true);
            
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool value) 
        {
            if (!_disposed) 
            {
                if(value) 
                {
                    _stream?.Dispose();
                    _reader?.Dispose();
                    Console.WriteLine("FileStream and StreamReader is Disposed");
                }

                _disposed = true;
            }
        }

        ~ConfigReader() 
        {
            Dispose(false);
        }
    }
}
