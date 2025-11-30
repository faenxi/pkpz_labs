import tkinter as tk
from tkinter import ttk, messagebox
from abc import ABC, abstractmethod
from datetime import datetime

class Animal(ABC):
    def __init__(self, name, vet_visits=None):
        self.name = name
        self.vet_visits = vet_visits if vet_visits else []
    
    @abstractmethod
    def make_sound(self):
        pass
    
    @abstractmethod
    def get_species(self):
        pass
    
    def add_vet_visit(self, date):
        self.vet_visits.append(date)
    
    def get_info(self):
        visits = ", ".join(self.vet_visits) if self.vet_visits else "no visits"
        return f"{self.get_species()} {self.name}, Sound: {self.make_sound()}, Vet visits: {visits}"

class Cat(Animal):
    def make_sound(self):
        return "Meow-meow"
    
    def get_species(self):
        return "Cat"
    
    def purr(self):
        return f"{self.name} is purring"

class Dog(Animal):
    def make_sound(self):
        return "Woof-woof"
    
    def get_species(self):
        return "Dog"
    
    def fetch(self):
        return f"{self.name} fetches a stick"

class AnimalApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Veterinary Clinic")
        self.animals = []
        
        self.create_widgets()
    
    def create_widgets(self):
        # Data input
        input_frame = ttk.LabelFrame(self.root, text="Add Animal")
        input_frame.grid(row=0, column=0, padx=10, pady=10, sticky="ew")
        
        ttk.Label(input_frame, text="Name:").grid(row=0, column=0, padx=5, pady=5)
        self.name_entry = ttk.Entry(input_frame)
        self.name_entry.grid(row=0, column=1, padx=5, pady=5)
        
        ttk.Label(input_frame, text="Type:").grid(row=1, column=0, padx=5, pady=5)
        self.animal_type = ttk.Combobox(input_frame, values=["Cat", "Dog"])
        self.animal_type.grid(row=1, column=1, padx=5, pady=5)
        
        ttk.Label(input_frame, text="Visit date (yyyy-mm-dd):").grid(row=2, column=0, padx=5, pady=5)
        self.date_entry = ttk.Entry(input_frame)
        self.date_entry.grid(row=2, column=1, padx=5, pady=5)
        
        ttk.Button(input_frame, text="Add Animal", command=self.add_animal).grid(row=3, column=0, columnspan=2, pady=10)
        
        # Search
        search_frame = ttk.LabelFrame(self.root, text="Search by Date")
        search_frame.grid(row=1, column=0, padx=10, pady=10, sticky="ew")
        
        ttk.Label(search_frame, text="Search date (yyyy-mm-dd):").grid(row=0, column=0, padx=5, pady=5)
        self.search_date_entry = ttk.Entry(search_frame)
        self.search_date_entry.grid(row=0, column=1, padx=5, pady=5)
        
        ttk.Button(search_frame, text="Search", command=self.search_animals).grid(row=0, column=2, padx=5, pady=5)
        
        # Results output
        output_frame = ttk.LabelFrame(self.root, text="Results")
        output_frame.grid(row=2, column=0, padx=10, pady=10, sticky="nsew")
        
        self.output_text = tk.Text(output_frame, height=15, width=60)
        self.output_text.grid(row=0, column=0, padx=5, pady=5)
        
        scrollbar = ttk.Scrollbar(output_frame, orient="vertical", command=self.output_text.yview)
        scrollbar.grid(row=0, column=1, sticky="ns")
        self.output_text.configure(yscrollcommand=scrollbar.set)
        
        ttk.Button(self.root, text="Show All Animals", command=self.show_all_animals).grid(row=3, column=0, pady=10)
    
    def add_animal(self):
        name = self.name_entry.get()
        animal_type = self.animal_type.get()
        date = self.date_entry.get()
        
        if not name or not animal_type or not date:
            messagebox.showerror("Error", "Please fill in all fields")
            return
        
        try:
            datetime.strptime(date, "%Y-%m-%d")
        except ValueError:
            messagebox.showerror("Error", "Invalid date format. Use yyyy-mm-dd")
            return
        
        if animal_type == "Cat":
            animal = Cat(name)
        else:
            animal = Dog(name)
        
        animal.add_vet_visit(date)
        self.animals.append(animal)
        
        self.name_entry.delete(0, tk.END)
        self.date_entry.delete(0, tk.END)
        messagebox.showinfo("Success", f"{animal_type} {name} added successfully!")
    
    def show_all_animals(self):
        self.output_text.delete(1.0, tk.END)
        if not self.animals:
            self.output_text.insert(tk.END, "No animals in database")
            return
        
        for animal in self.animals:
            self.output_text.insert(tk.END, animal.get_info() + "\n\n")
    
    def search_animals(self):
        search_date = self.search_date_entry.get()
        
        if not search_date:
            messagebox.showerror("Error", "Please enter a search date")
            return
        
        try:
            datetime.strptime(search_date, "%Y-%m-%d")
        except ValueError:
            messagebox.showerror("Error", "Invalid date format. Use yyyy-mm-dd")
            return
        
        self.output_text.delete(1.0, tk.END)
        found_animals = [animal for animal in self.animals if search_date in animal.vet_visits]
        
        if not found_animals:
            self.output_text.insert(tk.END, f"No animals found that visited the clinic on {search_date}")
            return
        
        self.output_text.insert(tk.END, f"Animals that visited the clinic on {search_date}:\n\n")
        for animal in found_animals:
            self.output_text.insert(tk.END, animal.get_info() + "\n\n")

if __name__ == "__main__":
    root = tk.Tk()
    app = AnimalApp(root)
    root.mainloop()