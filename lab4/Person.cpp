#include "Person.h"

Person::Person(std::string name, int age) : name(std::move(name)), age(age) {}

Person::~Person() {}

void Person::displayInfo() const {
    std::cout << "Name: " << name << ", Age: " << age;
}

Person& Person::operator=(const Person& other) {
    if (this != &other) {
        name = other.name;
        age = other.age;
    }
    return *this;
}

Person& Person::operator=(Person&& other) noexcept {
    if (this != &other) {
        name = std::move(other.name);
        age = other.age;
    }
    return *this;
}

std::ostream& operator<<(std::ostream& os, const Person& person) {
    os << "Name: " << person.name << ", Age: " << person.age;
    return os;
}
