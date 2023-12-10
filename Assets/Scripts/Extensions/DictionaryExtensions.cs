using System.Collections.Generic;

public static class DictionaryExtensions {
    public static void AddOrCreate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value) {
        if (dictionary.ContainsKey(key)) {
            dictionary[key] = value;
        }
        else {
            dictionary.Add(key, value);
        }
    }

    public static void AddOrCreate<TKey, TValue>(this Dictionary<TKey, List<TValue>> dictionary, TKey key, TValue value) {
        if (dictionary.ContainsKey(key)) {
            dictionary[key].Add(value);
        }
        else {
            dictionary.Add(key, new List<TValue> { value });
        }
    }
}
