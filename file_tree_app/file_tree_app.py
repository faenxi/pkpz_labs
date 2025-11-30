import tkinter as tk
from tkinter import messagebox, simpledialog
from collections import deque

class Node:
    def __init__(self, key):
        self.key = key
        self.left = None
        self.right = None
        
    def __str__(self):
        return str(self.key)

class CatalogTree:
    def __init__(self):
        self.root = None

    def _insert_recursive(self, root, key):
        if root is None:
            return Node(key)
        
        if key < root.key:
            root.left = self._insert_recursive(root.left, key)
        elif key > root.key:
            root.right = self._insert_recursive(root.right, key)
        
        return root

    def insert(self, key):
        if self.search(key):
            return False, "Елемент вже існує."
            
        self.root = self._insert_recursive(self.root, key)
        return True, f"Каталог '{key}' успішно додано."

    def _min_value_node(self, node):
        current = node
        while current.left is not None:
            current = current.left
        return current

    def _delete_recursive(self, root, key):
        if root is None:
            return root

        if key < root.key:
            root.left = self._delete_recursive(root.left, key)
        elif key > root.key:
            root.right = self._delete_recursive(root.right, key)
        else:
            if root.left is None:
                return root.right
            elif root.right is None:
                return root.left
            
            temp = self._min_value_node(root.right)
            root.key = temp.key
            root.right = self._delete_recursive(root.right, temp.key)

        return root
    
    def delete(self, key):
        initial_root = self.root
        self.root = self._delete_recursive(self.root, key)
        if initial_root is not self.root or self.search(key) is None:
            return True, f"Каталог '{key}' успішно видалено."
        else:
            return False, f"Каталог '{key}' не знайдено."

    def search(self, key):
        current = self.root
        while current is not None:
            if key == current.key:
                return current
            elif key < current.key:
                current = current.left
            else:
                current = current.right
        return None

    def traverse_bfs(self):
        if self.root is None:
            return "Дерево порожнє."
        
        nodes_list = []
        queue = deque([self.root])
        
        while queue:
            node = queue.popleft()
            nodes_list.append(node.key)
            
            if node.left:
                queue.append(node.left)
            if node.right:
                queue.append(node.right)
                
        return " -> ".join(nodes_list)

class TreeApp:
    def __init__(self, master):
        self.master = master
        master.title("Дерево Каталогів (BST)")

        self.tree = CatalogTree()
        self.setup_gui()
        self.insert_initial_data()

    def setup_gui(self):
        action_frame = tk.LabelFrame(self.master, text="Дії з Деревом", padx=10, pady=10)
        action_frame.pack(padx=10, pady=5, fill="x")

        tk.Button(action_frame, text="Включити Елемент", command=self.add_element).grid(row=0, column=0, padx=5, pady=5, sticky="we")
        tk.Button(action_frame, text="Видалити Елемент", command=self.remove_element).grid(row=0, column=1, padx=5, pady=5, sticky="we")
        tk.Button(action_frame, text="Пошук Елемента", command=self.find_element).grid(row=1, column=0, padx=5, pady=5, sticky="we")
        tk.Button(action_frame, text="Обхід Дерева (BFS)", command=self.traverse_tree).grid(row=1, column=1, padx=5, pady=5, sticky="we")
        
        action_frame.grid_columnconfigure(0, weight=1)
        action_frame.grid_columnconfigure(1, weight=1)

        result_frame = tk.LabelFrame(self.master, text="Стан та Результати", padx=10, pady=5)
        result_frame.pack(padx=10, pady=5, fill="both", expand=True)
        
        self.result_label = tk.Label(result_frame, text="Статус: Готово.", justify=tk.LEFT, anchor="w", fg="blue")
        self.result_label.pack(fill="x", pady=2)
        
        tk.Label(result_frame, text="Обхід Дерева (BFS):").pack(fill="x", pady=2)
        self.traverse_text = tk.Text(result_frame, height=5, width=60, state=tk.DISABLED, bg="lightgray")
        self.traverse_text.pack(fill="both", expand=True)

    def insert_initial_data(self):
        initial_keys = ["root", "Users", "System", "Documents", "Program Files", "Desktop", "Music"]
        for key in initial_keys:
            self.tree.insert(key)
        self.update_traverse_view("Початкове дерево каталогів створено.")

    def update_traverse_view(self, status_message):
        bfs_result = self.tree.traverse_bfs()
        self.traverse_text.config(state=tk.NORMAL)
        self.traverse_text.delete(1.0, tk.END)
        self.traverse_text.insert(tk.END, bfs_result)
        self.traverse_text.config(state=tk.DISABLED)
        
        self.result_label.config(text=f"Статус: {status_message}")


    def add_element(self):
        key = simpledialog.askstring("Включити Елемент", "Введіть назву каталогу/файлу (текст):")
        if key:
            key = key.strip()
            success, msg = self.tree.insert(key)
            if success:
                self.update_traverse_view(msg)
            else:
                messagebox.showerror("Помилка Включення", msg)
                self.update_traverse_view(msg)

    def remove_element(self):
        key = simpledialog.askstring("Видалити Елемент", "Введіть назву каталогу/файлу для видалення:")
        if key:
            key = key.strip()
            success, msg = self.tree.delete(key)
            if success:
                self.update_traverse_view(msg)
            else:
                messagebox.showerror("Помилка Видалення", msg)
                self.update_traverse_view(msg)

    def find_element(self):
        key = simpledialog.askstring("Пошук Елемента", "Введіть назву каталогу/файлу для пошуку:")
        if key:
            key = key.strip()
            node = self.tree.search(key)
            if node:
                messagebox.showinfo("Пошук Успішний", f"Елемент '{key}' знайдено в дереві.")
                self.update_traverse_view(f"Пошук: Елемент '{key}' знайдено.")
            else:
                messagebox.showerror("Пошук Невдалий", f"Елемент '{key}' не знайдено в дереві.")
                self.update_traverse_view(f"Пошук: Елемент '{key}' не знайдено.")

    def traverse_tree(self):
        self.update_traverse_view("Виконано обхід дерева в ширину (BFS).")


if __name__ == "__main__":
    root = tk.Tk()
    app = TreeApp(root)
    root.mainloop()