#pragma once
#include "linkedList.h"
#include "IDeque.h"


template <typename T>
class Deque : public linkedList<T>, public IDeque<T>
{

public:
    Deque() { linkedList<T>(); }
    void push(const T& data) override {
        linkedList<T>::push_back(data);
    }

    void pop() override {
        linkedList<T>::pop_front();
    }

    T front() const override {
        return linkedList<T>::front();
    }


    T back() const override {
        return linkedList<T>::back();
    }


    size_t size() const override {
        return linkedList<T>::size();
    }

    bool empty() const override {
        return linkedList<T>::empty();
    }
};
