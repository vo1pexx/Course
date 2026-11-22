public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        // Бінарний пошук виконуємо по меншому масиву
        if (nums1.Length > nums2.Length)
            return FindMedianSortedArrays(nums2, nums1);

        int m = nums1.Length;
        int n = nums2.Length;
        int half = (m + n + 1) / 2; // розмір лівої половини об'єднаного масиву

        int low = 0;
        int high = m;

        while (low <= high) {
            // i елементів беремо з nums1, j - з nums2 у ліву половину
            int i = (low + high) / 2;
            int j = half - i;

            int left1  = i == 0 ? int.MinValue : nums1[i - 1];
            int right1 = i == m ? int.MaxValue : nums1[i];
            int left2  = j == 0 ? int.MinValue : nums2[j - 1];
            int right2 = j == n ? int.MaxValue : nums2[j];

            if (left1 <= right2 && left2 <= right1) {
                // Знайшли правильний поділ
                if ((m + n) % 2 == 1)
                    return System.Math.Max(left1, left2);

                return (System.Math.Max(left1, left2) + System.Math.Min(right1, right2)) / 2.0;
            }

            if (left1 > right2)
                high = i - 1; // з nums1 узято забагато
            else
                low = i + 1;  // з nums1 узято замало
        }

        // Для коректних (відсортованих) вхідних даних сюди не потрапляємо
        return 0.0;
    }
}