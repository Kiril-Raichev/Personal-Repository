namespace StackQueueWorkshop.Queue
{
    public interface IQueue<T>
    {
        int Size { get; }

        bool IsEmpty { get; }

        void Enqueue(T element);

        T Dequeue();

        T Peek();
    }
}
