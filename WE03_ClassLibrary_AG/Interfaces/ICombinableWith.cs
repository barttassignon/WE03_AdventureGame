namespace WE03_ClassLibrary_AG.Interfaces
{
    public interface ICombinableWith<T> where T : IUsable
    {
        string UsedWith(T item);

    }
}
