import tkinter as tk
from tkinter import ttk, messagebox, filedialog
import re

class TextProcessorApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Text File Processor")
        self.root.geometry("600x500")
       
        self.create_widgets()
        
    def create_widgets(self):
        
        button_frame = tk.Frame(self.root)
        button_frame.pack(pady=10)
        
        self.create_file_btn = tk.Button(button_frame, text="Create TF_1", 
                                        command=self.create_tf1, width=15)
        self.create_file_btn.pack(side=tk.LEFT, padx=5)
        
        self.process_btn = tk.Button(button_frame, text="Process File", 
                                   command=self.process_file, width=15)
        self.process_btn.pack(side=tk.LEFT, padx=5)
        
        self.show_result_btn = tk.Button(button_frame, text="Show TF_2", 
                                       command=self.show_tf2, width=15)
        self.show_result_btn.pack(side=tk.LEFT, padx=5)
        
        input_label = tk.Label(self.root, text="Enter text for TF_1 file:")
        input_label.pack(anchor="w", padx=20, pady=(10, 0))
        
        self.text_input = tk.Text(self.root, height=5, width=70)
        self.text_input.pack(padx=20, pady=5)
        
        result_frame = tk.Frame(self.root)
        result_frame.pack(fill=tk.BOTH, expand=True, padx=20, pady=10)
        
        output_label = tk.Label(result_frame, text="Result:")
        output_label.pack(anchor="w")
        
        self.text_output = tk.Text(result_frame, height=10, width=70)
        self.text_output.pack(fill=tk.BOTH, expand=True, pady=5)
        
        self.status_bar = tk.Label(self.root, text="Ready to work", 
                                  relief=tk.SUNKEN, anchor=tk.W)
        self.status_bar.pack(fill=tk.X, side=tk.BOTTOM)
    
    def update_status(self, message):
        """Update status bar"""
        self.status_bar.config(text=message)
        self.root.update()
    
    def create_tf1(self):
        """Create TF_1 file with entered text"""
        text = self.text_input.get("1.0", tk.END).strip()
        
        if not text:
            messagebox.showwarning("Warning", "Please enter text!")
            return
        
        try:
            with open("TF_1.txt", "w", encoding="utf-8") as file:
                file.write(text)
            
            self.update_status("TF_1.txt file created successfully")
            messagebox.showinfo("Success", "TF_1.txt file created successfully!")
            
        except Exception as e:
            messagebox.showerror("Error", f"Failed to create file: {e}")
    
    def process_file(self):
        """Process TF_1 file and create TF_2"""
        try:
            with open("TF_1.txt", "r", encoding="utf-8") as file:
                content = file.read()
            
            words = re.findall(r'\b[a-zA-Z0-9]+\b', content)
            
            with open("TF_2.txt", "w", encoding="utf-8") as file:
                for word in words:
                    file.write(word + "\n")
            
            self.update_status("TF_2.txt file created successfully")
            messagebox.showinfo("Success", f"TF_2.txt created!\nWords found: {len(words)}")
            
        except FileNotFoundError:
            messagebox.showerror("Error", "TF_1.txt file not found! Please create it first.")
        except Exception as e:
            messagebox.showerror("Error", f"Failed to process file: {e}")
    
    def show_tf2(self):
        """Display content of TF_2 file"""
        try:
            with open("TF_2.txt", "r", encoding="utf-8") as file:
                content = file.read()
            
            self.text_output.delete("1.0", tk.END)
            self.text_output.insert("1.0", content)
            
            self.update_status("TF_2.txt content displayed")
            
        except FileNotFoundError:
            messagebox.showerror("Error", "TF_2.txt file not found! Please process the file first.")
        except Exception as e:
            messagebox.showerror("Error", f"Failed to read file: {e}")

def main():
    root = tk.Tk()
    app = TextProcessorApp(root)
    root.mainloop()

if __name__ == "__main__":
    main()