#define _CRT_SECURE_NO_WARNINGS 1
#include "slinkedlist.cpp"
#include "Queue.h"
using namespace std;

int main()
{
	Queue<char> qe;
	qe.push('a');
	qe.push('b');
	qe.push('c');

	std::cout << qe.size() << std::endl;

	auto q = qe;

	while (!qe.empty()) {
		std::cout << qe.front() << '\t' << qe.back() << std::endl;
		qe.pop();
	}
	std::cout << qe.size() << '\t' << q.size() << '\t'
		<< q.front() << '\t' << q.back() << std::endl;

	// 3
	// a	c
	// b	c
	// c	c
	// 0	3	a	c

}