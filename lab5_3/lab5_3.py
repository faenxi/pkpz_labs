import tkinter as tk
from tkinter import ttk, messagebox

class Automobile:
    def __init__(self, name="", max_speed=0, color=""):
        self.name = name
        self.max_speed = max_speed
        self.color = color

    def __del__(self):
        print("Лабораторна робота виконана: Бикова Поля")

    def cost(self):
        """Вартість = максимальна швидкість * 100"""
        return self.max_speed * 100

    def update_model(self):
        """Оновлення моделі: +10 км/год"""
        self.max_speed += 10
        return self.max_speed

    def info(self):
        """Повертає інформацію про автомобіль"""
        return f"Назва: {self.name}\nКолір: {self.color}\nМакс. швидкість: {self.max_speed} км/год\nВартість: ${self.cost():,}"


class SportCar(Automobile):
    def __init__(self, name="", max_speed=0, color="", seats=2):
        super().__init__(name, max_speed, color)
        self.seats = seats

    def cost(self):
        """Вартість = макс. швидкість * 350"""
        return self.max_speed * 350

    def update_model(self):
        """Оновлення моделі: +100 км/год"""
        self.max_speed += 100
        return self.max_speed

    def info(self):
        base_info = super().info()
        return base_info + f"\nКількість місць: {self.seats}"


class LuxuryCar(Automobile):
    def __init__(self, name="", max_speed=0, color="", has_ac=True):
        super().__init__(name, max_speed, color)
        self.has_ac = has_ac

    def cost(self):
        """Вартість = макс. швидкість * 250"""
        return self.max_speed * 250

    def update_model(self):
        """Оновлення моделі: +50 км/год"""
        self.max_speed += 50
        return self.max_speed

    def info(self):
        base_info = super().info()
        ac_status = "є кондиціонер" if self.has_ac else "немає кондиціонера"
        return base_info + f"\nНаявність кондиціонера: {ac_status}"


class CarManagementApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Система керування автомобілями")
        self.root.geometry("550x550")
        self.current_car = None

        main_frame = ttk.Frame(root, padding="10")
        main_frame.grid(row=0, column=0, sticky=(tk.W, tk.E, tk.N, tk.S))

        title_label = ttk.Label(main_frame, text="Система керування автомобілями",
                                font=("Arial", 14, "bold"))
        title_label.grid(row=0, column=0, columnspan=2, pady=10)

        self.create_input_fields(main_frame)
        self.create_buttons(main_frame)
        self.create_output_area(main_frame)
        self.configure_grid_weights(main_frame)

    def create_input_fields(self, parent):
        ttk.Label(parent, text="Назва:").grid(row=1, column=0, sticky=tk.W, pady=5)
        self.name_entry = ttk.Entry(parent, width=30)
        self.name_entry.grid(row=1, column=1, sticky=(tk.W, tk.E), pady=5)

        ttk.Label(parent, text="Макс. швидкість (км/год):").grid(row=2, column=0, sticky=tk.W, pady=5)
        self.speed_entry = ttk.Entry(parent, width=30)
        self.speed_entry.grid(row=2, column=1, sticky=(tk.W, tk.E), pady=5)

        ttk.Label(parent, text="Колір:").grid(row=3, column=0, sticky=tk.W, pady=5)
        self.color_entry = ttk.Entry(parent, width=30)
        self.color_entry.grid(row=3, column=1, sticky=(tk.W, tk.E), pady=5)

        ttk.Label(parent, text="Тип автомобіля:").grid(row=4, column=0, sticky=tk.W, pady=5)
        self.type_combobox = ttk.Combobox(parent, values=["Звичайний", "Спортивний", "Представницький"], state="readonly")
        self.type_combobox.grid(row=4, column=1, sticky=(tk.W, tk.E), pady=5)
        self.type_combobox.current(0)
        self.type_combobox.bind("<<ComboboxSelected>>", self.on_type_change)

        self.seats_label = ttk.Label(parent, text="Кількість місць:")
        self.seats_entry = ttk.Entry(parent, width=30)

        self.ac_var = tk.BooleanVar(value=True)
        self.ac_checkbox = ttk.Checkbutton(parent, text="Є кондиціонер", variable=self.ac_var)

    def create_buttons(self, parent):
        button_frame = ttk.Frame(parent)
        button_frame.grid(row=7, column=0, columnspan=2, pady=15)

        ttk.Button(button_frame, text="Створити", command=self.create_car).grid(row=0, column=0, padx=5)
        self.update_btn = ttk.Button(button_frame, text="Оновити модель", command=self.update_car, state=tk.DISABLED)
        self.update_btn.grid(row=0, column=1, padx=5)
        self.info_btn = ttk.Button(button_frame, text="Показати інформацію", command=self.show_info, state=tk.DISABLED)
        self.info_btn.grid(row=0, column=2, padx=5)
        ttk.Button(button_frame, text="Очистити", command=self.clear_fields).grid(row=0, column=3, padx=5)

    def create_output_area(self, parent):
        ttk.Label(parent, text="Інформація:").grid(row=8, column=0, sticky=tk.W, pady=5)
        self.output_text = tk.Text(parent, height=12, width=60, wrap=tk.WORD)
        self.output_text.grid(row=9, column=0, columnspan=2, pady=5)

    def configure_grid_weights(self, parent):
        self.root.columnconfigure(0, weight=1)
        self.root.rowconfigure(0, weight=1)
        parent.columnconfigure(1, weight=1)
        parent.rowconfigure(9, weight=1)

    def on_type_change(self, event=None):
        """Показує додаткові поля залежно від типу авто"""
        car_type = self.type_combobox.get()

        self.seats_label.grid_remove()
        self.seats_entry.grid_remove()
        self.ac_checkbox.grid_remove()

        if car_type == "Спортивний":
            self.seats_label.grid(row=5, column=0, sticky=tk.W, pady=5)
            self.seats_entry.grid(row=5, column=1, sticky=(tk.W, tk.E), pady=5)
        elif car_type == "Представницький":
            self.ac_checkbox.grid(row=5, column=1, sticky=tk.W, pady=5)

    def create_car(self):
        try:
            name = self.name_entry.get().strip()
            color = self.color_entry.get().strip()
            car_type = self.type_combobox.get()
            max_speed = int(self.speed_entry.get())

            if not name or not color or max_speed <= 0:
                messagebox.showerror("Помилка", "Введіть правильні дані!")
                return

            if car_type == "Звичайний":
                self.current_car = Automobile(name, max_speed, color)
            elif car_type == "Спортивний":
                seats = int(self.seats_entry.get()) if self.seats_entry.get().strip() else 2
                self.current_car = SportCar(name, max_speed, color, seats)
            elif car_type == "Представницький":
                has_ac = self.ac_var.get()
                self.current_car = LuxuryCar(name, max_speed, color, has_ac)

            self.update_btn.config(state=tk.NORMAL)
            self.info_btn.config(state=tk.NORMAL)

            self.output_text.delete(1.0, tk.END)
            self.output_text.insert(tk.END, f"{car_type} автомобіль створено успішно!\n\n")
            self.show_info()

        except ValueError:
            messagebox.showerror("Помилка", "Макс. швидкість і кількість місць мають бути числами!")

    def update_car(self):
        if self.current_car:
            old_speed = self.current_car.max_speed
            new_speed = self.current_car.update_model()
            self.output_text.insert(tk.END, f"Модель оновлено! Швидкість: {old_speed} → {new_speed}\n\n")

    def show_info(self):
        if self.current_car:
            info = self.current_car.info()
            self.output_text.insert(tk.END, f"{info}\n{'-' * 60}\n")

    def clear_fields(self):
        self.name_entry.delete(0, tk.END)
        self.speed_entry.delete(0, tk.END)
        self.color_entry.delete(0, tk.END)
        self.seats_entry.delete(0, tk.END)
        self.output_text.delete(1.0, tk.END)
        self.type_combobox.current(0)
        self.ac_var.set(True)
        self.on_type_change()
        self.current_car = None
        self.update_btn.config(state=tk.DISABLED)
        self.info_btn.config(state=tk.DISABLED)


def main():
    root = tk.Tk()
    app = CarManagementApp(root)
    root.mainloop()


if __name__ == "__main__":
    main()
