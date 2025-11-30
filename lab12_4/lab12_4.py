def has_uppercase(password: str) -> bool:
    return any(char.isupper() for char in password)

def has_digit(password: str) -> bool:
    return any(char.isdigit() for char in password)

def is_long_enough(password: str) -> bool:
    return len(password) >= 8

def has_special_char(password: str) -> bool:
    special_chars = "!@#$%^&*()"
    return any(char in special_chars for char in password)

def no_spaces(password: str) -> bool:
    return ' ' not in password

def validate_password(password: str) -> bool:
    rules = [has_uppercase, has_digit, is_long_enough, has_special_char, no_spaces]
    return all(rule(password) for rule in rules)

password = input("enter password: ")

result = validate_password(password)
print("true or false:", result)