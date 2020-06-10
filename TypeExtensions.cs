using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;

namespace Commerce.Api.Model
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Adds value into dictionary, if key does not exist, add it, otherwise update it. and returns the dictionary instance itself (for chaining)
        /// </summary>
        /// <returns></returns>
        public static Dictionary<TK, TV> AddOrUpdate<TK, TV>(
            this Dictionary<TK, TV> dict,
            TK key,
            TV value
        )
        {
            if (dict.ContainsKey(key))
                dict[key] = value;
            else
                dict.Add(
                    key,
                    value
                );

            return dict;
        }

        /// <summary>
        /// Adds value into dictionary only if key does not exist. If key exists, nothing is done. Returns the dictionary instance itself (for chaining)
        /// </summary>
        /// <returns></returns>
        public static Dictionary<TK, TV> AddIfMissing<TK, TV>(
            this Dictionary<TK, TV> dict,
            TK key,
            TV value
        )
        {
            if (dict == null) throw new ArgumentNullException(nameof(dict));

            if (!dict.ContainsKey(key)) dict[key] = value;

            return dict;
        }


        public static Dictionary<TK, TV> AddIfMissing<TK, TV>(
            this Dictionary<TK, TV> dict,
            TK key,
            Func<TV> valueMethod
        )
        {
            if (dict == null) throw new ArgumentNullException(nameof(dict));

            if (!dict.ContainsKey(key)) dict[key] = valueMethod();

            return dict;
        }


        /// <summary>
        /// Removes the entry defined by key if it exist. If key does not exist, nothing is done. Returns the dictionary instance itself (for chaining)
        /// </summary>
        /// <returns></returns>
        public static Dictionary<TK, TV> RemoveIfThere<TK, TV>(this Dictionary<TK, TV> dict, TK key)
        {
            if (dict == null) throw new ArgumentNullException(nameof(dict));

            if (dict.ContainsKey(key)) dict.Remove(key);

            return dict;
        }

        /// <summary>
        /// Adds value into hashset only if key does not exist. If key exists, nothing is done. Returns the hashset instance itself (for chaining)
        /// </summary>
        /// <returns></returns>
        public static HashSet<T> AddIfMissing<T>(this HashSet<T> hashSet, T key)
        {
            if (hashSet == null) throw new ArgumentNullException(nameof(hashSet));

            if (!hashSet.Contains(key)) hashSet.Add(key);

            return hashSet;
        }

        public static void AddIfNotNull<T>(
            this IList<T> o,
            T value
        ) where T : class
        {
            if (value != null) o.Add(value);
        }

        public static void AddIfNotNull<T>(
            this HashSet<T> o,
            T value
        ) where T : class
        {
            if (value != null) o.Add(value);
        }

        /// <summary>
        /// Gets value from dictionary by key, or return null if no key exists or dictionary is null reference.
        /// </summary>
        [Pure]
        public static TV ValueOrNull<TK, TV>(
            this IDictionary<TK, TV> dict,
            TK key
        )
        {
            if (dict == null) return default(TV);

            return dict.ContainsKey(key) ? dict[key] : default(TV);
        }


        /// <summary>
        /// Gets value from concurrent dictionary by key, or return null if no key exists or dictionary is null reference.
        /// </summary>
        [Pure]
        public static TV ValueOrNull<TK, TV>(
            this ConcurrentDictionary<TK, TV> dict,
            TK key
        ) where TV : class
        {
            return dict == null
                ? default(TV)
                : dict.TryGetValue(
                    key,
                    out var retval
                )
                    ? retval
                    : default(TV);
        }

        /// <summary>
        /// Gets value from dictionary by key, or the supplied default value if no key exists
        /// </summary>
        [Pure]
        public static TV ValueOrDefault<TK, TV>(
            this IDictionary<TK, TV> dict,
            TK key,
            TV valueMethod
        )
        {
            if (dict == null) return valueMethod;

            return dict.ContainsKey(key) ? dict[key] : valueMethod;
        }

        /// <summary>
        /// Gets value from dictionary by key, or the supplied default value if no key exists
        /// </summary>
        [Pure]
        public static TV ValueOrDefault<TK, TV>(
            this Dictionary<TK, TV> dict,
            TK key,
            Func<TV> valueMethod
        )
        {
            if (dict == null) return valueMethod();

            return dict.ContainsKey(key) ? dict[key] : valueMethod();
        }

        /// <summary>
        /// Gets value from dictionary by key. If dictionary has no key, call the delegate to get new value to add to dictionary, and return this value.
        /// </summary>
        public static TV ValueOrAdd<TK, TV>(
            this IDictionary<TK, TV> dict,
            TK key,
            Func<TV> valueMethod
        )
        {
            if (dict.ContainsKey(key)) return dict[key];

            var value = valueMethod();
            dict.Add(
                key,
                value
            );
            return value;
        }

        /// <summary>
        /// Gets value from dictionary by key. If dictionary has no key, call the delegate to get new value to add to dictionary, and return this value.
        /// </summary>
        public static TV ValueOrAdd<TK, TV>(
            this ConcurrentDictionary<TK, TV> dict,
            TK key,
            Func<TV> valueMethod
        )
        {
            return dict.GetOrAdd(
                key,
                k => valueMethod.Invoke()
            );
        }

        /// <summary>
        /// If instance is null, create a new <typeparamref name="T"/> instance using the valueMethod. 
        /// Returns either the instance or in case it was null, the newly created instance. 
        /// </summary>
        [Pure]
        public static T CreateIfNull<T>(
            this T o,
            Func<T> valueMethod
        ) where T : class
        {
            return o ?? valueMethod();
        }

        /// <summary>
        /// Returns a nullable datetime instance that returns the date, but null if datetime instance is Datetime.MinValue.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime? ToNullable(this DateTime d)
        {
            return d == DateTime.MinValue ? null : (DateTime?) d;
        }


        /// <summary>
        /// Finds the nearest past time slot based on slot duration, i.e. the slot closest to, but not newer than now.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="slotDuration"></param>
        /// <returns></returns>
        public static DateTime ToNearestSlot(this DateTime d, TimeSpan slotDuration)
        {
            var probeDate = DateTime.Now.Date;
            while (probeDate.Add(slotDuration) < d) probeDate = probeDate.Add(slotDuration);

            return probeDate;
        }

        /// <summary>
        /// Interprets the string as a <see cref="TimeSpan"/>. Time can be written in any form, using
        /// literals as unit, i.e. "d" = days, "h" = hours, "m" = minutes, "s" = seconds", "f" = milliseconds.
        /// If no qualifier is used, then minutes is assumed.
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public static TimeSpan? ToTimeSpan(
            this string timeSpan
        )
        {
            if (string.IsNullOrWhiteSpace(timeSpan)) return null;

            var l = timeSpan.Length - 1;
            var value = timeSpan.Substring(
                0,
                l
            );
            var type = timeSpan.Substring(
                l,
                1
            );
            switch (type)
            {
                case "d":
                    return TimeSpan.FromDays(double.Parse(value));
                case "h":
                    return TimeSpan.FromHours(double.Parse(value));
                case "m":
                    return TimeSpan.FromMinutes(double.Parse(value));
                case "s":
                    return TimeSpan.FromSeconds(double.Parse(value));
                case "f":
                    return TimeSpan.FromMilliseconds(double.Parse(value));
                case "z":
                    return TimeSpan.FromTicks(long.Parse(value));
                default:
                    return TimeSpan.FromMinutes(double.Parse(timeSpan));
            }
        }

        /// <summary>
        /// Parses the string to enum of type <typeparamref name="T"/>. Throws an exception if string cannot be parsed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
        {
            return (T) Enum.Parse(
                typeof(T),
                value,
                true
            );
        }

        /// <summary>
        /// Parses the string to enum of type <typeparamref name="T"/>. Returns defaultValue if string is null or cannot be parsed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ToEnum<T>(
            this string value,
            T defaultValue
        ) where T : struct
        {
            if (string.IsNullOrWhiteSpace(value)) return defaultValue;

            return Enum.TryParse(
                value,
                true,
                out T result
            )
                ? result
                : defaultValue;
        }

        /// <summary>
        /// Parses the string to nullable boolean. Returns null if string is null or cannot be parsed.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool? ToBoolean(
            this string value
        )
        {
            if (value == null) return null;

            if (bool.TryParse(
                value,
                out var retval
            ))
                return retval;

            return null;
        }

        /// <summary>
        /// Returns null if the bool is false, otherwise a nullable true.
        /// Used primarily for json responses.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool? ToNullIfFalse(
            this bool b
        )
        {
            return b ? (bool?) true : null;
        }

        /// <summary>
        /// Returns null if the bool is false, otherwise a nullable true.
        /// Used primarily for json responses.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool? ToNullIfFalse(
            this bool? b
        )
        {
            return b == true ? (bool?) true : null;
        }


        /// <summary>
        /// Parses the string to nullable <see cref="int"/>. Returns null if string is null or cannot be parsed.
        /// </summary>
        /// <returns></returns>
        public static int? ToInteger(
            this string value,
            NumberStyles style,
            IFormatProvider format
        )
        {
            if (string.IsNullOrWhiteSpace(value)) return null;

            if (int.TryParse(
                value,
                style,
                format,
                out var retval
            ))
                return retval;

            return null;
        }

        /// <summary>
        /// Returns null if the string is null or whitespace.
        /// Used primarily for json responses.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToNullIfWhite(
            this string s
        )
        {
            return string.IsNullOrWhiteSpace(s) ? null : s;
        }

        public static string ToLowerFirstCharacter(this string source)
        {
            if (string.IsNullOrWhiteSpace(source)) return source;

            var charArray = source.ToCharArray();
            charArray[0] = char.ToLower(
                charArray[0],
                CultureInfo.InvariantCulture
            );
            return new string(charArray);
        }

        public static int? ToIntegerConfigStyle(this string value)
        {
            return ToInteger(
                value,
                Statics.ConfigNumberStyles,
                Statics.ConfigNumberFormat
            );
        }

        /// <summary>
        /// Returns a string representation with only the digits of the integer, i.e. no group separators
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStringConfigStyle(this int value)
        {
            return value.ToString("0");
        }

        /// <summary>
        /// Returns a string representation with only the digits of the integer, i.e. no group separators
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStringConfigStyle(this long value)
        {
            return value.ToString("0");
        }

        public static string GetValueOrDefault(this string str, string defaultValue)
        {
            return str ?? defaultValue;
        }

        /// <summary>
        /// Parses the string to a list of <see cref="int"/>, assuming delimiter supplied.
        /// Only returns elements, that can be parsed to an int.
        /// </summary>
        /// <returns></returns>
        public static int[] ToIntegerArray(
            this string value,
            string delimiter,
            NumberStyles style,
            IFormatProvider format
        )
        {
            return string.IsNullOrWhiteSpace(value)
                ? new int[] { }
                : value?.Split(
                        new[] {delimiter},
                        StringSplitOptions.RemoveEmptyEntries
                    )
                    .Select(
                        x =>
                        {
                            if (int.TryParse(
                                x,
                                style,
                                format,
                                out var i
                            ))
                                return (int?) i;

                            return (int?) null;
                        }
                    )
                    .Where(x => x.HasValue)
                    .Select(x => x.Value)
                    .ToArray();
        }


        public static int[] ToIntegerArrayConfigStyle(this string value, string delimiter)
        {
            return ToIntegerArray(
                value,
                delimiter,
                Statics.ConfigNumberStyles,
                Statics.ConfigNumberFormat
            );
        }

        /// <summary>
        /// Returns a nullable int - if value is zero, it is returned as a null.
        /// From Classic eSeller, many values and especially IDs from database  = zero was considered (non-existing), hence this convention.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int? ToNullable(this int i)
        {
            return i == 0 || i == int.MinValue ? null : (int?) i;
        }

        /// <summary>
        /// Returns a nullable int - if value is zero, it is returned as a null.
        /// From Classic eSeller, many values and especially IDs from database  = zero was considered (non-existing), hence this convention.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int? ToNullable(this int? i)
        {
            return i == 0 || i == int.MinValue ? null : i;
        }

        public static decimal? ToNullable(this decimal i)
        {
            return i == 0 || i == decimal.MinValue ? null : (decimal?) i;
        }

        public static decimal? ToNullable(this decimal? i)
        {
            return i == 0 || i == decimal.MinValue ? null : (decimal?) i;
        }

        /// <summary>
        /// Returns a nullable long - if value is zero, it is returned as a null.
        /// From Classic eSeller, many values and especially IDs from database  = zero was considered (non-existing), hence this convention.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static long? ToNullable(this long i)
        {
            return i == 0 || i == long.MinValue ? null : (long?) i;
        }

        /// <summary>
        /// Returns a nullable guid - if value is Guid.Empty, it is returned as a null.
        /// From Classic eSeller, many values and especially IDs from database  = Guid.Empty was considered (non-existing), hence this convention.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Guid? ToNullable(this Guid i)
        {
            return i == Guid.Empty ? null : (Guid?) i;
        }

        /// <summary>
        /// Parses the string to nullable <see cref="double"/>. Returns null if string is null or cannot be parsed.
        /// </summary>
        public static double? ToDouble(
            this string value,
            NumberStyles style,
            IFormatProvider format
        )
        {
            if (string.IsNullOrWhiteSpace(value)) return null;

            if (double.TryParse(
                value,
                style,
                format,
                out var retval
            ))
                return retval;

            return null;
        }

        public static double? ToDoubleConfigStyle(this string value)
        {
            return ToDouble(
                value,
                Statics.ConfigNumberStyles,
                Statics.ConfigNumberFormat
            );
        }

        /// <summary>
        /// Parses the string to nullable <see cref="decimal"/>. Returns null if string is null or cannot be parsed.
        /// </summary>
        public static decimal? ToDecimal(
            this string value,
            NumberStyles style,
            IFormatProvider format
        )
        {
            if (string.IsNullOrWhiteSpace(value)) return null;

            if (decimal.TryParse(
                value,
                style,
                format,
                out var retval
            ))
                return retval;

            return null;
        }

        public static decimal? ToDecimalConfigStyle(this string value)
        {
            return ToDecimal(
                value,
                Statics.ConfigNumberStyles,
                Statics.ConfigNumberFormat
            );
        }


        public static string ToStringConfigStyle(this decimal? value)
        {
            return value?.ToString(Statics.ConfigNumberFormat);
        }


        public static string ToStringConfigStyle(this decimal value)
        {
            return value.ToString(Statics.ConfigNumberFormat);
        }


        /// <summary>
        /// Parses the string to nullable <see cref="long"/>. Returns null if string is null or cannot be parsed.
        /// </summary>
        public static long? ToLong(
            this string value,
            NumberStyles style,
            IFormatProvider format
        )
        {
            if (string.IsNullOrWhiteSpace(value)) return null;

            if (long.TryParse(
                value,
                style,
                format,
                out var retval
            ))
                return retval;

            return null;
        }

        public static long? ToLongConfigStyle(this string value)
        {
            return ToLong(
                value,
                Statics.ConfigNumberStyles,
                Statics.ConfigNumberFormat
            );
        }

        /// <summary>
        /// Parses the string to nullable <see cref="long"/>. Returns null if string is null or cannot be parsed.
        /// </summary>
        public static Guid? ToGuid(
            this string value
        )
        {
            if (string.IsNullOrWhiteSpace(value)) return null;

            if (Guid.TryParse(
                value,
                out var retval
            ))
                return retval;

            return null;
        }

        /// <summary>
        /// Performs <see cref="Action{T}"/> for each occurence in <see cref="IEnumerable{T}"/>. <see cref="IEnumerable{T}"/> may be null, in which case nothing is done.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(
            this IEnumerable<T> enumerable,
            Action<T> action
        )
        {
            if (enumerable == null) return;

            foreach (var local in enumerable) action(local);
        }


        ///// <summary>
        ///// Creates a deep-copy clone of the instance using serialization / deserialization.
        ///// This requires the object graph to be serializable using <see cref="ProtoBuf"/>.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="o"></param>
        ///// <returns></returns>
        //public static T CloneUsingProtoBuf<T>(this T o)
        //{
        //    using (var memoryStream = new System.IO.MemoryStream())
        //    {
        //        ProtoBuf.Serializer.Serialize(
        //            memoryStream,
        //            o
        //        );
        //        memoryStream.Position = 0;
        //        return ProtoBuf.Serializer.Deserialize<T>(memoryStream);
        //    }
        //}

        /// <summary>
        /// Returns the content as a json representation. Used for passing info to ui.
        /// </summary>
        public static string ToJsonString(this ItemKey k)
        {
            return $"{{\"itemId:{k.ItemId}\",\"typeOfItem\":\"{k.TypeOfItem.ToString()}\"}}";
        }


        public static IEnumerable<TSource> IsWithinScopeOf<TSource, TKey>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, TKey> keySelector,
            HashSet<TKey> scope
        )
        {
            return scope == null
                ? enumerable
                : enumerable.Where(x => scope.Contains(keySelector(x)));
        }

        public static IEnumerable<TSource> OrderByOnlyWhenComparerNotNull<TSource, TKey>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer
        )
        {
            return comparer == null
                ? enumerable
                : enumerable.OrderBy(
                    keySelector,
                    comparer
                );
        }


        /// <summary>
        /// Splits the current enumeration, so that the current enumeration is forked to a copyOf list,
        /// while you can continue cascading linq on the original one. 
        /// Note: As the source is always enumerated, and a split copy is always provided, this is a more or less expensive operation.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="copyOf"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Fork<TSource>(
            this IEnumerable<TSource> enumerable,
            out List<TSource> copyOf
        )
        {
            var mainEnumeration = enumerable.ToList();
            copyOf = mainEnumeration.ToList();
            return mainEnumeration;
        }

        /// <summary>
        /// Applies paging filter to the <see cref="IEnumerable{T}"/>, while retaining and returning the original list as an output.
        /// Paging applies a window on the <see cref="IEnumerable{T}"/> only if both pageSize and pageIndex is within valid ranges.
        /// Note: As the source is always enumerated, and a split copy is always provided, this is a more expensive operation.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="pageSize">Specifies how many items are on a single page</param>
        /// <param name="pageNumber">Specifies the page number (1-based)</param>
        /// <returns></returns>
        public static IEnumerable<TSource> ApplyPaging<TSource>(
            this IEnumerable<TSource> enumerable,
            int? pageSize,
            int? pageNumber
        )
        {
            return pageSize == null ||
                   pageSize < 1 ||
                   pageNumber == null ||
                   pageNumber < 1
                ? enumerable
                : enumerable
                    .Skip((pageNumber.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);
        }


        public static IEnumerable<Enum> GetFlags(this Enum value)
        {
            return GetFlags(
                value,
                Enum.GetValues(value.GetType()).Cast<Enum>().ToArray()
            );
        }


        public static IEnumerable<Enum> GetIndividualFlags(this Enum value)
        {
            return GetFlags(
                value,
                GetFlagValues(value.GetType()).ToArray()
            );
        }


        private static IEnumerable<Enum> GetFlags(Enum value, Enum[] values)
        {
            var bits = Convert.ToUInt64(value);
            var results = new List<Enum>();
            for (var i = values.Length - 1; i >= 0; i--)
            {
                var mask = Convert.ToUInt64(values[i]);
                if (i == 0 && mask == 0L) break;

                if ((bits & mask) == mask)
                {
                    results.Add(values[i]);
                    bits -= mask;
                }
            }

            if (bits != 0L) return Enumerable.Empty<Enum>();

            if (Convert.ToUInt64(value) != 0L) return results.Reverse<Enum>();

            if (bits == Convert.ToUInt64(value) && values.Length > 0 && Convert.ToUInt64(values[0]) == 0L)
                return values.Take(1);

            return Enumerable.Empty<Enum>();
        }

        private static IEnumerable<Enum> GetFlagValues(Type enumType)
        {
            ulong flag = 0x1;
            foreach (var value in Enum.GetValues(enumType).Cast<Enum>())
            {
                var bits = Convert.ToUInt64(value);
                if (bits == 0L)
                    //yield return value;
                    continue; // skip the zero value

                while (flag < bits) flag <<= 1;

                if (flag == bits) yield return value;
            }
        }

        /// <summary>
        /// Extension method for <see cref="string.IsNullOrWhiteSpace(string)"/>.
        /// </summary>
        public static bool IsWhiteSpaceOrNull(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// Extension method for <see cref="string.IsNullOrEmpty(string)"/>.
        /// </summary>
        public static bool IsEmptyOrNull(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
    }
}