#include <iostream>
#include <memory>
#include "Test.h"

int main() {
    // Проблема с владением указателем на массив данных
    //std::shared_ptr<Test> sp(new Test[3]);

    // Решение 1: указание типа-параметра как массив
    //std::shared_ptr<Test[]> sp(new Test[3]);

    // Решение 2: использование другого конструктора для shared_ptr
    //std::shared_ptr<Test> sp(new Test[3], std::default_delete<Test[]>());

    std::shared_ptr<Test> sp(new Test[3], std::default_delete<Test[]>());

    for (int i = 0; i < 3; ++i) {
        sp.get()[i].Val = i + 1;
    }

    for (int i = 0; i < 3; ++i) {
        std::cout << "sp[" << i << "].Val = " << sp.get()[i].Val << std::endl;
    }

    std::cout << "---------" << std::endl;

    std::unique_ptr<Test[]> p(new Test[3]);

    for (int i = 0; i < 3; ++i) {
        p[i].Val = i + 10;
    }
    p.reset(new Test[2]);

    for (int i = 0; i < 3; ++i) {
        std::cout << "p[" << i << "].Val = " << p[i].Val << std::endl;
    }

    return 0;
}