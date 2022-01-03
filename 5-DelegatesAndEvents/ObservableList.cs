namespace DelegatesAndEvents
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <inheritdoc cref="IObservableList{T}" />
    public class ObservableList<TItem> : IObservableList<TItem>
    {
        private readonly IList<TItem> _items = new List<TItem>();
        /// <inheritdoc cref="IObservableList{T}.ElementInserted" />
        public event ListChangeCallback<TItem> ElementInserted;

        /// <inheritdoc cref="IObservableList{T}.ElementRemoved" />
        public event ListChangeCallback<TItem> ElementRemoved;

        /// <inheritdoc cref="IObservableList{T}.ElementChanged" />
        public event ListElementChangeCallback<TItem> ElementChanged;

        /// <inheritdoc cref="ICollection{T}.Count" />
        public int Count => _items.Count;

        /// <inheritdoc cref="ICollection{T}.IsReadOnly" />
        public bool IsReadOnly => _items.IsReadOnly;

        /// <inheritdoc cref="IList{T}.this" />
        public TItem this[int index]
        {
            get => _items[index];
            set
            {
                TItem temp = _items[index];
                _items[index] = value;
                ElementChanged?.Invoke(this, value, temp, index);
            }
        }

        /// <inheritdoc cref="IEnumerable{T}.GetEnumerator" />
        public IEnumerator<TItem> GetEnumerator() => _items.GetEnumerator();

        /// <inheritdoc cref="IEnumerable.GetEnumerator" />
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        /// <inheritdoc cref="ICollection{T}.Add" />
        public void Add(TItem item)
        {
            _items.Add(item);
            ElementInserted?.Invoke(this, item, _items.Count-1);
        }

        /// <inheritdoc cref="ICollection{T}.Clear" />
        public void Clear()
        {
            List<TItem> temp = new List<TItem>(_items);
            _items.Clear();
            int count = 0;
            foreach (var item in temp)
            {
                ElementRemoved?.Invoke(this, item, count++);
            }
        }

        /// <inheritdoc cref="ICollection{T}.Contains" />
        public bool Contains(TItem item) => _items.Contains(item);

        /// <inheritdoc cref="ICollection{T}.CopyTo" />
        public void CopyTo(TItem[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < _items.Count; i++)
            {
                array[i] = _items[i];
            }
        }

        /// <inheritdoc cref="ICollection{T}.Remove" />
        public bool Remove(TItem item)
        {
            if (_items.Contains(item))
            {
                int ind = _items.IndexOf(item);
                bool res = _items.Remove(item);
                if (res)
                {
                    ElementRemoved?.Invoke(this, item, ind);
                }
                return res;
            }
            return false;
        }

        /// <inheritdoc cref="IList{T}.IndexOf" />
        public int IndexOf(TItem item) => _items.IndexOf(item);

        /// <inheritdoc cref="IList{T}.RemoveAt" />
        public void Insert(int index, TItem item)
        {
            _items.Insert(index, item);
            ElementInserted?.Invoke(this, item, index);
        }

        /// <inheritdoc cref="IList{T}.RemoveAt" />
        public void RemoveAt(int index)
        {
            TItem temp = _items[index];
            _items.RemoveAt(index);
            ElementRemoved?.Invoke(this, temp, index);
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            if (obj is ObservableList<TItem> objList)
            {
                return this.Equals(objList);
            }
            return false;
        }

        /// <inheritdoc cref="object.GetHashCode" />
        public override int GetHashCode() => this._items.GetHashCode();

        /// <inheritdoc cref="object.ToString" />
        public override string ToString() => Environment.NewLine + string.Join(Environment.NewLine, this._items) + Environment.NewLine;
    }
}
