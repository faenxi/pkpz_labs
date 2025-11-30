#include "Course.h"

Course::Course(std::string name, int code)
    : courseName(std::move(name)), courseCode(code) {
}

Course::~Course() {}

void Course::displayCourseInfo() const {
    std::cout << "Course: " << courseName << ", Code: " << courseCode;
}
