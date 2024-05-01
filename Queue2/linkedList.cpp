#include <iostream>
#include "IlinkedList.h"

template <typename T>
class Node {
public:
    T data;
    Node* next;

    Node(const T& value) : data(value), next(nullptr) {}
};

template <typename T>
class linkedList :public ILinkedList<T> {
private:
    Node<T>* tail;
    size_t size_;

public:
    linkedList() : tail(nullptr), size_(0) {}

    ~linkedList() {
        clear();
    }

    linkedList(const linkedList& other) : tail(nullptr), size_(0) {
        Node<T>* temp = other.tail;
        do {
            push_back(temp->data);
            temp = temp->next;
        } while (temp != other.tail);
    }

    linkedList& operator=(const linkedList& other) {
        if (this != &other) {
            clear();
            Node<T>* temp = other.tail;
            do {
                push_back(temp->data);
                temp = temp->next;
            } while (temp != other.tail);
        }
        return *this;
    }

    void push_back(const T& value) {
        Node<T>* newNode = new Node<T>(value);
        if (!tail) {
            tail = newNode;
            tail->next = tail;
        }
        else {
            newNode->next = tail->next;
            tail->next = newNode;
            tail = newNode;
        }
        size_++;
    }

    void push_front(const T& value) {
        Node<T>* newNode = new Node<T>(value);
        if (!tail) {
            tail = newNode;
            tail->next = tail;
        }
        else {
            newNode->next = tail->next;
            tail->next = newNode;
        }
        size_++;
    }

    void insert(size_t idx, const T& value) {
        if (idx < 0 || idx > size_) {
            std::cerr << "Index out of range\n";
            return;
        }
        if (idx == 0) {
            push_front(value);
        }
        else if (idx == size_) {
            push_back(value);
        }
        else {
            Node<T>* newNode = new Node<T>(value);
            Node<T>* temp = tail->next;
            for (size_t i = 0; i < idx - 1; ++i) {
                temp = temp->next;
            }
            newNode->next = temp->next;
            temp->next = newNode;
            size_++;
        }
    }

    void pop_back() {
        if (!tail) {
            return;
        }

        if (size_ == 1) {
            delete tail;
            tail = nullptr;
        }
        else {
            Node<T>* prev = tail->next;
            while (prev->next != tail) {
                prev = prev->next;
            }
            prev->next = tail->next;
            delete tail;
            tail = prev;
        }

        size_--;
    }

    void pop_front() {
        if (!tail) {
            return;
        }

        if (size_ == 1) {
            delete tail;
            tail = nullptr;
        }
        else {
            Node<T>* first = tail->next;
            tail->next = first->next;
            delete first;
        }

        size_--;
    }

    void remove_at(size_t index) {
        if (index < 0 || index >= size_) {
            std::cerr << "Index out of range\n";
            return;
        }
        if (index == 0) {
            pop_front();
        }
        else if (index == size_ - 1) {
            pop_back();
        }
        else {
            Node<T>* temp = tail->next;
            for (size_t i = 0; i < index - 1; ++i) {
                temp = temp->next;
            }
            Node<T>* toDelete = temp->next;
            temp->next = toDelete->next;
            delete toDelete;
            size_--;
        }
    }

    T& operator[](const size_t index) {
        Node<T>* temp = tail->next;
        for (size_t i = 0; i < index; ++i) {
            temp = temp->next;
        }
        return temp->data;
    }

    const T& operator[](const size_t index) const {
        Node<T>* temp = tail->next;
        for (size_t i = 0; i < index; ++i) {
            temp = temp->next;
        }
        return temp->data;
    }

    size_t size() const {
        return size_;
    }

    bool empty() const {
        return size_ == 0;
    }

    void clear() {
        while (!empty()) {
            pop_front();
        }
    }

    T front() const {
        if (!tail) {
            throw std::out_of_range("List is empty");
        }
        return tail->next->data;
    }

    T back() const {
        if (!tail) {
            throw std::out_of_range("List is empty");
        }
        return tail->data;
    }
};

