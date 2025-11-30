#pragma once
#include <string>

class Course {
private:
    std::string name;   // ����� �����
    std::string code;   // ��� �����
    int credits;        // ʳ������ �������

public:
    // ����������� �����
    Course(const std::string& courseName, const std::string& courseCode, int courseCredits)
        : name(courseName), code(courseCode), credits(courseCredits) {
    }

    // ������ ��� ��������� ����� �����
    std::string getCode() const { return code; }
    std::string getName() const { return name; }
    int getCredits() const { return credits; }
};