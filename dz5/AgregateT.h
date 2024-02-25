#pragma once
#ifndef AGGREGATET_H
#define AGGREGATET_H

#include <iostream>
using namespace std;

template<typename T>
class AgregateT {
public:
    T m_objField;

    AgregateT() {
        std::cout << "AggregateT constructor called" << std::endl;
    }

    ~AgregateT() {
        std::cout << "AggregateT destructor called" << std::endl;
    }
};

#endif