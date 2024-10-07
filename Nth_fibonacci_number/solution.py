#Nth fibonacci number 
# Fn = F(n - 1) + F(n - 2)


n = int(input("Enter a number to get its fibonacci equivalent: "))
#Brute force/naive approach 

# def fib(n):
#     if n <= 2:
#         result = 1
#     else: 
#         result = fib(n - 1) + fib(n - 2) #recursion
#     return result

# print(fib(n))
# Time complexity = o pow(n), non optimal for higher indexes


#MORE OPTIMAL SOLUTIONS, USING MEMOIZATION AND BOTTOM-UP APPROACH 

#Using memoization and recursion i.e Dynamic programming 
memo = {}

def fib(n):
    if n in memo:
        return memo[n]
     
    if n <= 2:
        result = 1
    else: 
        result = fib(n - 1) + fib(n - 2)
    
    memo[n] = result
    return result 

print(fib(n))
# Time complexity = O[n] - Linear 


#using bottom-up approach, more efficient
def fib(n):
    memo = {}

    for i in range(1, n + 1):
        if n <= 2:
            result = 1
        else: 
            result = memo[i - 1] + memo[i - 2]
        
    memo[i] = result
    return memo[n]