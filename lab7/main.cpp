#include "SinglyLinkedList.h"  // Formerly List.h
#include "DoublyLinkedList.h"
#include <iostream>

int main() {
    try {
        // Singly linked list
        SinglyLinkedList singleList;

        singleList.PushBack(10);
        singleList.PushBack(20);
        singleList.PushFront(5);
        singleList.PushBack(30);

        std::cout << "Singly linked list after adding elements: ";
        singleList.Show();

        std::cout << "Element at index 1 (singly linked): " << singleList[1] << std::endl;

        singleList.Remove(10);
        std::cout << "List after removing 10 (singly linked): ";
        singleList.Show();

        singleList.PopFront();
        std::cout << "List after PopFront (singly linked): ";
        singleList.Show();

        singleList.PopBack();
        std::cout << "List after PopBack (singly linked): ";
        singleList.Show();

        std::cout << "Does it contain 20 (singly linked)? " << (singleList.Find(20) ? "Yes" : "No") << std::endl;
        std::cout << "Size of singly linked list: " << singleList.Size() << std::endl;

        std::cout << "\nAttempting access with invalid index (singly linked):" << std::endl;
        std::cout << singleList[5] << std::endl; // Expected exception

        // Doubly linked list
        DoublyLinkedList doubleList;

        doubleList.PushBack(100);
        doubleList.PushBack(200);
        doubleList.PushFront(50);
        doubleList.PushBack(300);

        std::cout << "\nDoubly linked list after adding elements: ";
        doubleList.ShowForward();

        std::cout << "Element at index 1 (doubly linked): " << doubleList[1] << std::endl;

        doubleList.Remove(100);
        std::cout << "List after removing 100 (doubly linked): ";
        doubleList.ShowForward();

        doubleList.PopFront();
        std::cout << "List after PopFront (doubly linked): ";
        doubleList.ShowForward();

        doubleList.PopBack();
        std::cout << "List after PopBack (doubly linked): ";
        doubleList.ShowForward();

        std::cout << "Does it contain 200 (doubly linked)? " << (doubleList.Find(200) ? "Yes" : "No") << std::endl;
        std::cout << "Size of doubly linked list: " << doubleList.Size() << std::endl;

        std::cout << "\nAttempting access with invalid index (doubly linked):" << std::endl;
        std::cout << doubleList[5] << std::endl; // Expected exception

    }
    catch (const std::out_of_range& ex) {
        std::cerr << "Error: " << ex.what() << std::endl;  // Out-of-range error
    }
    catch (...) {
        std::cerr << "Unknown error!" << std::endl;  // Generic error
    }

    return 0;
}
