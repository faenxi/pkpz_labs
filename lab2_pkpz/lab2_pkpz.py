"""

rows = int(input("amount of rows: "))
cols = int(input("amount of columns: "))

arr = []
for i in range(rows):
    row = list(map(int, input("enter array ").split()))
    arr.append(row)

print("Original array:")
for row in arr:
    print(row)

total_sum = sum(sum(row) for row in arr)
total_elements = rows * cols
average = total_sum / total_elements
print("Average:", average)

for i in range(rows):
    for j in range(cols):
        if arr[i][j] < average:
            arr[i][j] = 0

print("Modified array:")
for row in arr:
    print(row)

"""
import random
month_number = 4

def calcul_salary(matrix):
    return sum(sum(row) for row in matrix)

def calcu_salary_by_month(month_number):
    return sum(row[month_number] for row in matrix)


rows, cols = 10, 12 
matrix = [[random.randint(5000, 20000) for _ in range(cols)] for _ in range(rows)]

for row in matrix:
    print(' '.join(f"{num:6}" for num in row))

total_salary = calcul_salary(matrix)
print("total for a year:", total_salary)

total_salary_in_particul_month = calcu_salary_by_month(month_number)
print(f"total for {month_number} mounth : {total_salary_in_particul_month} avarage : {total_salary_in_particul_month / 10}")

