using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCExercises
{
    public class UserSettings : IDisposable
    {
        private FileStream _stream;
        private StreamReader _reader;
        private StreamWriter _writer;
        private Dictionary<string, string> _settings;

        private bool _disposed = false;

        public UserSettings(string filePath) 
        {
            _stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            _reader = new StreamReader(_stream);
            _writer = new StreamWriter(_stream);
            _settings = new Dictionary<string, string>();

            SplitingLineLogic();

            Console.WriteLine("File is opened and is already read by StreamReader");

        }

        protected void SplitingLineLogic() 
        {
            while (_reader.Peek() >= 0)
            {
                string text = _reader.ReadLine();

                if (text.Contains('='))
                {
                    string[] spliting = text.Split('=', 2);

                    if (spliting.Length == 2)
                    {
                        string key = spliting[0].Trim();
                        string value = spliting[1].Trim();

                        _settings.Add(key, value);

                    }
                }
            }
        }

        public string GetSettingValue(string key) 
        {
            return _settings[key];
        }

        public void WriteSetting(string setting) 
        {

            _writer.WriteLine(setting);
            

        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool isDisposed) 
        {
            if(!_disposed) 
            {
                if (isDisposed) 
                {
                    _reader?.Dispose();
                    _writer?.Dispose();
                    _stream?.Dispose();
                    Console.WriteLine("Stream Writer , Stream Reader and FileStream are disposed");

                }

                _disposed = true;
            }
        }

        ~UserSettings() 
        {
            Dispose(false);
        }
    }
}
