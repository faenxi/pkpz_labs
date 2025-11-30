import tkinter as tk
from tkinter import scrolledtext
import re

def process_text():
    text1 = input_text1.get("1.0", tk.END)
    text2 = input_text2.get("1.0", tk.END)

    words1 = re.findall(r"\w+", text1.lower())
    words2 = set(re.findall(r"\w+", text2.lower()))

    result_words = [w for w in words1 if w not in words2]
    result_text = " ".join(result_words)

    output_text.delete("1.0", tk.END)
    output_text.insert(tk.END, result_text)

root = tk.Tk()
root.title("Text Processor")

lbl1 = tk.Label(root, text="Enter first text:")
lbl1.pack()


input_text1 = scrolledtext.ScrolledText(root, height=5, width=50)
input_text1.pack()

lbl2 = tk.Label(root, text="Enter second text:")
lbl2.pack()


input_text2 = scrolledtext.ScrolledText(root, height=5, width=50)
input_text2.pack()

btn = tk.Button(root, text="Process", command=process_text)
btn.pack()

lbl3 = tk.Label(root, text="Result:")
lbl3.pack()


output_text = scrolledtext.ScrolledText(root, height=5, width=50)
output_text.pack()

root.mainloop()

