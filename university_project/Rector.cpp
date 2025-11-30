#include "Rector.h"

Rector::Rector(const std::string& name) : name(name) {}
Rector::~Rector() {}

std::string Rector::getName() const {
    return name;
}
