#ifndef PERSON_H
#define PERSON_H

#include <string>
#include <iostream>

class Person {
protected:
    std::string name;
    int age;

public:
    Person(std::string name = "Unknown", int age = 0);
    virtual ~Person();

    virtual void displayInfo() const;

    Person& operator=(const Person& other);
    Person& operator=(Person&& other) noexcept;

    friend std::ostream& operator<<(std::ostream& os, const Person& person);
};

#endif
