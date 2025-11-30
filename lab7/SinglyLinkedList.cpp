#include "SinglyLinkedList.h"

template <typename T>
SinglyLinkedList<T>::SinglyLinkedList() : start(nullptr), end(nullptr), size(0) {}

template <typename T>
SinglyLinkedList<T>::~SinglyLinkedList() {
    Clear();
}

template <typename T>
void SinglyLinkedList<T>::Append(const T& val) {
    auto newElement = std::make_unique<Element<T>>(val);
    Element<T>* rawPtr = newElement.get();

    if (!start) {
        start = std::move(newElement);
        end = rawPtr;
    }
    else {
        end->next = std::move(newElement);
        end = rawPtr;
    }
    ++size;
}

template <typename T>
void SinglyLinkedList<T>::RemoveLast() {
    if (!start) {
        throw std::runtime_error("List is empty");
    }
    if (!start->next) {
        start.reset();
        end = nullptr;
    }
    else {
        Element<T>* current = start.get();
        while (current->next->next) {
            current = current->next.get();
        }
        current->next.reset();
        end = current;
    }
    --size;
}

template <typename T>
void SinglyLinkedList<T>::RemoveFirst() {
    if (!start) {
        throw std::runtime_error("List is empty");
    }
    start = std::move(start->next);
    if (!start) end = nullptr;
    --size;
}

template <typename T>
void SinglyLinkedList<T>::InsertAt(const T& val, size_t index) {
    if (index > size) {
        throw std::out_of_range("Index out of range");
    }

    auto newElement = std::make_unique<Element<T>>(val);
    if (index == 0) {
        newElement->next = std::move(start);
        start = std::move(newElement);
        if (!end) end = start.get();
    }
    else {
        Element<T>* current = start.get();
        for (size_t i = 0; i < index - 1; ++i) {
            current = current->next.get();
        }
        newElement->next = std::move(current->next);
        current->next = std::move(newElement);
        if (!current->next->next) end = current->next.get();
    }
    ++size;
}

template <typename T>
void SinglyLinkedList<T>::DeleteAt(size_t index) {
    if (index >= size) {
        throw std::out_of_range("Index out of range");
    }

    if (index == 0) {
        RemoveFirst();
    }
    else {
        Element<T>* current = start.get();
        for (size_t i = 0; i < index - 1; ++i) {
            current = current->next.get();
        }
        if (current->next.get() == end) {
            end = current;
        }
        current->next = std::move(current->next->next);
        --size;
    }
}

template <typename T>
void SinglyLinkedList<T>::Clear() {
    while (start) {
        start = std::move(start->next);
    }
    end = nullptr;
    size = 0;
}

template <typename T>
void SinglyLinkedList<T>::Print() const {
    if (!start) {
        std::cout << "List is empty!" << std::endl;
        return;
    }

    Element<T>* current = start.get();
    while (current) {
        std::cout << current->value << " ";
        current = current->next.get();
    }
    std::cout << std::endl;
}

template <typename T>
T& SinglyLinkedList<T>::operator[](size_t index) {
    if (index >= size) {
        throw std::out_of_range("Index out of range");
    }

    Element<T>* current = start.get();
    for (size_t i = 0; i < index; ++i) {
        current = current->next.get();
    }
    return current->value;
}

// Explicit instantiation
template class SinglyLinkedList<int>;
