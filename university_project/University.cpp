#include "University.h"

University::University(const Rector& rector) : rector(rector) {}

University::~University() {
    for (auto course : courses)
        delete course;
    for (auto student : students)
        delete student;
}

void University::addCourse(Course* course) {
    courses.push_back(course);
}

void University::addStudent(Student* student) {
    students.push_back(student);
}

const std::vector<Course*>& University::getCourses() const {
    return courses;
}

const std::vector<Student*>& University::getStudents() const {
    return students;
}

const Rector& University::getRector() const {
    return rector;
}
