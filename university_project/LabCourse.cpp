#include "LabCourse.h"
#include <iostream>

LabCourse::LabCourse(const std::string& name, int credits, const std::string& labRoom)
    : Course(name, credits), labRoom(labRoom) {
}

LabCourse::~LabCourse() {}

void LabCourse::printDetails() const {
    std::cout << "Lab Course: " << name << ", Credits: " << credits
        << ", Lab Room: " << labRoom << std::endl;
}

std::string LabCourse::getCourseType() const {
    return "Lab Course";
}

LabCourse::LabCourse(const LabCourse& other)
    : Course(other), labRoom(other.labRoom) {
}

LabCourse& LabCourse::operator=(const LabCourse& other) {
    if (this != &other) {
        Course::operator=(other);
        labRoom = other.labRoom;
    }
    return *this;
}

LabCourse::LabCourse(LabCourse&& other) noexcept
    : Course(std::move(other)), labRoom(std::move(other.labRoom)) {
}

LabCourse& LabCourse::operator=(LabCourse&& other) noexcept {
    if (this != &other) {
        Course::operator=(std::move(other));
        labRoom = std::move(other.labRoom);
    }
    return *this;
}
