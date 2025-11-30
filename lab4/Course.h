#ifndef COURSE_H
#define COURSE_H

#include <string>
#include <iostream>

class Course {
protected:
    std::string courseName;
    int courseCode;

public:
    Course(std::string name = "", int code = 0);
    virtual ~Course();

    virtual void displayCourseInfo() const;
};

#endif
