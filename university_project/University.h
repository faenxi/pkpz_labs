#pragma once
#include "Course.h"
#include "Student.h"
#include "Rector.h"
#include <vector>

class University {
private:
    std::vector<Course*> courses;
    std::vector<Student*> students;
    Rector rector;

public:
    University(const Rector& rector);
    ~University();

    void addCourse(Course* course);
    void addStudent(Student* student);

    const std::vector<Course*>& getCourses() const;
    const std::vector<Student*>& getStudents() const;

    const Rector& getRector() const;

    University(const University& other) = delete;
    University& operator=(const University& other) = delete;
    University(University&& other) noexcept = default;
    University& operator=(University&& other) noexcept = default;
};
