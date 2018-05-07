using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class CollectionExtensions
    {
		public static async Task<IEnumerable> AsEnumerable(this Task<ICollection> collection)
			=> await collection;

		public static async Task<IEnumerable> AsEnumerable(this Task<IList> collection)
			=> await collection;

		public static async Task<IEnumerable> AsEnumerable(this Task<IDictionary> collection)
			=> await collection;

		public static async Task<IEnumerable> AsEnumerable(this Task<Array> collection)
			=> await collection;

		public static async Task<IEnumerable> AsEnumerable(this Task<ArrayList> collection)
			=> await collection;

		public static async Task<IEnumerable> AsEnumerable(this Task<BitArray> collection)
			=> await collection;

		public static async Task<IEnumerable> AsEnumerable(this Task<Hashtable> collection)
			=> await collection;

		public static async Task<IEnumerable> AsEnumerable(this Task<Queue> collection)
			=> await collection;

		public static async Task<IEnumerable> AsEnumerable(this Task<Stack> collection)
			=> await collection;

		public static async Task<IEnumerable> AsEnumerable(this Task<SortedList> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<ICollection<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<IList<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<ISet<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<IOrderedEnumerable<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<KeyValuePair<TKey, TValue>>> AsEnumerable<TKey, TValue>(this Task<IDictionary<TKey, TValue>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<IReadOnlyCollection<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<IReadOnlyList<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<KeyValuePair<TKey, TValue>>> AsEnumerable<TKey, TValue>(this Task<IReadOnlyDictionary<TKey, TValue>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<T[]> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<List<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<LinkedList<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<Stack<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<Queue<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<HashSet<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<SortedSet<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<KeyValuePair<TKey, TValue>>> AsEnumerable<TKey, TValue>(this Task<SortedDictionary<TKey, TValue>> collection)
			=> await collection;

		public static async Task<IEnumerable<KeyValuePair<TKey, TValue>>> AsEnumerable<TKey, TValue>(this Task<SortedList<TKey, TValue>> collection)
			=> await collection;

		public static async Task<IEnumerable<KeyValuePair<TKey, TValue>>> AsEnumerable<TKey, TValue>(this Task<Dictionary<TKey, TValue>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<IProducerConsumerCollection<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<ConcurrentBag<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<ConcurrentQueue<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<ConcurrentStack<T>> collection)
			=> await collection;

		public static async Task<IEnumerable<KeyValuePair<TKey, TValue>>> AsEnumerable<TKey, TValue>(this Task<ConcurrentDictionary<TKey, TValue>> collection)
			=> await collection;
	}
}
