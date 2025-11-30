# Завдання 1.1: Парні числа та спискові вирази
def filter_even_numbers(nums: list[int]) -> list[int]:
    return [num for num in nums if num % 2 == 0]

# Завдання 1.2: Ітератор зворотного відліку
class Countdown:
    def __init__(self, start: int):
        self.current = max(0, start) 
    
    def __iter__(self):
        return self
    
    def __next__(self):
        if self.current < 0:
            raise StopIteration
        value = self.current
        self.current -= 1
        return value

# Завдання 1.3: Генератор діапазону з плаваючою крапкою
from typing import Iterator

def float_range(start: float, stop: float, step: float) -> Iterator[float]:
    if step == 0:
        raise ValueError("Step cannot be zero")
    
    current = start
    if step > 0:
        while current < stop:
            yield round(current, 10)
            current += step
    else:
        while current > stop:
            yield round(current, 10)
            current += step

# Завдання 1.4: Рекурсивний обхід дерева
def walk_tree(data: dict) -> Iterator[str]:
    for key, value in data.items():
        yield key
        if isinstance(value, dict):
            yield from walk_tree(value)

if __name__ == "__main__":
    print("1.1:")
    print(filter_even_numbers([1, 2, 3, 4, 5, 8, 12])) 
    
    print("\n 1.2:")
    for n in Countdown(5):
        print(n, end=' ')
    print()
    
    print(list(Countdown(3))) 
    print(list(Countdown(0)))  
    print(list(Countdown(-3)))
    
    print("\n 1.3:")
    print(list(float_range(1.0, 2.0, 0.3)))  
    print(list(float_range(5.0, 3.0, -0.5))) 
    print(list(float_range(0.0, 1.0, 0.1))[:3])  
    print(list(float_range(0.0, 0.0, 1.0)))   
    print(list(float_range(1.0, 2.0, -1.0))) 
    
    print("\n 1.4:")
    tree1 = {'a': {'b': {'c': 1}}, 'd': 2}
    print(list(walk_tree(tree1)))  
    
    tree2 = {'x': {'y': {'z': {}}}, 'm': {'n': 42}}
    print(list(walk_tree(tree2))) 
