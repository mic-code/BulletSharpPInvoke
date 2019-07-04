﻿using System;
using System.IO;
using BulletSharp.Math;

namespace BulletSharp
{
    class BulletWriter : BinaryWriter
    {
        public BulletWriter(Stream stream)
            : base(stream)
        {
        }

        public void Write(double value, int position)
        {
            BaseStream.Position = position;
            Write(value);
        }

        public void Write(int value, int position)
        {
            BaseStream.Position = position;
            Write(value);
        }

        public void Write(long value, int position)
        {
            BaseStream.Position = position;
            Write(value);
        }

        public void Write(Matrix value)
        {
            Write(value.M11);
            Write(value.M21);
            Write(value.M31);
            Write(0);
            Write(value.M12);
            Write(value.M22);
            Write(value.M32);
            Write(0);
            Write(value.M13);
            Write(value.M23);
            Write(value.M33);
            Write(0);
            Write(value.M41);
            Write(value.M42);
            Write(value.M43);
            Write(1);
        }

        public void Write(Matrix value, int position)
        {
            BaseStream.Position = position;
            Write(value);
        }

        public void Write(IntPtr value)
        {
            if (IntPtr.Size == 8)
            {
                Write(value.ToInt64());
            }
            else
            {
                Write(value.ToInt32());
            }
        }

        public void Write(IntPtr value, int position)
        {
            BaseStream.Position = position;
            Write(value);
        }

        public void Write(Vector3d value)
        {
            Write(value.X);
            Write(value.Y);
            Write(value.Z);
            BaseStream.Position += 4; // Write(value.W);
        }

        public void Write(Vector3d value, int position)
        {
            BaseStream.Position = position;
            Write(value);
        }
    }
}
