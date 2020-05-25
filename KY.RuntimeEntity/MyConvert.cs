using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace KY.RuntimeEntity
{

        public static class MyConvert
        {
            private static readonly IFormatter formatter = new BinaryFormatter();

            #region 值类型
            public static bool ToBoolean(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToBoolean(value);
                    }
                    catch
                    {
                    }
                }
                return false;
            }

            public static char ToChar(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        string str = Convert.ToString(value);
                        if (null != str && 0 < str.Length)
                        {
                            return str[0];
                        }
                    }
                    catch
                    {
                    }
                }
                return '\0';
            }

            public static sbyte ToSByte(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToSByte(value);
                    }
                    catch
                    {
                    }
                }
                return 0;
            }

            public static byte ToByte(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToByte(value);
                    }
                    catch
                    {
                    }
                }
                return 0;
            }

            public static short ToInt16(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToInt16(value);
                    }
                    catch
                    {
                    }
                }
                return 0;
            }

            public static ushort ToUInt16(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToUInt16(value);
                    }
                    catch
                    {
                    }
                }
                return 0;
            }

            public static int ToInt32(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToInt32(value);
                    }
                    catch
                    {
                    }
                }
                return 0;
            }

            public static uint ToUInt32(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToUInt32(value);
                    }
                    catch
                    {
                    }
                }
                return 0;
            }

            public static long ToInt64(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToInt64(value);
                    }
                    catch
                    {
                    }
                }
                return 0;
            }

            public static ulong ToUInt64(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToUInt64(value);
                    }
                    catch
                    {
                    }
                }
                return 0;
            }

            public static float ToSingle(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToSingle(value);
                    }
                    catch
                    {
                    }
                }
                return 0f;
            }

            public static decimal ToDecimal(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToDecimal(value);
                    }
                    catch
                    {
                    }
                }
                return 0m;
            }

            public static double ToDouble(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToDouble(value);
                    }
                    catch
                    {
                    }
                }
                return 0d;
            }

            public static DateTime ToDateTime(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToDateTime(value);
                    }
                    catch
                    {
                    }
                }
                return DateTime.MinValue;
            }

            public static DateTimeOffset ToDateTimeOffset(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return (DateTimeOffset)value;
                    }
                    catch
                    {
                    }
                }
                return DateTimeOffset.MinValue;
            }
            public static DateTimeOffset? ToDateTimeOffsetNullable(object value)
            {
                if (value != DBNull.Value)
                {
                    try
                    {
                        return (DateTimeOffset)value;
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            #endregion

            #region 引用类型
            public static object ToObject(object value)
            {
                return value;
            }

            public static bool? ToBooleanNullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToBoolean(value);
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            public static byte[] ToByteArray(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    MemoryStream stream = new MemoryStream();
                    try
                    {
                        formatter.Serialize(stream, value);
                        return stream.GetBuffer();
                    }
                    finally
                    {
                        stream.Dispose();
                    }
                }
                return null;
            }

            public static char? ToCharNullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        string str = Convert.ToString(value);
                        if (null != str && 0 < str.Length)
                        {
                            return str[0];
                        }
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            public static Guid ToGuid(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return (Guid)value;
                    }
                    catch
                    {
                    }
                }
                return Guid.Empty;
            }

            public static byte? ToByteNullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToByte(value);
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            public static sbyte? ToSByteNullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToSByte(value);
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            public static short? ToInt16Nullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToInt16(value);
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            public static ushort? ToUInt16Nullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToUInt16(value);
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            public static int? ToInt32Nullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToInt32(value);
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            public static uint? ToUInt32Nullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToUInt32(value);
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            public static long? ToInt64Nullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToInt64(value);
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            public static ulong? ToUInt64Nullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToUInt64(value);
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            public static float? ToSingleNullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToSingle(value);
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            public static decimal? ToDecimalNullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToDecimal(value);
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            public static double? ToDoubleNullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToDouble(value);
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            public static DateTime? ToDateTimeNullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return Convert.ToDateTime(value);
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            public static Guid? ToGuidNullable(object value)
            {
                if (null != value && value != DBNull.Value)
                {
                    try
                    {
                        return (Guid)value;
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            #endregion

            #region 其他
            public static int IndexOf(int length, string[] fields, string name)
            {
                for (int index = 0; index < length; index++)
                {
                    if (string.Equals(fields[index], name, StringComparison.OrdinalIgnoreCase))
                    {
                        return index;
                    }
                }
                return -1;
            }
            #endregion

        }
    
}
