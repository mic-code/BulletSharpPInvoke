﻿using System;
using System.IO;
using BulletSharp.Math;
using System.Collections.Generic;
using System.Text;

namespace BulletSharp
{
    public class BulletReader : BinaryReader
    {
        public BulletReader(Stream stream)
            : base(stream)
        {
        }

        public byte ReadByte(int position)
        {
            BaseStream.Position = position;
            return ReadByte();
        }

        public double ReadDouble(int position)
        {
            BaseStream.Position = position;
            return ReadDouble();
        }

        public float ReadSingle(int position)
        {
            BaseStream.Position = position;
            return ReadSingle();
        }

        public int ReadInt32(int position)
        {
            BaseStream.Position = position;
            return ReadInt32();
        }

        public long ReadInt64(int position)
        {
            BaseStream.Position = position;
            return ReadInt64();
        }

        public Matrix ReadMatrix()
        {
            double[] m = new double[16];
            m[0] = ReadSingle();
            m[4] = ReadSingle();
            m[8] = ReadSingle();
            ReadSingle();
            m[1] = ReadSingle();
            m[5] = ReadSingle();
            m[9] = ReadSingle();
            ReadSingle();
            m[2] = ReadSingle();
            m[6] = ReadSingle();
            m[10] = ReadSingle();
            ReadSingle();
            m[12] = ReadSingle();
            m[13] = ReadSingle();
            m[14] = ReadSingle();
            ReadSingle();
            m[15] = 1;
            return new Matrix(m);
        }

        public Matrix ReadMatrixDouble()
        {
            double[] m = new double[16];
            m[0] = ReadDouble();
            m[4] = ReadDouble();
            m[8] = ReadDouble();
            ReadDouble();
            m[1] = ReadDouble();
            m[5] = ReadDouble();
            m[9] = ReadDouble();
            ReadDouble();
            m[2] = ReadDouble();
            m[6] = ReadDouble();
            m[10] = ReadDouble();
            ReadDouble();
            m[12] = ReadDouble();
            m[13] = ReadDouble();
            m[14] = ReadDouble();
            ReadDouble();
            m[15] = 1;
            return new Matrix(m);
        }

        public Matrix ReadMatrix(int position)
        {
            BaseStream.Position = position;
            return ReadMatrix();
        }

        public Matrix ReadMatrixDouble(int position)
        {
            BaseStream.Position = position;
            return ReadMatrixDouble();
        }

        public string ReadNullTerminatedString()
        {
            List<byte> name = new List<byte>();
            byte ch = ReadByte();
            while (ch != 0)
            {
                name.Add(ch);
                ch = ReadByte();
            }
            return Encoding.ASCII.GetString(name.ToArray());
        }

        public long ReadPtr()
        {
            return (IntPtr.Size == 8) ? ReadInt64() : ReadInt32();
        }

        public long ReadPtr(int position)
        {
            BaseStream.Position = position;
            return ReadPtr();
        }

        public string[] ReadStringList()
        {
            int count = ReadInt32();
            string[] list = new string[count];
            for (int i = 0; i < count; i++)
            {
                list[i] = ReadNullTerminatedString();
            }

            BaseStream.Position = (BaseStream.Position + 3) & ~3;
            return list;
        }

        public void ReadTag(string tag)
        {
            byte[] codeData = ReadBytes(tag.Length);
            string code = Encoding.ASCII.GetString(codeData);
            if (code != tag)
            {
                throw new InvalidDataException($"Expected tag: {tag}");
            }
        }

        public Vector3d ReadVector3()
        {
            double x = ReadSingle();
            double y = ReadSingle();
            double z = ReadSingle();
            BaseStream.Position += sizeof(float); // double w = ReadSingle();
            return new Vector3d(x, y, z);
        }

        public Vector3d ReadVector3Double()
        {
            double x = ReadDouble();
            double y = ReadDouble();
            double z = ReadDouble();
            BaseStream.Position += sizeof(double); // double w = ReadDouble();
            return new Vector3d(x, y, z);
        }

        public Vector3d ReadVector3(int position)
        {
            BaseStream.Position = position;
            return ReadVector3();
        }

        public Vector3d ReadVector3Double(int position)
        {
            BaseStream.Position = position;
            return ReadVector3Double();
        }

        public static Matrix ToMatrix(byte[] value, int startIndex)
        {
            return new Matrix(
                BitConverter.ToSingle(value, startIndex),
                BitConverter.ToSingle(value, startIndex + 16),
                BitConverter.ToSingle(value, startIndex + 32),
                0,
                BitConverter.ToSingle(value, startIndex + 4),
                BitConverter.ToSingle(value, startIndex + 20),
                BitConverter.ToSingle(value, startIndex + 36),
                0,
                BitConverter.ToSingle(value, startIndex + 8),
                BitConverter.ToSingle(value, startIndex + 24),
                BitConverter.ToSingle(value, startIndex + 40),
                0,
                BitConverter.ToSingle(value, startIndex + 48),
                BitConverter.ToSingle(value, startIndex + 52),
                BitConverter.ToSingle(value, startIndex + 56),
                1);
        }

        public static Matrix ToMatrixDouble(byte[] value, int startIndex)
        {
            return new Matrix(
                (float)BitConverter.ToDouble(value, startIndex),
                (float)BitConverter.ToDouble(value, startIndex + 32),
                (float)BitConverter.ToDouble(value, startIndex + 64),
                0,
                (float)BitConverter.ToDouble(value, startIndex + 8),
                (float)BitConverter.ToDouble(value, startIndex + 40),
                (float)BitConverter.ToDouble(value, startIndex + 72),
                0,
                (float)BitConverter.ToDouble(value, startIndex + 16),
                (float)BitConverter.ToDouble(value, startIndex + 48),
                (float)BitConverter.ToDouble(value, startIndex + 80),
                0,
                (float)BitConverter.ToDouble(value, startIndex + 96),
                (float)BitConverter.ToDouble(value, startIndex + 104),
                (float)BitConverter.ToDouble(value, startIndex + 112),
                1);
        }

        public static long ToPtr(byte[] value, int startIndex)
        {
            return IntPtr.Size == 8
                ? BitConverter.ToInt64(value, startIndex)
                : BitConverter.ToInt32(value, startIndex);
        }

        public static Vector3d ToVector3(byte[] value, int startIndex)
        {
            return new Vector3d(
                BitConverter.ToSingle(value, startIndex),
                BitConverter.ToSingle(value, startIndex + 4),
                BitConverter.ToSingle(value, startIndex + 8));
        }

        public static Vector3d ToVector3Double(byte[] value, int startIndex)
        {
            return new Vector3d(
                (float)BitConverter.ToDouble(value, startIndex),
                (float)BitConverter.ToDouble(value, startIndex + 8),
                (float)BitConverter.ToDouble(value, startIndex + 16));
        }
    }
}
