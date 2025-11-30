import tkinter as tk
from tkinter import messagebox
import re


date_pattern = r"\b(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.(19\d{2}|20\d{2})\b"

def find_dates():
    text = text_input.get("1.0", tk.END)
    dates = re.findall(date_pattern, text)
    dates_list.delete(0, tk.END)
    for d in dates:
        date_str = ".".join(d)   
        dates_list.insert(tk.END, date_str)
    messagebox.showinfo("Result", f"Found {len(dates)} dates")

def delete_date():
    selected = dates_list.get(tk.ACTIVE)
    if not selected:
        return
    text = text_input.get("1.0", tk.END)
    new_text = text.replace(selected, "")
    text_input.delete("1.0", tk.END)
    text_input.insert(tk.END, new_text)
    find_dates()

def replace_date():
    selected = dates_list.get(tk.ACTIVE)
    new_date = entry_replace.get()
    if not selected or not new_date:
        return
    text = text_input.get("1.0", tk.END)
    new_text = text.replace(selected, new_date, 1)  
    text_input.delete("1.0", tk.END)
    text_input.insert(tk.END, new_text)
    find_dates()


root = tk.Tk()
root.title("Date Finder")

lbl = tk.Label(root, text="Enter your text:")
lbl.pack()

text_input = tk.Text(root, height=10, width=50)
text_input.pack()

btn_find = tk.Button(root, text="Find dates", command=find_dates)
btn_find.pack()

dates_list = tk.Listbox(root, width=50, height=6)
dates_list.pack()

btn_delete = tk.Button(root, text="Delete selected date", command=delete_date)
btn_delete.pack()

lbl_replace = tk.Label(root, text="New date for replacement:")
lbl_replace.pack()

entry_replace = tk.Entry(root, width=20)
entry_replace.pack()

btn_replace = tk.Button(root, text="Replace selected date", command=replace_date)
btn_replace.pack()

root.mainloop()
