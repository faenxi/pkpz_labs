#ifndef LABCOURSE_H
#define LABCOURSE_H

#include "Course.h"
#include <string>

class LabCourse : public Course {
private:
    std::string labRoom;

public:
    LabCourse(std::string name = "", int code = 0, std::string labRoom = "");
    void displayCourseInfo() const override;
};

#endif
