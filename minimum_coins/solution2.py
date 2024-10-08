#find how many ways the target sum can be formed
from collections import defaultdict

def sum_possibility_ways(m, coins):
    memo = defaultdict(lambda _: 0)
    memo[0]= 1

    for i in range(1, m + 1):
        memo[i] = 0
        for aCoin in coins:
            subproblem = i - aCoin
            if subproblem < 0:
                continue
            memo[i] = memo[i] + memo[subproblem]

    return memo[m]

print(sum_possibility_ways(5, [1, 4, 5]))
#Time complexity = O[n * m]