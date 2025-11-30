import tkinter as tk
from tkinter import messagebox
from datetime import datetime, timedelta

class MobilePackageApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Mobile Package Expiry Calculator")
        self.root.geometry("450x250")
        
        self.create_widgets()

    def create_widgets(self):
        title_label = tk.Label(self.root, text="Mobile Package Expiry Calculation",
                                 font=("Arial", 14, "bold"))
        title_label.pack(pady=15)
        
        date_frame = tk.Frame(self.root)
        date_frame.pack(pady=8)
        
        date_label = tk.Label(date_frame, text="Last call date (DDMMYYYY):", font=("Arial", 10))
        date_label.pack(side=tk.LEFT, padx=5)
        
        self.date_entry = tk.Entry(date_frame, width=15, font=("Arial", 10))
        self.date_entry.pack(side=tk.LEFT, padx=5)
        
        time_frame = tk.Frame(self.root)
        time_frame.pack(pady=8)
        
        time_label = tk.Label(time_frame, text="Last call time (HH:MM:SS):", font=("Arial", 10))
        time_label.pack(side=tk.LEFT, padx=5)
        
        self.time_entry = tk.Entry(time_frame, width=15, font=("Arial", 10))
        self.time_entry.pack(side=tk.LEFT, padx=5)
        
        calculate_btn = tk.Button(self.root, text="Calculate Expiry Date",
                                     command=self.calculate_expiry,
                                     bg="#4CAF50", fg="white",
                                     font=("Arial", 10, "bold"),
                                     padx=10, pady=5)
        calculate_btn.pack(pady=15)
        
        result_frame = tk.Frame(self.root)
        result_frame.pack(pady=10)
        
        self.result_label = tk.Label(result_frame, text="", font=("Arial", 10, "bold"),
                                         justify=tk.LEFT, fg="#2196F3")
        self.result_label.pack()

    def calculate_expiry(self):
        date_str = self.date_entry.get().strip()
        time_str = self.time_entry.get().strip()
        
        if not self.validate_input(date_str, time_str):
            return

        try:
            day = int(date_str[0:2])
            month = int(date_str[2:4])
            year = int(date_str[4:8])
            
            time_parts = time_str.split(':')
            hour = int(time_parts[0])
            minute = int(time_parts[1])
            second = int(time_parts[2])
            
            call_datetime = datetime(year, month, day, hour, minute, second)
            
            if call_datetime.month == 2 and call_datetime.day == 29:
                expiry_datetime = call_datetime.replace(year=call_datetime.year + 1, day=28)
            else:
                expiry_datetime = call_datetime.replace(year=call_datetime.year + 1)
            
            day_of_week = expiry_datetime.isoweekday()
            
            days = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"]
            day_name = days[day_of_week - 1]
            
            result_text = f"Package expiry date and time:\n"
            result_text += f"Date: {expiry_datetime.strftime('%d.%m.%Y')}\n"
            result_text += f"Time: {expiry_datetime.strftime('%H:%M:%S')}\n"
            result_text += f"Day of week: {day_of_week} ({day_name})"
            
            self.result_label.config(text=result_text)
            
        except ValueError as e:
            messagebox.showerror("Error", f"Invalid data: {str(e)}")

    def validate_input(self, date_str, time_str):
        if len(date_str) != 8 or not date_str.isdigit():
            messagebox.showerror("Error", "Date must contain exactly 8 digits in DDMMYYYY format")
            return False
        
        try:
            day = int(date_str[0:2])
            month = int(date_str[2:4])
            year = int(date_str[4:8])
            
            if day < 1 or day > 31:
                messagebox.showerror("Error", "Day must be between 01 and 31")
                return False
            if month < 1 or month > 12:
                messagebox.showerror("Error", "Month must be between 01 and 12")
                return False
            if year < 1900 or year > 2100:
                messagebox.showerror("Error", "Year must be between 1900 and 2100")
                return False
                
            datetime(year, month, day)
                
        except ValueError:
            messagebox.showerror("Error", "Invalid date")
            return False
        
        time_parts = time_str.split(':')
        if len(time_parts) != 3:
            messagebox.showerror("Error", "Time must be in HH:MM:SS format")
            return False
        
        for part in time_parts:
            if not part.isdigit() or len(part) != 2:
                messagebox.showerror("Error", "Each time part must be two digits")
                return False
        
        try:
            hour = int(time_parts[0])
            minute = int(time_parts[1])
            second = int(time_parts[2])
            
            if hour < 0 or hour > 23:
                messagebox.showerror("Error", "Hour must be between 00 and 23")
                return False
            if minute < 0 or minute > 59:
                messagebox.showerror("Error", "Minute must be between 00 and 59")
                return False
            if second < 0 or second > 59:
                messagebox.showerror("Error", "Second must be between 00 and 59")
                return False
                
        except ValueError:
            messagebox.showerror("Error", "Invalid time format")
            return False
        
        return True

def main():
    root = tk.Tk()
    app = MobilePackageApp(root)
    root.mainloop()

if __name__ == "__main__":
    main()
