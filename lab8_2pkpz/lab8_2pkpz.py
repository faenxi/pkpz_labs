import tkinter as tk
from tkinter import ttk, messagebox
from collections import namedtuple
import random

Pupil = namedtuple('Pupil', ['surname', 'age', 'grade', 'address'])

class PupilApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Student Performance Analysis")
        self.root.geometry("800x600")
        
        self.pupils_data = [
            Pupil("Ivanenko", 15, 85, "Shevchenko St, 12"),
            Pupil("Petrenko", 16, 92, "Franko St, 25"),
            Pupil("Sydorenko", 14, 78, "Lesya Ukrainka St, 8"),
            Pupil("Kovalenko", 15, 88, "Hrushevskyi St, 15"),
            Pupil("Shevchenko", 16, 95, "Khreshchatyk St, 42"),
            Pupil("Bondarenko", 14, 82, "Saksahanskoho St, 30"),
            Pupil("Tkachenko", 15, 90, "Lysenko St, 5")
        ]
        
        self.create_widgets()
        self.display_pupils()
    
    def create_widgets(self):
        main_frame = ttk.Frame(self.root, padding="10")
        main_frame.grid(row=0, column=0, sticky=(tk.W, tk.E, tk.N, tk.S))
        
        title_label = ttk.Label(main_frame, text="Student List", font=('Arial', 14, 'bold'))
        title_label.grid(row=0, column=0, columnspan=5, pady=(0, 10))
        
        columns = ('surname', 'age', 'grade', 'address')
        self.tree = ttk.Treeview(main_frame, columns=columns, show='headings', height=10)
        
        self.tree.heading('surname', text='Surname')
        self.tree.heading('age', text='Age')
        self.tree.heading('grade', text='Grade')
        self.tree.heading('address', text='Address')
        
        self.tree.column('surname', width=120)
        self.tree.column('age', width=80)
        self.tree.column('grade', width=80)
        self.tree.column('address', width=200)
        
        self.tree.grid(row=1, column=0, columnspan=5, pady=(0, 10), sticky=(tk.W, tk.E))
        
        button_frame = ttk.Frame(main_frame)
        button_frame.grid(row=2, column=0, columnspan=5, pady=10)
        
        ttk.Button(button_frame, text="Find Good Students", 
                  command=self.show_good_pupils).pack(side=tk.LEFT, padx=5)
        
        ttk.Button(button_frame, text="Update Grades", 
                  command=self.update_grades).pack(side=tk.LEFT, padx=5)
        
        ttk.Button(button_frame, text="Add Random Student", 
                  command=self.add_random_pupil).pack(side=tk.LEFT, padx=5)
        
        ttk.Button(button_frame, text="Clear List", 
                  command=self.clear_pupils).pack(side=tk.LEFT, padx=5)
        
        self.result_text = tk.Text(main_frame, height=8, width=70)
        self.result_text.grid(row=3, column=0, columnspan=5, pady=10, sticky=(tk.W, tk.E))
        
        self.root.columnconfigure(0, weight=1)
        self.root.rowconfigure(0, weight=1)
        main_frame.columnconfigure(0, weight=1)
        main_frame.rowconfigure(3, weight=1)
    
    def display_pupils(self):
        for item in self.tree.get_children():
            self.tree.delete(item)

        for pupil in self.pupils_data:
            self.tree.insert('', tk.END, values=pupil)
    
    def calculate_average_grade(self):
        if not self.pupils_data:
            return 0
        total = sum(pupil.grade for pupil in self.pupils_data)
        return total / len(self.pupils_data)
    
    def good_pupils(self):
        if not self.pupils_data:
            return []
        
        average_grade = self.calculate_average_grade()
        good_pupils_list = [pupil for pupil in self.pupils_data if pupil.grade >= average_grade]
        
        return good_pupils_list, average_grade
    
    def show_good_pupils(self):
        good_pupils_list, average_grade = self.good_pupils()
        
        self.result_text.delete(1.0, tk.END)
        
        if not good_pupils_list:
            self.result_text.insert(tk.END, "No students for analysis.")
            return
        
        surnames = [pupil.surname for pupil in good_pupils_list]
        surnames_text = ", ".join(surnames)
        
        result_message = f"Average grade: {average_grade:.2f}\n\n"
        result_message += f"Students {surnames_text} are doing well this semester!\n\n"
        result_message += f"Number of good students: {len(good_pupils_list)} out of {len(self.pupils_data)}"
        
        self.result_text.insert(tk.END, result_message)
    
    def update_grades(self):
        if not self.pupils_data:
            messagebox.showwarning("Warning", "No students to update grades.")
            return
        
        updated_pupils = []
        for pupil in self.pupils_data:
            new_grade = min(100, pupil.grade + random.randint(1, 5))
            updated_pupil = pupil._replace(grade=new_grade)
            updated_pupils.append(updated_pupil)
        
        self.pupils_data = updated_pupils
        self.display_pupils()
        
        self.result_text.delete(1.0, tk.END)
        self.result_text.insert(tk.END, "Student grades updated!\n")
        self.show_good_pupils()
    
    def add_random_pupil(self):
        surnames = ["Melnyk", "Koval", "Boyko", "Lysenko", "Gonchar", "Savenko", "Pavlenko"]
        addresses = ["Victory Ave, 10", "Soborna St, 15", "Constitution Sq, 3", 
                    "Naberezhna St, 22", "Taras Shevchenko Blvd, 7"]
        
        new_pupil = Pupil(
            surname=random.choice(surnames),
            age=random.randint(14, 17),
            grade=random.randint(75, 98),
            address=random.choice(addresses)
        )
        
        self.pupils_data.append(new_pupil)
        self.display_pupils()
        messagebox.showinfo("Information", f"Added new student: {new_pupil.surname}")
    
    def clear_pupils(self):
        if messagebox.askyesno("Confirmation", "Delete all students?"):
            self.pupils_data = []
            self.display_pupils()
            self.result_text.delete(1.0, tk.END)

def main():
    root = tk.Tk()
    app = PupilApp(root)
    root.mainloop()

if __name__ == "__main__":
    main()