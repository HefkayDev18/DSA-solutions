#Longest common subsequence between 2 strings using dymamic programming approach
import unittest; 


def Longest_common_subsequence(text1, text2):
    n, m = len(text1), len(text2)
    dp = [[0] * (m  + 1) for _ in range (n + 1)]

    for i in range(1, n + 1):
        for j in range(1, m + 1):
            if text1[i - 1] == text2[j - 1]:
                dp[i][j] = dp[i - 1][j - 1] + 1           
            else: 
                dp[i][j] = max(dp[i - 1][j], dp[i][j - 1])

    i, j = n, m
    sub_seq = ""
    while i > 0 and j > 0:
        if text1[i - 1] == text2[j - 1]:
            sub_seq = text1[i - 1] + sub_seq
            i -= 1
            j -= 1
        elif dp[i - 1][j] > dp[i][j - 1]:
            i -= 1
        else:
            j -= 1

    return f"The longest common subsequence is '{sub_seq}' and the length is '{len(sub_seq)}' "

book1 = "abcde"
book2 = "ace"
print(Longest_common_subsequence(book1, book2))


class TestLongestCommonSubsequence(unittest.TestCase):

    def test_no_common_substring(self):
        result = Longest_common_subsequence("abc", "def")
        expected = "The longest common subsequence is '' and the length is '0'"
        self.assertEqual(result.strip(), expected.strip())
        
    def test_partial_match(self):
        result = Longest_common_subsequence("abcdef", "defabc")
        expected = "The longest common subsequence is 'def' and the length is '3'"
        self.assertEqual(result.strip(), expected.strip())
    
    def test_identicalstrings(self):
        result = Longest_common_subsequence("hello", "hello")
        expected = "The longest common subsequence is 'hello' and the length is '5'"
        self.assertEqual(result.strip(), expected.strip())
    
    def test_edge_case_empty(self):
        result1 = Longest_common_subsequence("", "test")
        result2 = Longest_common_subsequence("test", "")
        expected = "The longest common subsequence is '' and the length is '0'"
        self.assertEqual(result1.strip(), expected.strip())
    
    def test_emptystrings(self):
        result = Longest_common_subsequence("", "")
        expected = "The longest common subsequence is '' and the length is '0'"
        self.assertEqual(result.strip(), expected.strip())

    def single_charMatch(self):
        result = Longest_common_subsequence("a", "a")
        expected = "The longest common subsequence is 'a' and the length is '1'"
        self.assertEqual(result.strip(), expected.strip())

    def test_no_singleCharMatch(self):
        result = Longest_common_subsequence("a", "b")
        expected = "The longest common subsequence is '' and the length is '0'"
        self.assertEqual(result.strip(), expected.strip())

    def test_repeated_characters(self):
        result = Longest_common_subsequence("aaaaaaaaa","aaaa")
        expected = "The longest common subsequence is 'aaaa' and the length is '4'"
        self.assertEqual(result.strip(), expected.strip())

if __name__ == '__main__':
    unittest.main()
