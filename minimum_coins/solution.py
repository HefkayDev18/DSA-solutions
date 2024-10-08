#Given a set of coins {c1, c2, ..., ck} and a target sum of money, m. find the minimum no of coins that form m
import unittest

#HELPER FUNCTION
def optimal_answer(a, b):
    if a is None:
        return b
    if b is None:
        return a
    return min(a, b)

#brute force approach 

# def min_no_of_coins(m, coins):
#     if m == 0:
#         answer = 0
#     else: 
#         answer = None
#         for aCoin in coins:
#             difference = m - aCoin
#             if difference < 0: 
#                 continue
#             answer = optimal_answer(answer, min_no_of_coins(difference, coins) + 1)
#     return answer

# Time complexity = O[2pow(n)]


#using memoization 

# memo = {}

# def min_no_of_coins(m, coins):
#     if m in memo:
#         return memo[m]

#     if m == 0:
#         answer = 0
#     else: 
#         answer = None
#         for coin in coins:
#             counter = m - coin
#             if counter >= 0:
#                 answer = optimal_answer(answer, min_no_of_coins(counter, coins) + 1)
#             continue

#     memo[m] = answer
#     return answer
#Time complexity = O[m * n], since there are m(target sum) subproblems/counters which involves checking n coins


#using bottom-up approach

def min_no_of_coins(m, coins):
    memo = {0:0}
    # memo[0] = 0

    for i in range(1, m + 1):
        answer = None
        for aCoin in coins:
            subproblem = i - aCoin
            if subproblem < 0:
                continue
            prev_value = memo.get(subproblem)
            if prev_value is not None:
                if answer is None:
                    answer = prev_value + 1
                else:
                    answer = min(answer, prev_value + 1)
        memo[i] = answer
        #     prev_value = memo.get(subproblem)
        #     if prev_value is not None:
        #         answer = optimal_answer(memo.get(i), prev_value + 1)
        # memo[i] = answer

    return memo[m] if memo[m] is not None else None

print(min_no_of_coins(200, [1, 4, 5]))


class TestMinNoOfCoins(unittest.TestCase):

    def test_base_case(self):
        self.assertEqual(min_no_of_coins(0, [1, 4, 5]), 0)

    def test_single_coin(self):
        self.assertEqual(min_no_of_coins(5, [1, 4, 5]), 1)

    def test_multiple_coins(self):
        self.assertEqual(min_no_of_coins(8, [1, 4, 5]), 2)

    def test_small_no(self):
        self.assertEqual(min_no_of_coins(13, [1, 4, 5]), 3)

    def test_indefinite(self):
        self.assertEqual(min_no_of_coins(5, [2, 6, 8]), None)

    def test_larger_no(self):
        self.assertEqual(min_no_of_coins(200, [1, 4, 5]), 40)
    
if __name__ == '__main__':
    unittest.main()