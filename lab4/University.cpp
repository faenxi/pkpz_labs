#include "University.h"
#include <iostream>

University::University(const Rector& rector)
    : rector(rector) {
}

University::~University() {
    for (auto c : courses)
        delete c;
}

void University::enrollStudent(const Student& student) {
    students.push_back(student);
}

void University::addCourse(Course* course) {
    courses.push_back(course);
}

void University::showStudents() const {
    for (const auto& s : students)
        s.displayInfo();
}

void University::showCourses() const {
    for (const auto& c : courses)
        c->displayCourseInfo();
}

void University::showRector() const {
    rector.displayInfo();
}
