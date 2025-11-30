from typing import Iterable

def capitalize_words(words: Iterable[str]) -> Iterable[str]:
    return map(str.capitalize, words)
words = input("words: ").split()
result = list(capitalize_words(words))
print("result:", result)