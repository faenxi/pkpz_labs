#include "LabCourse.h"
#include <iostream>

LabCourse::LabCourse(std::string name, int code, std::string labRoom)
    : Course(std::move(name), code), labRoom(std::move(labRoom)) {
}

void LabCourse::displayCourseInfo() const {
    Course::displayCourseInfo();
    std::cout << ", Lab Room: " << labRoom << std::endl;
}
