namespace StackQueueWorkshop.Stack
{
    public interface IStack<T>
    {
        int Size { get; }

        bool IsEmpty { get; }

        void Push(T element);

        T Pop();

        T Peek();
    }
}
