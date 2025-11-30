#include "Student.h"

Student::Student() : Person(), studentId(0) {}

Student::Student(std::string name, int age, int id)
    : Person(std::move(name), age), studentId(id) {
}

Student::Student(const Student& other)
    : Person(other), studentId(other.studentId) {
    std::cout << "Student copied: " << name << std::endl;
}

Student::Student(Student&& other) noexcept
    : Person(std::move(other)), studentId(other.studentId) {
    std::cout << "Student moved: " << name << std::endl;
}

Student::~Student() {
    std::cout << "Student " << name << " destroyed." << std::endl;
}

void Student::displayInfo() const {
    Person::displayInfo();
    std::cout << ", Student ID: " << studentId << std::endl;
}

Student& Student::operator=(const Student& other) {
    if (this != &other) {
        Person::operator=(other);
        studentId = other.studentId;
    }
    return *this;
}

Student& Student::operator=(Student&& other) noexcept {
    if (this != &other) {
        Person::operator=(std::move(other));
        studentId = other.studentId;
    }
    return *this;
}

std::ostream& operator<<(std::ostream& os, const Student& student) {
    os << static_cast<const Person&>(student) << ", ID: " << student.studentId;
    return os;
}

std::istream& operator>>(std::istream& is, Student& student) {
    std::cout << "Enter student name, age and ID: ";
    is >> student.name >> student.age >> student.studentId;
    return is;
}
