#ifndef RECTOR_H
#define RECTOR_H

#include "Person.h"

class Rector : public Person {
public:
    Rector(std::string name, int age);
    void displayInfo() const override;
};

#endif
