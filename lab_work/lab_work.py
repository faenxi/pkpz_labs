import tkinter as tk
from tkinter import filedialog, messagebox
import csv
from itertools import cycle


def read_list_of_lists(filepath):
    """Зчитує список списків з CSV-файлу."""
    data = []
    try:
        with open(filepath, 'r', newline='', encoding='utf-8') as file:
            reader = csv.reader(file)
            for row in reader:
                processed_row = [
                    (int(item) if item.isdigit() else item)
                    for item in row
                ]
                data.append(processed_row)
        return data
    except FileNotFoundError:
        messagebox.showerror("Помилка", f"Файл не знайдено: {filepath}")
        return None
    except Exception as e:
        messagebox.showerror("Помилка зчитування", f"Помилка при зчитуванні файлу: {e}")
        return None

def write_list_of_lists(filepath, data):
    """Зберігає список списків у CSV-файл."""
    try:
        with open(filepath, 'w', newline='', encoding='utf-8') as file:
            writer = csv.writer(file)
            writer.writerows(data)
        messagebox.showinfo("Успіх", f"Результат успішно збережено у файл: {filepath}")
    except Exception as e:
        messagebox.showerror("Помилка запису", f"Помилка при записі у файл: {e}")

def process_variant_1(buyers_list, items_list, k_param, m_param, n_param):
    """
    Обробляє циклічні списки згідно з Варіантом 1.
    Дано 2 кільцевих списки (покупці та товари).
    Кожен k-й покупець купує m-й товар.
    Один покупець може придбати n-ну кількість товарів.
    """
    if not buyers_list or not items_list:
        return []

    buyers_cycle = cycle(buyers_list)
    items_cycle = cycle(items_list)

    purchases = []
    buyer_purchases_count = {}

    for buyer in buyers_list:
        buyer_purchases_count[buyer] = 0

    k_index = 0
    m_index = 0

    max_iterations = len(buyers_list) * len(items_list) * n_param * 2
    iteration_count = 0

    while iteration_count < max_iterations:
        current_buyer = next(buyers_cycle)
        current_item = next(items_cycle)

        k_index = (k_index + 1) % len(buyers_list)
        m_index = (m_index + 1) % len(items_list)

        is_k_buyer = (k_index + 1) % k_param == 0
        

        if is_k_buyer:
            if buyer_purchases_count[current_buyer] < n_param:
                purchases.append([current_buyer, current_item])
                buyer_purchases_count[current_buyer] += 1
                
        if all(count >= n_param for count in buyer_purchases_count.values()):
            break
            
        iteration_count += 1
        if iteration_count >= max_iterations:
            messagebox.showwarning("Увага", "Перевищено максимальну кількість ітерацій. Можливо, умова 'кожен k-й покупець купує m-й товар' не дозволяє всім покупцям досягти ліміту n.")


    return purchases


class LabApp:
    def __init__(self, master):
        self.master = master
        master.title("Лабораторна робота 1.2, Варіант 1")

        self.buyers_data = []
        self.items_data = []
        self.results_data = []
        self.input_file_path = "input_data.csv"
        self.output_file_path = "output_data.csv"
        
        self.create_widgets()

    def create_widgets(self):
        input_frame = tk.LabelFrame(self.master, text="Вхідні дані та Параметри", padx=10, pady=10)
        input_frame.pack(padx=10, pady=5, fill="x")

        tk.Label(input_frame, text="k (кожен k-й покупець):").grid(row=0, column=0, padx=5, pady=2, sticky="w")
        self.k_entry = tk.Entry(input_frame, width=5)
        self.k_entry.insert(0, "2")
        self.k_entry.grid(row=0, column=1, padx=5, pady=2, sticky="w")
        
        tk.Label(input_frame, text="m (купує m-й товар):").grid(row=1, column=0, padx=5, pady=2, sticky="w")
        self.m_entry = tk.Entry(input_frame, width=5)
        self.m_entry.insert(0, "1") 
        self.m_entry.grid(row=1, column=1, padx=5, pady=2, sticky="w")

        tk.Label(input_frame, text="n (макс. покупок на покупця):").grid(row=2, column=0, padx=5, pady=2, sticky="w")
        self.n_entry = tk.Entry(input_frame, width=5)
        self.n_entry.insert(0, "3")
        self.n_entry.grid(row=2, column=1, padx=5, pady=2, sticky="w")

        tk.Button(input_frame, text="Завантажити дані (CSV)", command=self.load_data).grid(row=3, column=0, columnspan=2, pady=5, sticky="we")
        
        data_display_frame = tk.LabelFrame(self.master, text="Вхідні списки", padx=10, pady=5)
        data_display_frame.pack(padx=10, pady=5, fill="x")

        tk.Label(data_display_frame, text="Покупці:").grid(row=0, column=0, padx=5, sticky="nw")
        self.buyers_text = tk.Text(data_display_frame, height=5, width=30)
        self.buyers_text.grid(row=1, column=0, padx=5, sticky="we")

        tk.Label(data_display_frame, text="Товари:").grid(row=0, column=1, padx=5, sticky="nw")
        self.items_text = tk.Text(data_display_frame, height=5, width=30)
        self.items_text.grid(row=1, column=1, padx=5, sticky="we")
        
        data_display_frame.grid_columnconfigure(0, weight=1)
        data_display_frame.grid_columnconfigure(1, weight=1)

        action_frame = tk.Frame(self.master)
        action_frame.pack(padx=10, pady=5, fill="x")
        
        tk.Button(action_frame, text="Виконати обробку", command=self.execute_processing).pack(side="left", padx=5, expand=True, fill="x")
        tk.Button(action_frame, text="Зберегти результат (CSV)", command=self.save_results).pack(side="right", padx=5, expand=True, fill="x")

        result_frame = tk.LabelFrame(self.master, text="Результат (Список покупок [Покупець, Товар])", padx=10, pady=5)
        result_frame.pack(padx=10, pady=5, fill="both", expand=True)
        
        self.result_text = tk.Text(result_frame, height=10, width=60)
        self.result_text.pack(padx=5, pady=5, fill="both", expand=True)


    def update_gui_data(self):
        """Оновлює текстові поля вхідними даними."""
        self.buyers_text.delete(1.0, tk.END)
        self.items_text.delete(1.0, tk.END)

        if self.buyers_data:
            buyers_str = "\n".join(str(item) for sublist in self.buyers_data for item in sublist)
            self.buyers_text.insert(tk.END, buyers_str)
        
        if self.items_data:
            items_str = "\n".join(str(item) for sublist in self.items_data for item in sublist)
            self.items_text.insert(tk.END, items_str)
            
    def update_gui_results(self):
        """Оновлює текстове поле результатів."""
        self.result_text.delete(1.0, tk.END)
        if self.results_data:
            result_str = "\n".join([f"[{b}, {i}]" for b, i in self.results_data])
            self.result_text.insert(tk.END, result_str)

    def load_data(self):
        """Завантажує дані з файлу і оновлює GUI."""
        filepath = filedialog.askopenfilename(
            defaultextension=".csv",
            filetypes=[("CSV files", "*.csv"), ("All files", "*.*")],
            initialfile=self.input_file_path
        )
        if not filepath:
            return

        all_data = read_list_of_lists(filepath)
        if all_data and len(all_data) >= 2:
            self.buyers_data = [all_data[0]]
            self.items_data = [all_data[1]] 
            self.update_gui_data()
            messagebox.showinfo("Успіх", f"Дані завантажено з {filepath}. Перший рядок - покупці, другий - товари.")
        elif all_data:
             messagebox.showerror("Помилка", "Файл повинен містити принаймні два рядки: один для покупців, один для товарів.")

    def execute_processing(self):
        """Виконує обробку і відображає результат."""
        try:
            k_param = int(self.k_entry.get())
            m_param = int(self.m_entry.get())
            n_param = int(self.n_entry.get())
            
            if k_param <= 0 or n_param <= 0:
                 messagebox.showerror("Помилка параметрів", "Параметри k і n мають бути додатніми числами.")
                 return
        except ValueError:
            messagebox.showerror("Помилка параметрів", "Параметри k, m, n мають бути цілими числами.")
            return

        if not self.buyers_data or not self.items_data:
            messagebox.showerror("Помилка", "Будь ласка, завантажте вхідні дані.")
            return
            
        buyers = self.buyers_data[0]
        items = self.items_data[0]

        self.results_data = process_variant_1(buyers, items, k_param, m_param, n_param)
        
        self.update_gui_results()
        messagebox.showinfo("Обробка завершена", "Результат обробки виведено на екран.")

    def save_results(self):
        """Зберігає список результатів у файл."""
        if not self.results_data:
            messagebox.showwarning("Попередження", "Немає даних для збереження.")
            return
            
        filepath = filedialog.asksaveasfilename(
            defaultextension=".csv",
            filetypes=[("CSV files", "*.csv"), ("All files", "*.*")],
            initialfile=self.output_file_path
        )
        if filepath:
            write_list_of_lists(filepath, self.results_data)

if __name__ == "__main__":
    try:
        with open("input_data.csv", 'x', newline='', encoding='utf-8') as f:
            writer = csv.writer(f)
            writer.writerow(["Іванов", "Петров", "Сидоров", "Коваленко"]) 
            writer.writerow(["Молоко", "Хліб", "Сир", "Кава", "Цукор"]) 
    except FileExistsError:
        pass
    except Exception:
        pass
        
    root = tk.Tk()
    app = LabApp(root)
    root.mainloop()
