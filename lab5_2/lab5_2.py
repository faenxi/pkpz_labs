import tkinter as tk
from tkinter import ttk
import sys

class Person:
    def __init__(self, name="", age=0, gender=""):
        self.name = name
        self.age = age
        self.gender = gender
    
    def __del__(self):
        print("lab work bykova polya")
    
    def get_role(self):
        return "Person"
    
    def show(self):
        return f"Name: {self.name}\nAge: {self.age}\nGender: {self.gender}"

class Student(Person):
    def __init__(self, name="", age=0, gender="", student_id="", major="", grade=0):
        super().__init__(name, age, gender)
        self.student_id = student_id
        self.major = major
        self.grade = grade
    
    def get_role(self):
        return "Student"
    
    def show(self):
        return f"{super().show()}\nStudent ID: {self.student_id}\nMajor: {self.major}\nGrade: {self.grade}"

class Teacher(Person):
    def __init__(self, name="", age=0, gender="", teacher_id="", department="", salary=0):
        super().__init__(name, age, gender)
        self.teacher_id = teacher_id
        self.department = department
        self.salary = salary
    
    def get_role(self):
        return "Teacher"
    
    def show(self):
        return f"{super().show()}\nTeacher ID: {self.teacher_id}\nDepartment: {self.department}\nSalary: {self.salary}"

class DepartmentHead(Teacher):
    def __init__(self, name="", age=0, gender="", teacher_id="", department="", salary=0, management_years=0):
        super().__init__(name, age, gender, teacher_id, department, salary)
        self.management_years = management_years
    
    def get_role(self):
        return "Department Head"
    
    def show(self):
        return f"{super().show()}\nManagement Years: {self.management_years}"

class UniversityApp:
    def __init__(self, root):
        self.root = root
        self.root.title("University Management System")
        
        main_frame = ttk.Frame(root, padding="10")
        main_frame.grid(row=0, column=0, sticky=(tk.W, tk.E, tk.N, tk.S))
        
        ttk.Label(main_frame, text="Select Person Type:").grid(row=0, column=0, sticky=tk.W, pady=5)
        self.person_type = tk.StringVar()
        person_combo = ttk.Combobox(main_frame, textvariable=self.person_type, 
                                   values=["Student", "Teacher", "Department Head"])
        person_combo.grid(row=0, column=1, sticky=(tk.W, tk.E), pady=5)
        person_combo.bind('<<ComboboxSelected>>', self.on_person_type_change)
        
        self.common_fields = {}
        fields = [("Name", "name"), ("Age", "age"), ("Gender", "gender")]
        for i, (label, key) in enumerate(fields):
            ttk.Label(main_frame, text=f"{label}:").grid(row=i+1, column=0, sticky=tk.W, pady=2)
            entry = ttk.Entry(main_frame)
            entry.grid(row=i+1, column=1, sticky=(tk.W, tk.E), pady=2)
            self.common_fields[key] = entry
        
        self.specific_frame = ttk.Frame(main_frame)
        self.specific_frame.grid(row=4, column=0, columnspan=2, sticky=(tk.W, tk.E), pady=5)
        self.specific_fields = {}
        
        self.create_btn = ttk.Button(main_frame, text="Create Person", command=self.create_person)
        self.create_btn.grid(row=5, column=0, columnspan=2, pady=10)
        
        self.results_text = tk.Text(main_frame, height=10, width=50)
        self.results_text.grid(row=6, column=0, columnspan=2, sticky=(tk.W, tk.E), pady=5)
        
        root.columnconfigure(0, weight=1)
        root.rowconfigure(0, weight=1)
        main_frame.columnconfigure(1, weight=1)
    
    def on_person_type_change(self, event):
        for widget in self.specific_frame.winfo_children():
            widget.destroy()
        self.specific_fields.clear()
        
        person_type = self.person_type.get()
        fields = []
        
        if person_type == "Student":
            fields = [("Student ID", "student_id"), ("Major", "major"), ("Grade", "grade")]
        elif person_type == "Teacher":
            fields = [("Teacher ID", "teacher_id"), ("Department", "department"), ("Salary", "salary")]
        elif person_type == "Department Head":
            fields = [("Teacher ID", "teacher_id"), ("Department", "department"), 
                     ("Salary", "salary"), ("Management Years", "management_years")]
        
        for i, (label, key) in enumerate(fields):
            ttk.Label(self.specific_frame, text=f"{label}:").grid(row=i, column=0, sticky=tk.W, pady=2)
            entry = ttk.Entry(self.specific_frame)
            entry.grid(row=i, column=1, sticky=(tk.W, tk.E), pady=2)
            self.specific_fields[key] = entry
        
        self.specific_frame.columnconfigure(1, weight=1)
    
    def create_person(self):
        try:
            person_type = self.person_type.get()
            if not person_type:
                self.show_message("Please select a person type!")
                return
            
            name = self.common_fields['name'].get()
            age = int(self.common_fields['age'].get()) if self.common_fields['age'].get() else 0
            gender = self.common_fields['gender'].get()
            
            if person_type == "Student":
                student_id = self.specific_fields['student_id'].get()
                major = self.specific_fields['major'].get()
                grade = float(self.specific_fields['grade'].get()) if self.specific_fields['grade'].get() else 0
                person = Student(name, age, gender, student_id, major, grade)
            
            elif person_type == "Teacher":
                teacher_id = self.specific_fields['teacher_id'].get()
                department = self.specific_fields['department'].get()
                salary = float(self.specific_fields['salary'].get()) if self.specific_fields['salary'].get() else 0
                person = Teacher(name, age, gender, teacher_id, department, salary)
            
            elif person_type == "Department Head":
                teacher_id = self.specific_fields['teacher_id'].get()
                department = self.specific_fields['department'].get()
                salary = float(self.specific_fields['salary'].get()) if self.specific_fields['salary'].get() else 0
                management_years = int(self.specific_fields['management_years'].get()) if self.specific_fields['management_years'].get() else 0
                person = DepartmentHead(name, age, gender, teacher_id, department, salary, management_years)
            
            result = f"Created {person_type}:\n"
            result += person.show()
            result += f"\nRole: {person.get_role()}\n"
            result += "-" * 50 + "\n"
            
            self.results_text.insert(tk.END, result)
            self.results_text.see(tk.END)
            
            self.clear_fields()
            
        except ValueError as e:
            self.show_message("Please enter valid numeric values for age/grade/salary!")
        except Exception as e:
            self.show_message(f"Error: {str(e)}")
    
    def clear_fields(self):
        for entry in self.common_fields.values():
            entry.delete(0, tk.END)
        for entry in self.specific_fields.values():
            entry.delete(0, tk.END)
    
    def show_message(self, message):
        self.results_text.insert(tk.END, f"{message}\n")
        self.results_text.see(tk.END)

if __name__ == "__main__":
    root = tk.Tk()
    app = UniversityApp(root)
    root.mainloop()