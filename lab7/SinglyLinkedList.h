#ifndef SINGLY_LINKED_LIST_H
#define SINGLY_LINKED_LIST_H

#include <iostream>
#include <memory>

template <typename T>
struct Element {
    T value;
    std::unique_ptr<Element<T>> next;

    Element(const T& val) : value(val), next(nullptr) {}
};

template <typename T>
class SinglyLinkedList {
private:
    std::unique_ptr<Element<T>> start;
    Element<T>* end;
    size_t size;

public:
    SinglyLinkedList();
    ~SinglyLinkedList();

    void Append(const T& val);
    void RemoveLast();
    void RemoveFirst();
    void InsertAt(const T& val, size_t index);
    void DeleteAt(size_t index);
    void Clear();

    void Print() const;
    T& operator[](size_t index);

    size_t Count() const { return size; }
};

#endif
