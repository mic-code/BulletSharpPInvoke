using System;
using System.Collections.Generic;
using System.Diagnostics;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp.Math
{
    internal class Vector3ListDebugView
    {
        private IList<Vector3d> _list;

        public Vector3ListDebugView(IList<Vector3d> list)
        {
            _list = list;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public Vector3d[] Items
        {
            get
            {
                var arr = new Vector3d[_list.Count];
                _list.CopyTo(arr, 0);
                return arr;
            }
        }
    };

    public class Vector3ArrayEnumerator : IEnumerator<Vector3d>
    {
        private int _i;
        private int _count;
        private IList<Vector3d> _array;

        public Vector3ArrayEnumerator(IList<Vector3d> array)
        {
            _array = array;
            _count = array.Count;
            _i = -1;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _i++;
            return _i != _count;
        }

        public void Reset()
        {
            _i = 0;
        }

        public Vector3d Current => _array[_i];

        object System.Collections.IEnumerator.Current => _array[_i];
    }

    [DebuggerDisplay("Count = {Count}")]
    [DebuggerTypeProxy(typeof(Vector3ListDebugView))]
    public class Vector3Array : FixedSizeArray, IList<Vector3d>
    {
        internal Vector3Array(IntPtr native, int count)
            : base(native, count)
        {
        }

        public int IndexOf(Vector3d item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Vector3d item)
        {
            throw new NotSupportedException();
        }

        public Vector3d this[int index]
        {
            get
            {
                if ((uint)index >= (uint)Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                Vector3d value;
                btVector3_array_at(_native, index, out value);
                return value;
            }
            set
            {
                if ((uint)index >= (uint)Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                btVector3_array_set(_native, index, ref value);
            }
        }

        public void Add(Vector3d item)
        {
            throw new NotSupportedException();
        }

        public bool Contains(Vector3d item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Vector3d[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(array));

            int count = Count;
            if (arrayIndex + count > array.Length)
                throw new ArgumentException("Array too small.", "array");

            for (int i = 0; i < count; i++)
            {
                array[arrayIndex + i] = this[i];
            }
        }

        public bool Remove(Vector3d item)
        {
            throw new NotSupportedException();
        }

        public IEnumerator<Vector3d> GetEnumerator()
        {
            return new Vector3ArrayEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new Vector3ArrayEnumerator(this);
        }
    }
}
