public class Solution {
    public int LengthOfLongestSubstring(string s) {
        // lastSeen[c] - індекс, на якому символ c зустрічався востаннє (-1, якщо ще ні)
        var lastSeen = new int[256];
        System.Array.Fill(lastSeen, -1);

        int best = 0;
        int left = 0; // початок поточного вікна без повторів

        for (int right = 0; right < s.Length; right++) {
            char c = s[right];

            // Якщо символ уже є у вікні, пересуваємо ліву межу за його попередню позицію
            if (lastSeen[c] >= left)
                left = lastSeen[c] + 1;

            lastSeen[c] = right;
            best = System.Math.Max(best, right - left + 1);
        }

        return best;
    }
}