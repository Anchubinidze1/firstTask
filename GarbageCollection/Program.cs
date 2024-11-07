

using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Runtime.InteropServices;

namespace GarbageCollection
{

    public class UnmanagedResourceHolder : IDisposable
    {

        private IntPtr _unmanagedMemory;  // ფოინთერი არა მართვად რესურსზე
        private bool _disposed =  false; // ცვლადი რომ შევამოწმოთ რესულრსები უკვე გათავისუფლდა თუ არ


        public UnmanagedResourceHolder(int size) 
        {
            _unmanagedMemory = Marshal.AllocHGlobal(size);
            Console.WriteLine($"Allocated {size} bytes of unmanaged memory.");
        }


        public void Dispose()
        {
            Dispose(true);    // გამოიძახებს Dispose მეთოდს True პარამეტრით

            GC.SuppressFinalize(this); // დესტრუქტორი რომ აღარ გამოიძახოს რადგან უკვე მოგვარებულია რესურსების თემა
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    
                }

                if(_unmanagedMemory != IntPtr.Zero ) 
                {
                    Marshal.FreeHGlobal(_unmanagedMemory);  // შიგნით არსებული მეთოდი რომელიც გაათავისუფლებს ამ რესურს
                    _unmanagedMemory = IntPtr.Zero;
                    Console.WriteLine("Unmanaged memory freed.");
                }

                _disposed = true;
            }
        }


        ~UnmanagedResourceHolder()
        {
            Dispose(false); 
        }

        public void UseUnmanagedResource()
        {
            if (_disposed)
                throw new ObjectDisposedException("UnmanagedResourceHolder");

            
            Marshal.WriteByte(_unmanagedMemory, 0, 42);
            Console.WriteLine("Wrote to unmanaged memory.");
        }

    }

    public class SampleResource : IDisposable
    {

        private FileStream _stream;     // მართვადი რესურსი , მართვადი რატომაა მერე ავხსი
        private bool _disposed =  false; // ცვლადი რომ შევამოწმოთ რესულრსები უკვე გათავისუფლდა თუ არა
        public void Dispose()
        {
            Dispose(true);    // გამოიძახებს Dispose მეთოდს True პარამეტრით

            GC.SuppressFinalize(this); // დესტრუქტორი რომ აღარ გამოიძახოს რადგან უკვე მოგვარებულია რესურსების თემა
        }

        public SampleResource(string filepath)  // მეთოდი რომელიც შექმნის ან გამოიძახებს ფაილს
        {
            _stream = new FileStream(filepath, FileMode.OpenOrCreate);
            Console.WriteLine("File opened");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _stream?.Dispose();
                    Console.WriteLine("Managed resources disposed.");
                }

                

                _disposed = true;
            }
        }

        public void WriteToFile(string text)  // ფაილში ჩაწერის ლოგიკა
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("SampleResource");
            }

            byte[] data = System.Text.Encoding.UTF8.GetBytes(text);
            _stream.Write(data, 0, data.Length);
            Console.WriteLine("Data written to file");

        }

        ~SampleResource()
        {
            Dispose(false); // გამოიძახებს GC თუ dispose() მეთოდი არ იქნა გამოძახებული თავის დაზღვევის საშვალებაა        
        }


       

    }


    public class MyResorce : IDisposable
    {
        private bool _disposed = false;  // ცვლადი რომ შევამოწმოთ რესულრსები უკვე გათავისუფლდა თუ არა

        public void Dispose()
        {
            Dispose(true);    // გამოიძახებს Dispose მეთოდს True პარამეტრით

            GC.SuppressFinalize(this); // დესტრუქტორი რომ აღარ გამოიძახოს რადგან უკვე მოგვარებულია რესურსების თემა
        }


        protected virtual void Dispose(bool disposing) 
        {
            if (!_disposed) 
            {
                if (disposing) 
                {
                         // ლოგიკა რომელიც მოუვლის მართვად რესურსებს
                }            

                //ლოგიკა რომელიც მოუვლის არა მართვად რესურსებს

                _disposed = true;
            }
        }

        ~MyResorce() 
        {
            Dispose(false); // გამოიძახებს GC თუ dispose() მეთოდი არ იქნა გამოძახებული თავის დაზღვევის საშვალებაა        
        }
    }

    class Program
    {

        public static void Main(string[] args) 
        {
            /*
            SampleResource resource = new SampleResource("Test1");
            resource.WriteToFile("Helloo");
            resource.Dispose();
            */

            UnmanagedResourceHolder unmanagedResourceHolder = new UnmanagedResourceHolder(23);

            unmanagedResourceHolder.UseUnmanagedResource();

            unmanagedResourceHolder.Dispose();


        }
    }
}