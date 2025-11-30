#ifndef LABCOURSE_H
#define LABCOURSE_H

#include "Course.h"

class LabCourse final : public Course {
private:
    std::string labRoom;

public:
    LabCourse(std::string name = "", int code = 0, std::string labRoom = "");
    void displayCourseInfo() const override;
    std::string getCourseType() const override;
    void courseDetails() const override;
};

#endif
