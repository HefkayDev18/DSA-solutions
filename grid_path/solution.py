#Given an N * M grid, in how many ways can a rabbit move from the top left corner to bottom right corner if he can only 
#right or down
import unittest

def no_of_paths(n, m):
    memo = {}

    #define my base case ( can only move in 1 way along a row or column)
    for i in range(1, n + 1):
        memo[(i, 1)] = 1
    for j in range(1, m + 1):
        memo[(1, j)] = 1

    for i in range(2, n + 1):
        for j in range(2, m + 1):
            memo[(i, j)] = memo[(i - 1, j)] + memo[(i, j - 1)]

    return memo[(n, m)]

print(no_of_paths(18, 6))
#Time complexity is O[n * m]

class TestNoOfPaths(unittest.TestCase):

    def test_base_case(self):
        self.assertEqual(no_of_paths(1, 1), 1)

    def test_single_row(self):
        self.assertEqual(no_of_paths(1, 5), 1)

    def test_single_column(self):
        self.assertEqual(no_of_paths(5, 1), 1)

    def test_small_grid(self):
        self.assertEqual(no_of_paths(2, 2), 2)

    def test_larger_grid(self):
        self.assertEqual(no_of_paths(3, 3), 6)

    def test_larger_grid_different_dimensions(self):
        self.assertEqual(no_of_paths(2, 4), 4)

if __name__ == '__main__':
    unittest.main()