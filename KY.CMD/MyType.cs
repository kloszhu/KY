using System;
using System.Collections.Generic;
using System.Text;

namespace KY.CMD
{

        public class MyType
        {
            public static readonly System.Type
                Nullable = typeof(System.Nullable),
                Enum = typeof(System.Enum),
                Object = typeof(object),
                Byte = typeof(byte),
                SByte = typeof(sbyte),
                Int16 = typeof(short),
                UInt16 = typeof(ushort),
                Int32 = typeof(int),
                UInt32 = typeof(uint),
                Int64 = typeof(long),
                UInt64 = typeof(ulong),
                Single = typeof(float),
                Decimal = typeof(decimal),
                Double = typeof(double),
                Boolean = typeof(bool),
                Char = typeof(char),
                String = typeof(string),
                Guid = typeof(System.Guid),
                DateTime = typeof(System.DateTime),
                DateTimeOffset = typeof(System.DateTimeOffset),
                NullableByte = typeof(byte?),
                NullableSByte = typeof(sbyte?),
                NullableInt16 = typeof(short?),
                NullableUInt16 = typeof(ushort?),
                NullableInt32 = typeof(int?),
                NullableUInt32 = typeof(uint?),
                NullableInt64 = typeof(long?),
                NullableUInt64 = typeof(ulong?),
                NullableSingle = typeof(float?),
                NullableDecimal = typeof(decimal?),
                NullableDouble = typeof(double?),
                NullableBoolean = typeof(bool?),
                NullableChar = typeof(char?),
                NullableGuid = typeof(System.Guid?),
                NullableDateTime = typeof(System.DateTime?),
                NullableDateTimeOffset = typeof(System.DateTimeOffset?),
                ByteArray = typeof(byte[]),
                IntArray = typeof(int[]),
                StringArray = typeof(string[]),
                Exception = typeof(System.Exception),
                Convert = typeof(System.Convert),
                IEnumerator = typeof(System.Collections.IEnumerator),
                //MyConvert = typeof(MyConvert),
                //DbColumn = typeof(DbColumnAttribute),
                DataRow = typeof(System.Data.DataRow),
                DataRows = typeof(System.Data.DataRowCollection),
                DataTable = typeof(System.Data.DataTable),
                DataColumns = typeof(System.Data.DataColumnCollection),
                IDataRecord = typeof(System.Data.IDataRecord),
                IDataReader = typeof(System.Data.IDataReader);

            public static readonly System.Type[]
                ArrayObject = new System.Type[] { Object },
                ArrayInt = new System.Type[] { Int32 },
                ArrayString = new System.Type[] { String };
        }
    
}
