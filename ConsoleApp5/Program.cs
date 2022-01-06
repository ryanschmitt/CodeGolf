int[] test = { 1, 2, 3, 1 };
var isDups = new Solution().ContainsDuplicate(test);

var s = "anagram";
var t = "nagaram";
var isAnagram = new Solution().IsAnagram3(s, t);

Console.WriteLine($"isDups={isDups}");
Console.WriteLine($"isAnagram={isAnagram}");


public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        return new HashSet<int>(nums).Count != nums.Length;
    }

    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var ch1 = s.ToCharArray();
        var ch2 = t.ToCharArray();

        Array.Sort(ch1);
        Array.Sort(ch2);

        return ch1.SequenceEqual(ch2);
    }

    public bool IsAnagram2(string s, string t)
    {
        int[] sFreq = new int[26];
        int[] tFreq = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            sFreq[s[i] - 'a']++;
        }

        for (int i = 0; i < t.Length; i++)
        {
            tFreq[t[i] - 'a']++;
        }

        for (int i = 0; i < sFreq.Length; i++)
        {
            if (sFreq[i] != tFreq[i])
            {
                return false;
            }
        }
        return true;
    }

    public bool IsAnagram3(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (!dict.ContainsKey(s[i]))
                dict.Add(s[i], 1);
            else
                dict[s[i]]++;
        }

        for (int j = 0; j < t.Length; j++)
        {
            if (!dict.ContainsKey(t[j]) || --dict[t[j]] < 0)  //--dict[t[j]] < 0
                return false;
        }

        return true;
    }

}