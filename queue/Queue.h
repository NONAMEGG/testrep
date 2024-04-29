#define _CRT_SECURE_NO_WARNINGS 1

#pragma once
#include "IDeque.cpp"
#include "slinkedlist.h"

template <typename T>
class Queue : public slinkedlist<T>, public IDeque<T>
{
public:
    Queue() : slinkedlist<T>() {}  
    void push(const T& data) override { slinkedlist<T>::push_back(data); }  
    void pop() override { slinkedlist<T>::pop_front(); }
    T top() const override { return slinkedlist<T>::front(); }
    size_t size() const override { return slinkedlist<T>::size(); }
    bool empty() const override { return slinkedlist<T>::empty(); }
};


