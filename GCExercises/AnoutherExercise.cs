using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCExercises
{
    public class AnoutherExercise : IDisposable
    {
        private bool _isDisposed = false;
        private bool _isConnected = false;

        public void Connect() 
        {
            if(_isConnected) 
            {
                throw new ObjectDisposedException("DatabaseConnection");
            }
            _isConnected = true;
            Console.WriteLine("Connected");
        }


        public void Disconnect() 
        {
            if(_isConnected) 
            {
                throw new ObjectDisposedException("DatabaseConnection");
            }
            _isConnected = false;
            Console.WriteLine("Disconected");
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing) 
        {
            if (!_isDisposed) 
            {
                if(disposing) 
                {
                    Console.WriteLine("Disposed of managed resources");
                }

                if(_isConnected) 
                {
                    _isDisposed = false;
                    Console.WriteLine("Disconecting from database");
                }

                _isDisposed = true;
            }
        }

        ~AnoutherExercise() 
        {
            Dispose(false);
        }
    }
}
