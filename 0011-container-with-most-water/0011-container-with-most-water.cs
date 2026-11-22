public class Solution {
    public int MaxArea(int[] height) {
        int left = 0;
        int right = height.Length - 1;
        int best = 0;

        while (left < right) {
            int width = right - left;
            int h = System.Math.Min(height[left], height[right]);
            best = System.Math.Max(best, width * h);

            // Пересуваємо вказівник на нижчій лінії
            if (height[left] < height[right])
                left++;
            else
                right--;
        }

        return best;
    }
}