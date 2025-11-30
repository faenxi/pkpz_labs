#include "DoublyLinkedList.h"
#include <iostream>

template <typename T>
DoublyLinkedList<T>::DoublyLinkedList() : head(nullptr), tail(nullptr), count(0) {}

template <typename T>
DoublyLinkedList<T>::~DoublyLinkedList() {
    Clear();
}

template <typename T>
void DoublyLinkedList<T>::AddToFront(T val) {
    auto newNode = std::make_unique<DNode<T>>(val);
    newNode->next = std::move(head);
    newNode->previous = nullptr;

    if (newNode->next) {
        newNode->next->previous = newNode.get();
    }
    else {
        tail = newNode.get();
    }

    head = std::move(newNode);
    ++count;
}

template <typename T>
void DoublyLinkedList<T>::AddToBack(T val) {
    auto newNode = std::make_unique<DNode<T>>(val);
    newNode->next = nullptr;
    newNode->previous = tail;

    if (!head) {
        head = std::move(newNode);
        tail = head.get();
    }
    else {
        tail->next = std::move(newNode);
        tail->next->previous = tail;
        tail = tail->next.get();
    }
    ++count;
}

template <typename T>
void DoublyLinkedList<T>::RemoveFromFront() {
    if (!head) return;

    head = std::move(head->next);
    if (head) {
        head->previous = nullptr;
    }
    else {
        tail = nullptr;
    }
    --count;
}

template <typename T>
void DoublyLinkedList<T>::RemoveFromBack() {
    if (!tail) return;

    if (tail->previous) {
        tail = tail->previous;
        tail->next.reset();
    }
    else {
        head.reset();
        tail = nullptr;
    }
    --count;
}

template <typename T>
void DoublyLinkedList<T>::Delete(T val) {
    DNode<T>* current = head.get();
    while (current) {
        if (current->value == val) {
            if (current == head.get()) {
                RemoveFromFront();
                return;
            }
            else if (current == tail) {
                RemoveFromBack();
                return;
            }
            else {
                DNode<T>* prev = current->previous;
                std::unique_ptr<DNode<T>> toRemove = std::move(prev->next);
                prev->next = std::move(toRemove->next);
                if (prev->next) {
                    prev->next->previous = prev;
                }
                --count;
                return;
            }
        }
        current = current->next.get();
    }
}

template <typename T>
bool DoublyLinkedList<T>::Search(T val) const {
    DNode<T>* current = head.get();
    while (current) {
        if (current->value == val) return true;
        current = current->next.get();
    }
    return false;
}

template <typename T>
bool DoublyLinkedList<T>::IsEmpty() const {
    return count == 0;
}

template <typename T>
size_t DoublyLinkedList<T>::Length() const {
    return count;
}

template <typename T>
void DoublyLinkedList<T>::Clear() {
    while (head) {
        head = std::move(head->next);
    }
    tail = nullptr;
    count = 0;
}

template <typename T>
void DoublyLinkedList<T>::PrintForward() const {
    if (!head) {
        std::cout << "List is empty!" << std::endl;
        return;
    }
    DNode<T>* current = head.get();
    while (current) {
        std::cout << current->value << " ";
        current = current->next.get();
    }
    std::cout << std::endl;
}

template <typename T>
void DoublyLinkedList<T>::PrintBackward() const {
    if (!tail) {
        std::cout << "List is empty!" << std::endl;
        return;
    }
    DNode<T>* current = tail;
    while (current) {
        std::cout << current->value << " ";
        current = current->previous;
    }
    std::cout << std::endl;
}

template <typename T>
T& DoublyLinkedList<T>::operator[](size_t index) {
    if (index >= count) {
        throw std::out_of_range("Index out of range");
    }

    DNode<T>* current = head.get();
    for (size_t i = 0; i < index; ++i) {
        current = current->next.get();
    }
    return current->value;
}

// Explicit instantiation for int
template class DoublyLinkedList<int>;


