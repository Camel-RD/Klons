using System;
using System.Reflection;
using System.ComponentModel;
using System.Linq;
using Validation;
namespace System.Collections.Generic
{
    /*
    public interface IReadOnlyCollection<out T> : IEnumerable<T>, IEnumerable
    {
        int Count { get; }
    }

    //[DefaultMember("Item")]
    public interface IReadOnlyDictionary<TKey, TValue> : IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
    {
        TValue this[TKey key] { get; }
        IEnumerable<TKey> Keys { get; }
        IEnumerable<TValue> Values { get; }
        bool ContainsKey(TKey key);
        bool TryGetValue(TKey key, out TValue value);
    }
	*/
	
    public class MultiValueDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>>, IReadOnlyCollection<KeyValuePair<TKey, IReadOnlyCollection<TValue>>>, IEnumerable<KeyValuePair<TKey, IReadOnlyCollection<TValue>>>, IEnumerable
	{

        private class Enumerator : IEnumerator<KeyValuePair<TKey, IReadOnlyCollection<TValue>>>, IEnumerator, IDisposable
		{
			private enum EnumerationState
			{
				BeforeFirst,
				During,
				AfterLast
			}
			private MultiValueDictionary<TKey, TValue> multiValueDictionary;
			private int version;
			private KeyValuePair<TKey, IReadOnlyCollection<TValue>> current;
			private Dictionary<TKey, MultiValueDictionary<TKey, TValue>.InnerCollectionView>.Enumerator enumerator;
			private MultiValueDictionary<TKey, TValue>.Enumerator.EnumerationState state;
			public KeyValuePair<TKey, IReadOnlyCollection<TValue>> Current
			{
				get
				{
					return this.current;
				}
			}
			object IEnumerator.Current
			{
				get
				{
					switch (this.state)
					{
					case MultiValueDictionary<TKey, TValue>.Enumerator.EnumerationState.BeforeFirst:
						throw new InvalidOperationException(SR.GetString(Exceptions.Enumerator_BeforeCurrent));
					case MultiValueDictionary<TKey, TValue>.Enumerator.EnumerationState.AfterLast:
						throw new InvalidOperationException(SR.GetString(Exceptions.Enumerator_AfterCurrent));
					}
					return this.current;
				}
			}
			internal Enumerator(MultiValueDictionary<TKey, TValue> multiValueDictionary)
			{
				this.multiValueDictionary = multiValueDictionary;
				this.version = multiValueDictionary.version;
				this.current = default(KeyValuePair<TKey, IReadOnlyCollection<TValue>>);
				this.enumerator = multiValueDictionary.dictionary.GetEnumerator();
				this.state = MultiValueDictionary<TKey, TValue>.Enumerator.EnumerationState.BeforeFirst;
			}
			public bool MoveNext()
			{
				if (this.version != this.multiValueDictionary.version)
				{
					throw new InvalidOperationException(SR.GetString(Exceptions.Enumerator_Modification));
				}
				if (this.enumerator.MoveNext())
				{
					KeyValuePair<TKey, MultiValueDictionary<TKey, TValue>.InnerCollectionView> keyValuePair = this.enumerator.Current;
					TKey arg_57_0 = keyValuePair.Key;
					KeyValuePair<TKey, MultiValueDictionary<TKey, TValue>.InnerCollectionView> keyValuePair2 = this.enumerator.Current;
					this.current = new KeyValuePair<TKey, IReadOnlyCollection<TValue>>(arg_57_0, keyValuePair2.Value);
					this.state = MultiValueDictionary<TKey, TValue>.Enumerator.EnumerationState.During;
					return true;
				}
				this.current = default(KeyValuePair<TKey, IReadOnlyCollection<TValue>>);
				this.state = MultiValueDictionary<TKey, TValue>.Enumerator.EnumerationState.AfterLast;
				return false;
			}
			public void Reset()
			{
				if (this.version != this.multiValueDictionary.version)
				{
					throw new InvalidOperationException(SR.GetString(Exceptions.Enumerator_Modification));
				}
				this.enumerator.Dispose();
				this.enumerator = this.multiValueDictionary.dictionary.GetEnumerator();
				this.current = default(KeyValuePair<TKey, IReadOnlyCollection<TValue>>);
				this.state = MultiValueDictionary<TKey, TValue>.Enumerator.EnumerationState.BeforeFirst;
			}
			public void Dispose()
			{
				this.enumerator.Dispose();
			}
		}
		private class InnerCollectionView : ICollection<TValue>, IReadOnlyCollection<TValue>, IGrouping<TKey, TValue>, IEnumerable<TValue>, IEnumerable
		{
			private TKey key;
			private ICollection<TValue> collection;
			public int Count
			{
				get
				{
					return this.collection.Count;
				}
			}
			public bool IsReadOnly
			{
				get
				{
					return true;
				}
			}
			public TKey Key
			{
				get
				{
					return this.key;
				}
			}
			public InnerCollectionView(TKey key, ICollection<TValue> collection)
			{
				this.key = key;
				this.collection = collection;
			}
			public void AddValue(TValue item)
			{
				this.collection.Add(item);
			}
			public bool RemoveValue(TValue item)
			{
				return this.collection.Remove(item);
			}
			public bool Contains(TValue item)
			{
				return this.collection.Contains(item);
			}
			public void CopyTo(TValue[] array, int arrayIndex)
			{
				Requires.NotNullAllowStructs<TValue[]>(array, "array");
				Requires.Range(arrayIndex >= 0, "arrayIndex", null);
				Requires.Range(arrayIndex <= array.Length, "arrayIndex", null);
				Requires.Argument(array.Length - arrayIndex >= this.collection.Count, "arrayIndex", SR.GetString(Exceptions.CopyTo_ArgumentsTooSmall));
				this.collection.CopyTo(array, arrayIndex);
			}
			public IEnumerator<TValue> GetEnumerator()
			{
				return this.collection.GetEnumerator();
			}
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}
			void ICollection<TValue>.Add(TValue item)
			{
				throw new NotSupportedException(SR.GetString(Exceptions.ReadOnly_Modification));
			}
			void ICollection<TValue>.Clear()
			{
				throw new NotSupportedException(SR.GetString(Exceptions.ReadOnly_Modification));
			}
			bool ICollection<TValue>.Remove(TValue item)
			{
				throw new NotSupportedException(SR.GetString(Exceptions.ReadOnly_Modification));
			}
		}
		private class MultiLookup : ILookup<TKey, TValue>, IEnumerable<IGrouping<TKey, TValue>>, IEnumerable
		{
			private class Enumerator : IEnumerator<IGrouping<TKey, TValue>>, IEnumerator, IDisposable
			{
				private enum EnumerationState
				{
					BeforeFirst,
					During,
					AfterLast
				}
				private MultiValueDictionary<TKey, TValue> multiValueDictionary;
				private IGrouping<TKey, TValue> current;
				private int version;
				private IEnumerator<KeyValuePair<TKey, MultiValueDictionary<TKey, TValue>.InnerCollectionView>> enumerator;
				private MultiValueDictionary<TKey, TValue>.MultiLookup.Enumerator.EnumerationState state;
				IGrouping<TKey, TValue> IEnumerator<IGrouping<TKey, TValue>>.Current
				{
					get
					{
						return this.current;
					}
				}
				object IEnumerator.Current
				{
					get
					{
						switch (this.state)
						{
						case MultiValueDictionary<TKey, TValue>.MultiLookup.Enumerator.EnumerationState.BeforeFirst:
							throw new InvalidOperationException(SR.GetString(Exceptions.Enumerator_BeforeCurrent));
						case MultiValueDictionary<TKey, TValue>.MultiLookup.Enumerator.EnumerationState.AfterLast:
							throw new InvalidOperationException(SR.GetString(Exceptions.Enumerator_AfterCurrent));
						}
						return this.current;
					}
				}
				internal Enumerator(MultiValueDictionary<TKey, TValue> multiValueDictionary)
				{
					this.multiValueDictionary = multiValueDictionary;
					this.enumerator = multiValueDictionary.dictionary.GetEnumerator();
					this.version = multiValueDictionary.version;
					KeyValuePair<TKey, MultiValueDictionary<TKey, TValue>.InnerCollectionView> keyValuePair = this.enumerator.Current;
					this.current = keyValuePair.Value;
					this.state = MultiValueDictionary<TKey, TValue>.MultiLookup.Enumerator.EnumerationState.BeforeFirst;
				}
				public bool MoveNext()
				{
					if (this.version != this.multiValueDictionary.version)
					{
						throw new InvalidOperationException(SR.GetString(Exceptions.Enumerator_Modification));
					}
					if (this.enumerator.MoveNext())
					{
						KeyValuePair<TKey, MultiValueDictionary<TKey, TValue>.InnerCollectionView> keyValuePair = this.enumerator.Current;
						this.current = keyValuePair.Value;
						this.state = MultiValueDictionary<TKey, TValue>.MultiLookup.Enumerator.EnumerationState.During;
						return true;
					}
					this.state = MultiValueDictionary<TKey, TValue>.MultiLookup.Enumerator.EnumerationState.AfterLast;
					return false;
				}
				public void Reset()
				{
					if (this.version != this.multiValueDictionary.version)
					{
						throw new InvalidOperationException(SR.GetString(Exceptions.Enumerator_Modification));
					}
					this.state = MultiValueDictionary<TKey, TValue>.MultiLookup.Enumerator.EnumerationState.BeforeFirst;
					this.enumerator.Reset();
					KeyValuePair<TKey, MultiValueDictionary<TKey, TValue>.InnerCollectionView> keyValuePair = this.enumerator.Current;
					this.current = keyValuePair.Value;
				}
				public void Dispose()
				{
					this.enumerator.Dispose();
				}
			}
			private readonly MultiValueDictionary<TKey, TValue> multiValueDictionary;
			public int Count
			{
				get
				{
					return this.multiValueDictionary.dictionary.Count;
				}
			}
			public IEnumerable<TValue> this[TKey key]
			{
				get
				{
					MultiValueDictionary<TKey, TValue>.InnerCollectionView result;
					if (this.multiValueDictionary.dictionary.TryGetValue(key, out result))
					{
						return result;
					}
					return Enumerable.Empty<TValue>();
				}
			}
			internal MultiLookup(MultiValueDictionary<TKey, TValue> multiValueDictionary)
			{
				this.multiValueDictionary = multiValueDictionary;
			}
			public bool Contains(TKey key)
			{
				Requires.NotNullAllowStructs<TKey>(key, "key");
				return this.multiValueDictionary.dictionary.ContainsKey(key);
			}
			public IEnumerator<IGrouping<TKey, TValue>> GetEnumerator()
			{
				return new MultiValueDictionary<TKey, TValue>.MultiLookup.Enumerator(this.multiValueDictionary);
			}
			IEnumerator IEnumerable.GetEnumerator()
			{
				return new MultiValueDictionary<TKey, TValue>.MultiLookup.Enumerator(this.multiValueDictionary);
			}
		}
		private Dictionary<TKey, MultiValueDictionary<TKey, TValue>.InnerCollectionView> dictionary;
		private Func<ICollection<TValue>> NewCollectionFactory = () => new List<TValue>();
		private int version;
		public IEnumerable<TKey> Keys
		{
			get
			{
				return this.dictionary.Keys;
			}
		}
		public IEnumerable<IReadOnlyCollection<TValue>> Values
		{
			get
			{
				return this.dictionary.Values;
			}
		}
		public IReadOnlyCollection<TValue> this[TKey key]
		{
			get
			{
				Requires.NotNullAllowStructs<TKey>(key, "key");
				MultiValueDictionary<TKey, TValue>.InnerCollectionView result;
				if (this.dictionary.TryGetValue(key, out result))
				{
					return result;
				}
				throw new KeyNotFoundException(SR.GetString(Exceptions.KeyNotFound));
			}
		}
		public int Count
		{
			get
			{
				return this.dictionary.Count;
			}
		}
		public MultiValueDictionary()
		{
			this.dictionary = new Dictionary<TKey, MultiValueDictionary<TKey, TValue>.InnerCollectionView>();
		}
		public MultiValueDictionary(int capacity)
		{
			Requires.Range(capacity >= 0, "capacity", null);
			this.dictionary = new Dictionary<TKey, MultiValueDictionary<TKey, TValue>.InnerCollectionView>(capacity);
		}
		public MultiValueDictionary(IEqualityComparer<TKey> comparer)
		{
			this.dictionary = new Dictionary<TKey, MultiValueDictionary<TKey, TValue>.InnerCollectionView>(comparer);
		}
		public MultiValueDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
			Requires.Range(capacity >= 0, "capacity", null);
			this.dictionary = new Dictionary<TKey, MultiValueDictionary<TKey, TValue>.InnerCollectionView>(capacity, comparer);
		}
		public MultiValueDictionary(IEnumerable<KeyValuePair<TKey, IReadOnlyCollection<TValue>>> enumerable) : this(enumerable, null)
		{
		}
		public MultiValueDictionary(IEnumerable<KeyValuePair<TKey, IReadOnlyCollection<TValue>>> enumerable, IEqualityComparer<TKey> comparer)
		{
			Requires.NotNullAllowStructs<IEnumerable<KeyValuePair<TKey, IReadOnlyCollection<TValue>>>>(enumerable, "enumerable");
			this.dictionary = new Dictionary<TKey, MultiValueDictionary<TKey, TValue>.InnerCollectionView>(comparer);
			foreach (KeyValuePair<TKey, IReadOnlyCollection<TValue>> current in enumerable)
			{
				this.AddRange(current.Key, current.Value);
			}
		}
		public MultiValueDictionary(IEnumerable<IGrouping<TKey, TValue>> enumerable) : this(enumerable, null)
		{
		}
		public MultiValueDictionary(IEnumerable<IGrouping<TKey, TValue>> enumerable, IEqualityComparer<TKey> comparer)
		{
			Requires.NotNullAllowStructs<IEnumerable<IGrouping<TKey, TValue>>>(enumerable, "enumerable");
			this.dictionary = new Dictionary<TKey, MultiValueDictionary<TKey, TValue>.InnerCollectionView>(comparer);
			foreach (IGrouping<TKey, TValue> current in enumerable)
			{
				this.AddRange(current.Key, current);
			}
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>() where TValueCollection : ICollection<TValue>, new()
		{
			TValueCollection tValueCollection = (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection);
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			return new MultiValueDictionary<TKey, TValue>
			{
				NewCollectionFactory = () => (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection)
			};
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(int capacity) where TValueCollection : ICollection<TValue>, new()
		{
			Requires.Range(capacity >= 0, "capacity", null);
			TValueCollection tValueCollection = (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection);
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			return new MultiValueDictionary<TKey, TValue>(capacity)
			{
				NewCollectionFactory = () => (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection)
			};
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEqualityComparer<TKey> comparer) where TValueCollection : ICollection<TValue>, new()
		{
			TValueCollection tValueCollection = (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection);
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			return new MultiValueDictionary<TKey, TValue>(comparer)
			{
				NewCollectionFactory = () => (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection)
			};
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(int capacity, IEqualityComparer<TKey> comparer) where TValueCollection : ICollection<TValue>, new()
		{
			Requires.Range(capacity >= 0, "capacity", null);
			TValueCollection tValueCollection = (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection);
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			return new MultiValueDictionary<TKey, TValue>(capacity, comparer)
			{
				NewCollectionFactory = () => (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection)
			};
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEnumerable<KeyValuePair<TKey, IReadOnlyCollection<TValue>>> enumerable) where TValueCollection : ICollection<TValue>, new()
		{
			Requires.NotNullAllowStructs<IEnumerable<KeyValuePair<TKey, IReadOnlyCollection<TValue>>>>(enumerable, "enumerable");
			TValueCollection tValueCollection = (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection);
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			MultiValueDictionary<TKey, TValue> multiValueDictionary = new MultiValueDictionary<TKey, TValue>();
			multiValueDictionary.NewCollectionFactory = (() => (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection));
			foreach (KeyValuePair<TKey, IReadOnlyCollection<TValue>> current in enumerable)
			{
				multiValueDictionary.AddRange(current.Key, current.Value);
			}
			return multiValueDictionary;
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEnumerable<KeyValuePair<TKey, IReadOnlyCollection<TValue>>> enumerable, IEqualityComparer<TKey> comparer) where TValueCollection : ICollection<TValue>, new()
		{
			Requires.NotNullAllowStructs<IEnumerable<KeyValuePair<TKey, IReadOnlyCollection<TValue>>>>(enumerable, "enumerable");
			TValueCollection tValueCollection = (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection);
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			MultiValueDictionary<TKey, TValue> multiValueDictionary = new MultiValueDictionary<TKey, TValue>(comparer);
			multiValueDictionary.NewCollectionFactory = (() => (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection));
			foreach (KeyValuePair<TKey, IReadOnlyCollection<TValue>> current in enumerable)
			{
				multiValueDictionary.AddRange(current.Key, current.Value);
			}
			return multiValueDictionary;
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEnumerable<IGrouping<TKey, TValue>> enumerable) where TValueCollection : ICollection<TValue>, new()
		{
			Requires.NotNullAllowStructs<IEnumerable<IGrouping<TKey, TValue>>>(enumerable, "enumerable");
			TValueCollection tValueCollection = (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection);
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			MultiValueDictionary<TKey, TValue> multiValueDictionary = new MultiValueDictionary<TKey, TValue>();
			multiValueDictionary.NewCollectionFactory = (() => (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection));
			foreach (IGrouping<TKey, TValue> current in enumerable)
			{
				multiValueDictionary.AddRange(current.Key, current);
			}
			return multiValueDictionary;
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEnumerable<IGrouping<TKey, TValue>> enumerable, IEqualityComparer<TKey> comparer) where TValueCollection : ICollection<TValue>, new()
		{
			Requires.NotNullAllowStructs<IEnumerable<IGrouping<TKey, TValue>>>(enumerable, "enumerable");
			TValueCollection tValueCollection = (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection);
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			MultiValueDictionary<TKey, TValue> multiValueDictionary = new MultiValueDictionary<TKey, TValue>(comparer);
			multiValueDictionary.NewCollectionFactory = (() => (default(TValueCollection) == null) ? Activator.CreateInstance<TValueCollection>() : default(TValueCollection));
			foreach (IGrouping<TKey, TValue> current in enumerable)
			{
				multiValueDictionary.AddRange(current.Key, current);
			}
			return multiValueDictionary;
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(Func<TValueCollection> collectionFactory) where TValueCollection : ICollection<TValue>
		{
			TValueCollection tValueCollection = collectionFactory();
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
            return new MultiValueDictionary<TKey, TValue>
            {
                NewCollectionFactory = (Func<ICollection<TValue>>)(object)collectionFactory
            };
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(int capacity, Func<TValueCollection> collectionFactory) where TValueCollection : ICollection<TValue>
		{
			Requires.Range(capacity >= 0, "capacity", null);
			TValueCollection tValueCollection = collectionFactory();
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			return new MultiValueDictionary<TKey, TValue>(capacity)
			{
				NewCollectionFactory = (Func<ICollection<TValue>>)(object)collectionFactory
			};
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEqualityComparer<TKey> comparer, Func<TValueCollection> collectionFactory) where TValueCollection : ICollection<TValue>
		{
			TValueCollection tValueCollection = collectionFactory();
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			return new MultiValueDictionary<TKey, TValue>(comparer)
			{
				NewCollectionFactory = (Func<ICollection<TValue>>)(object)collectionFactory
			};
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(int capacity, IEqualityComparer<TKey> comparer, Func<TValueCollection> collectionFactory) where TValueCollection : ICollection<TValue>
		{
			Requires.Range(capacity >= 0, "capacity", null);
			TValueCollection tValueCollection = collectionFactory();
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			return new MultiValueDictionary<TKey, TValue>(capacity, comparer)
			{
				NewCollectionFactory = (Func<ICollection<TValue>>)(object)collectionFactory
			};
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEnumerable<KeyValuePair<TKey, IReadOnlyCollection<TValue>>> enumerable, Func<TValueCollection> collectionFactory) where TValueCollection : ICollection<TValue>
		{
			Requires.NotNullAllowStructs<IEnumerable<KeyValuePair<TKey, IReadOnlyCollection<TValue>>>>(enumerable, "enumerable");
			TValueCollection tValueCollection = collectionFactory();
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			MultiValueDictionary<TKey, TValue> multiValueDictionary = new MultiValueDictionary<TKey, TValue>();
			multiValueDictionary.NewCollectionFactory = (Func<ICollection<TValue>>)(object)collectionFactory;
			foreach (KeyValuePair<TKey, IReadOnlyCollection<TValue>> current in enumerable)
			{
				multiValueDictionary.AddRange(current.Key, current.Value);
			}
			return multiValueDictionary;
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEnumerable<KeyValuePair<TKey, IReadOnlyCollection<TValue>>> enumerable, IEqualityComparer<TKey> comparer, Func<TValueCollection> collectionFactory) where TValueCollection : ICollection<TValue>
		{
			Requires.NotNullAllowStructs<IEnumerable<KeyValuePair<TKey, IReadOnlyCollection<TValue>>>>(enumerable, "enumerable");
			TValueCollection tValueCollection = collectionFactory();
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			MultiValueDictionary<TKey, TValue> multiValueDictionary = new MultiValueDictionary<TKey, TValue>(comparer);
			multiValueDictionary.NewCollectionFactory = (Func<ICollection<TValue>>)(object)collectionFactory;
			foreach (KeyValuePair<TKey, IReadOnlyCollection<TValue>> current in enumerable)
			{
				multiValueDictionary.AddRange(current.Key, current.Value);
			}
			return multiValueDictionary;
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEnumerable<IGrouping<TKey, TValue>> enumerable, Func<TValueCollection> collectionFactory) where TValueCollection : ICollection<TValue>
		{
			Requires.NotNullAllowStructs<IEnumerable<IGrouping<TKey, TValue>>>(enumerable, "enumerable");
			TValueCollection tValueCollection = collectionFactory();
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			MultiValueDictionary<TKey, TValue> multiValueDictionary = new MultiValueDictionary<TKey, TValue>();
			multiValueDictionary.NewCollectionFactory = (Func<ICollection<TValue>>)(object)collectionFactory;
			foreach (IGrouping<TKey, TValue> current in enumerable)
			{
				multiValueDictionary.AddRange(current.Key, current);
			}
			return multiValueDictionary;
		}
		public static MultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEnumerable<IGrouping<TKey, TValue>> enumerable, IEqualityComparer<TKey> comparer, Func<TValueCollection> collectionFactory) where TValueCollection : ICollection<TValue>
		{
			Requires.NotNullAllowStructs<IEnumerable<IGrouping<TKey, TValue>>>(enumerable, "enumerable");
			TValueCollection tValueCollection = collectionFactory();
			if (tValueCollection.IsReadOnly)
			{
				throw new InvalidOperationException(SR.GetString(Exceptions.Create_TValueCollectionReadOnly));
			}
			MultiValueDictionary<TKey, TValue> multiValueDictionary = new MultiValueDictionary<TKey, TValue>(comparer);
			multiValueDictionary.NewCollectionFactory = (Func<ICollection<TValue>>)(object)collectionFactory;
			foreach (IGrouping<TKey, TValue> current in enumerable)
			{
				multiValueDictionary.AddRange(current.Key, current);
			}
			return multiValueDictionary;
		}
		public void Add(TKey key, TValue value)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			MultiValueDictionary<TKey, TValue>.InnerCollectionView innerCollectionView;
			if (!this.dictionary.TryGetValue(key, out innerCollectionView))
			{
				innerCollectionView = new MultiValueDictionary<TKey, TValue>.InnerCollectionView(key, this.NewCollectionFactory());
				this.dictionary.Add(key, innerCollectionView);
			}
			innerCollectionView.AddValue(value);
			this.version++;
		}
		public void AddRange(TKey key, IEnumerable<TValue> values)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			Requires.NotNullAllowStructs<IEnumerable<TValue>>(values, "values");
			MultiValueDictionary<TKey, TValue>.InnerCollectionView innerCollectionView;
			if (!this.dictionary.TryGetValue(key, out innerCollectionView))
			{
				innerCollectionView = new MultiValueDictionary<TKey, TValue>.InnerCollectionView(key, this.NewCollectionFactory());
				this.dictionary.Add(key, innerCollectionView);
			}
			foreach (TValue current in values)
			{
				innerCollectionView.AddValue(current);
			}
			this.version++;
		}
		public bool Remove(TKey key)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			MultiValueDictionary<TKey, TValue>.InnerCollectionView innerCollectionView;
			if (this.dictionary.TryGetValue(key, out innerCollectionView) && this.dictionary.Remove(key))
			{
				this.version++;
				return true;
			}
			return false;
		}
		public bool Remove(TKey key, TValue value)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			MultiValueDictionary<TKey, TValue>.InnerCollectionView innerCollectionView;
			if (this.dictionary.TryGetValue(key, out innerCollectionView) && innerCollectionView.RemoveValue(value))
			{
				if (innerCollectionView.Count == 0)
				{
					this.dictionary.Remove(key);
				}
				this.version++;
				return true;
			}
			return false;
		}
		public bool Contains(TKey key, TValue value)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			MultiValueDictionary<TKey, TValue>.InnerCollectionView innerCollectionView;
			return this.dictionary.TryGetValue(key, out innerCollectionView) && innerCollectionView.Contains(value);
		}
		public bool ContainsValue(TValue value)
		{
			foreach (MultiValueDictionary<TKey, TValue>.InnerCollectionView current in this.dictionary.Values)
			{
				if (current.Contains(value))
				{
					return true;
				}
			}
			return false;
		}
		public ILookup<TKey, TValue> AsLookup()
		{
			return new MultiValueDictionary<TKey, TValue>.MultiLookup(this);
		}
		public void Clear()
		{
			this.dictionary.Clear();
			this.version++;
		}
		public bool ContainsKey(TKey key)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			return this.dictionary.ContainsKey(key);
		}
		public bool TryGetValue(TKey key, out IReadOnlyCollection<TValue> value)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			MultiValueDictionary<TKey, TValue>.InnerCollectionView innerCollectionView;
			bool result = this.dictionary.TryGetValue(key, out innerCollectionView);
			value = innerCollectionView;
			return result;
		}
		public IEnumerator<KeyValuePair<TKey, IReadOnlyCollection<TValue>>> GetEnumerator()
		{
			return new MultiValueDictionary<TKey, TValue>.Enumerator(this);
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new MultiValueDictionary<TKey, TValue>.Enumerator(this);
		}
	}
}
