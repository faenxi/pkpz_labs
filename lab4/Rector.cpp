#include "Rector.h"
#include <iostream>

Rector::Rector(std::string name, int age)
    : Person(std::move(name), age) {
}

void Rector::displayInfo() const {
    std::cout << "Rector - ";
    Person::displayInfo();
    std::cout << std::endl;
}
