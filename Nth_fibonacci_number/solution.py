#Nth fibonacci number 
# Fn = F(n - 1) + F(n - 2)
import unittest;

n = int(input("Enter a number to get its fibonacci equivalent: "))
#Brute force/naive approach 

# def fib(n):
#     if n <= 2:
#         result = 1
#     else: 
#         result = fib(n - 1) + fib(n - 2) #recursion
#     return result

# Time complexity = O[2pow(n)], space complexity is O[n], because height of recursive tree is n - non optimal for higher indexes


#MORE OPTIMAL SOLUTIONS, USING MEMOIZATION AND BOTTOM-UP APPROACH 

#Using memoization and recursion i.e Dynamic programming 
# memo = {}

# def fib(n):
#     if n in memo:
#         return memo[n]
     
#     if n <= 2:
#         result = 1
#     else: 
#         result = fib(n - 1) + fib(n - 2)
    
#     memo[n] = result
#     return result 

# Time complexity = O[n] - Linear 


#using bottom-up approach, more efficient
def fib(n):
    memo = {}

    for i in range(1, n + 1):
        if i <= 2:
            result = 1
        else: 
            result = memo[i - 1] + memo[i - 2]
                   
        memo[i] = result
    return memo[n]

print(fib(n))


class TestFibonacci(unittest.TestCase):

    def test_small_no(self):
        self.assertEqual(fib(5), 5)
    
    def test_larger_no(self):
        self.assertEqual(fib(200), 280571172992510140037611932413038677189525)


if __name__ == '__main__':
    unittest.main()