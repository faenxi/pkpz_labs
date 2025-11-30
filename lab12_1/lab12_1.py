def sort_by_age(people: list[dict]) -> list[dict]:
    return sorted(people, key=lambda person: person["age"])

people = []
while True:
    name = input("name or stop: ")
    if name.lower() == 'stop':
        break
    age = int(input("age: "))
    people.append({"name": name, "age": age})
result = sort_by_age(people)
print("sorted:")
for person in result:
    print(f"{person['name']}: {person['age']}")
