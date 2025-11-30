class University {
private:
    std::vector<Student> students;
    std::vector<Course*> courses;
    Rector rector;

public:
    University(const Rector& rector);
    ~University();

    void enrollStudent(const Student& student);
    void addCourse(Course* course);

    void showStudents() const;
    void showCourses() const;
    void showRector() const;
};
