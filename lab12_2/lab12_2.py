def filter_long_words(words: list[str]) -> list[str]:
    return list(filter(lambda word: len(word) > 3, words))

words = input("words: ").split()
result = filter_long_words(words)
print("result:", result)