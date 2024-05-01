#include <iostream>
#include "Deque.h"

int main()
{
    Deque<char> qe; // проверка через std::queue<char> qe; и #inlcude <queue>
    qe.push('a');
    qe.push('b');
    qe.push('c');

    std::cout << qe.size() << std::endl;

    auto q = qe; // нужен конструктор копирования в LList

    while (!qe.empty()) {
        std::cout << qe.front() << '\t' << qe.back() << std::endl;
        qe.pop();
    }
    std::cout << qe.size() << '\t' << q.size() << '\t'
        << q.front() << '\t' << q.back() << std::endl;
    return 0;

}