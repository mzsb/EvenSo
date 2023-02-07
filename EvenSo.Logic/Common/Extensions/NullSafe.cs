namespace EvenSo
{
    internal static class NullSafes
    {
        internal static T IsNotNull<T>(this object item, Func<T> wasNotNull, Action? wasNull = null) =>
            IsNotNullFuncLogic(wasNotNull, wasNull, item);

        internal static void IsNotNull(this object item, Action wasNotNull, Action? wasNull = null) =>
            IsNotNullActionLogic(wasNotNull, wasNull, item);

        internal static async Task<T> IsNotNull<T>(this object item, Func<Task<T>> wasNotNull, Action? wasNull = null) =>
            await IsNotNullFuncLogicAsync(wasNotNull, wasNull, item);

        internal static async Task IsNotNull(this object item, Func<Task> wasNotNull, Action? wasNull = null) =>
            await IsNotNullActionLogicAsync(wasNotNull, wasNull, item);

        private static T IsNotNullFuncLogic<T>(Func<T> wasNotNull, Action? wasNull, params object[] items)
        {
            NullCheck(wasNull, items);

            return wasNotNull();
        }

        private static void IsNotNullActionLogic(Action wasNotNull, Action? wasNull, params object[] items)
        {
            NullCheck(wasNull, items);

            wasNotNull();
        }

        private static async Task<T> IsNotNullFuncLogicAsync<T>(Func<Task<T>> wasNotNull, Action? wasNull, params object[] items)
        {
            NullCheck(wasNull, items);

            return await wasNotNull();
        }

        private static async Task IsNotNullActionLogicAsync(Func<Task> wasNotNull, Action? wasNull, params object[] items)
        {
            NullCheck(wasNull, items);

            await wasNotNull();
        }

        private static void NullCheck(Action? wasNull, params object[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] is null)
                {
                    wasNull?.Invoke();

                    throw new NullException("Method was called with null parameter(s).");
                }
            }
        }

        #region With more parameters

        internal static T IsNotNull<T>(this (object, object) items, Func<T> wasNotNull, Action? wasNull = null) =>
            IsNotNullFuncLogic(wasNotNull, wasNull, items.Item1, items.Item2);

        internal static T IsNotNull<T>(this (object, object, object) items, Func<T> wasNotNull, Action? wasNull = null) =>
            IsNotNullFuncLogic(wasNotNull, wasNull, items.Item1, items.Item2, items.Item3);

        internal static T IsNotNull<T>(this (object, object, object, object) items, Func<T> wasNotNull, Action? wasNull = null) =>
            IsNotNullFuncLogic(wasNotNull, wasNull, items.Item1, items.Item2, items.Item3, items.Item4);

        internal static void IsNotNull(this (object, object) items, Action wasNotNull, Action? wasNull = null) =>
            IsNotNullActionLogic(wasNotNull, wasNull, items.Item1, items.Item2);

        internal static void IsNotNull(this (object, object, object) items, Action wasNotNull, Action? wasNull = null) =>
            IsNotNullActionLogic(wasNotNull, wasNull, items.Item1, items.Item2, items.Item3);

        internal static void IsNotNull(this (object, object, object, object) items, Action wasNotNull, Action? wasNull = null) =>
            IsNotNullActionLogic(wasNotNull, wasNull, items.Item1, items.Item2, items.Item3, items.Item4);

        internal async static Task<T> IsNotNull<T>(this (object, object) items, Func<Task<T>> wasNotNull, Action? wasNull = null) =>
            await IsNotNullFuncLogicAsync(wasNotNull, wasNull, items.Item1, items.Item2);

        internal async static Task<T> IsNotNull<T>(this (object, object, object) items, Func<Task<T>> wasNotNull, Action? wasNull = null) =>
            await IsNotNullFuncLogicAsync(wasNotNull, wasNull, items.Item1, items.Item2, items.Item3);

        internal async static Task<T> IsNotNull<T>(this (object, object, object, object) items, Func<Task<T>> wasNotNull, Action? wasNull = null) =>
            await IsNotNullFuncLogicAsync(wasNotNull, wasNull, items.Item1, items.Item2, items.Item3, items.Item4);

        internal async static Task IsNotNull(this (object, object) items, Func<Task> wasNotNull, Action? wasNull = null) =>
            await IsNotNullActionLogicAsync(wasNotNull, wasNull, items.Item1, items.Item2);

        internal async static Task IsNotNull(this (object, object, object) items, Func<Task> wasNotNull, Action? wasNull = null) =>
            await IsNotNullActionLogicAsync(wasNotNull, wasNull, items.Item1, items.Item2, items.Item3);

        internal async static Task IsNotNull(this (object, object, object, object) items, Func<Task> wasNotNull, Action? wasNull = null) =>
            await IsNotNullActionLogicAsync(wasNotNull, wasNull, items.Item1, items.Item2, items.Item3, items.Item4);

        #endregion
    }

    internal sealed class NullException : Exception
    {
        internal NullException(string? message) : base(message) { }
    }
}
