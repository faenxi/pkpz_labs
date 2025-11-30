#pragma once

#include <memory>
#include <cstddef>
#include <stdexcept>
#include <iostream>

template <typename T>
struct DNode {
    T value;
    std::unique_ptr<DNode<T>> next;
    DNode<T>* previous;

    DNode(T val) : value(val), next(nullptr), previous(nullptr) {}
};

template <typename T>
class DoublyLinkedList {
private:
    std::unique_ptr<DNode<T>> head;
    DNode<T>* tail;
    size_t count;

public:
    DoublyLinkedList();
    ~DoublyLinkedList();

    void AddToFront(T val);
    void AddToBack(T val);
    void RemoveFromFront();
    void RemoveFromBack();
    void Delete(T val);
    bool Search(T val) const;
    bool IsEmpty() const;
    size_t Length() const;
    void Clear();
    void PrintForward() const;
    void PrintBackward() const;
    T& operator[](size_t index);

    class Iterator {
    private:
        DNode<T>* current;
    public:
        Iterator(DNode<T>* node) : current(node) {}
        T& operator*() const { return current->value; }
        Iterator& operator++() {
            if (current) current = current->next.get();
            return *this;
        }
        bool operator!=(const Iterator& other) const { return current != other.current; }
    };

    Iterator begin() const { return Iterator(head.get()); }
    Iterator end() const { return Iterator(nullptr); }
};
