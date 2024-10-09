#Longest common subsequence between 2 strings using dynamic programming approach
import unittest;


def longest_possible_substring_dp(text1, text2): #Accepting 2 strings/books to be checked for plagiarism
    n, m = len(text1), len(text2) #we are obtaining the length of both strings, so it could be iterated through
    table = [[0] * (m + 1) for _ in range(n + 1)] #Created a 2D table with 0 as prefilled values for a (n+1) * (m+1) table
    
    max_substring_length = 0 #initialized values to track both the longest substring length and end position
    end_position = 0

    for i in range(1, n + 1): #iterated through each characters in compared strings and increased the length for each match
        for j in range(1, m + 1):
            if text1[i - 1] == text2[j - 1]:
                table[i][j] = table[i - 1][j - 1] + 1
                if table[i][j] > max_substring_length:
                    max_substring_length = table[i][j]
                    end_position = i

    return text1[end_position - max_substring_length:end_position] #returned the longest common substring 

book1_content = "This is the content of book one."
book2_content = "This book has similar content."
print(longest_possible_substring_dp(book1_content, book2_content))

#The time complexity and space complexity is O[n*m]

class TestLongestCommonSubstring(unittest.TestCase):

    def test_no_common_substring(self):
        self.assertEqual(longest_possible_substring_dp("abc", "def"), "")

    def test_partial_match(self):
        self.assertEqual(longest_possible_substring_dp("abcdef", "defabc"), "abc")
    
    def test_identicalstrings(self):
        self.assertEqual(longest_possible_substring_dp("hello", "hello"), "hello")
    
    def test_edge_case_empty(self):
        self.assertEqual(longest_possible_substring_dp("", "test"), "")
        self.assertEqual(longest_possible_substring_dp("test", ""), "")
    
    def test_emptystrings(self):
        self.assertEqual(longest_possible_substring_dp("",""), "")

    def single_charMatch(self):
        self.assertEqual(longest_possible_substring_dp("a","a"), "a")

    def test_no_singleCharMatch(self):
        self.assertEqual(longest_possible_substring_dp("a", "b"), "")

    def test_repeated_characters(self):
        self.assertEqual(longest_possible_substring_dp("aaaaaaaaa","aaaa"), "aaaa")
    
if __name__ == '__main__':
    unittest.main()