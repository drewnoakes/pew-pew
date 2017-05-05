using System.Collections.Concurrent;

namespace Sfxr
{
    internal sealed class ObjectPool<T> where T : class, new()
    {
        private readonly int _maxCount;

        private readonly ConcurrentBag<T> _bag = new ConcurrentBag<T>();

        public ObjectPool(int maxCount = 256) => _maxCount = maxCount;

        public T Take() => _bag.TryTake(out var item) ? item : new T();

        public void Release(T item)
        {
            if (_bag.Count < _maxCount)
                _bag.Add(item);
        }
    }
}