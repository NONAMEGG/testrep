#pragma once
#include "Node.h"


using namespace std;

template<typename T>
class slinkedlist
{
private:
	void push_after_the_root(const T& value);
public:
	Node<T>* root;
	Node<T>* sentinel;
	slinkedlist();
	slinkedlist(const slinkedlist& other);
	slinkedlist& operator=(const slinkedlist& other);
	~slinkedlist();

	void clear();
	void push_back(const T& value);
	void push_front(const T& value);
	void insert(size_t idx, const T& value);
	void pop_back();
	void pop_front();
	void remove_at(size_t idx);
	T& operator[](const size_t idx);
	T const& operator[](const size_t index) const;
	size_t size() const;
	bool empty() const { return (root->next == sentinel->next); }
	T front() const { return (root->next->data); }
	T back() const;
};