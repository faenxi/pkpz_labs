#include "University.h"
#include "LabCourse.h"
#include <iostream>

int main() {
    Rector rector("Prof. Dumbledore", 120);
    University uni(rector);

    Student s1("Anya", 20, 22309234);
    Student s2("Ivan", 19, 35894584);

    Course* c1 = new Course("Mathematics", 301);
    Course* c2 = new LabCourse("Physics Lab", 302, "Lab A");

    uni.enrollStudent(s1);
    uni.enrollStudent(s2);

    uni.addCourse(c1);
    uni.addCourse(c2);

    std::cout << "\nRector:\n";
    uni.showRector();

    std::cout << "\nStudents:\n";
    uni.showStudents();

    std::cout << "\nCourses:\n";
    uni.showCourses();

    return 0;
}