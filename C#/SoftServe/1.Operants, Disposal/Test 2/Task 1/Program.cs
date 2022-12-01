using System;

namespace Task_1
{
    public abstract class CloseableResource
    {
        public void Close()
        {

        }
    }

    public class DisposePatternImplementer : CloseableResource, IDisposable
    {
        private bool disposed = false;
        new public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Disposing by developer");
                    Close();
                }
                else
                {
                    Console.WriteLine("Disposing by GC");
                    Close();
                }

                disposed = true;
            }
        }
        ~DisposePatternImplementer()
        {
            Dispose(false);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
