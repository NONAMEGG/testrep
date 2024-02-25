#pragma once
#include <iostream>

template<typename T>
struct Node
{
public:
    T data;
    Node* next;

    Node(const T& data) : data(data), next(nullptr) {}
    Node() : data(0), next(nullptr) {}
};
