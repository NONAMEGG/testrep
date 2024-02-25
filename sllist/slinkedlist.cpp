#include "slinkedlist.h"
#include <stdio.h>
#include "Node.h"

template<typename T>
slinkedlist<T>::slinkedlist() {
	sentinel = new Node<T>();
	sentinel->next = new Node<T>();
	root = new Node<T>();
	root->next = sentinel->next;
}

template<typename T>
slinkedlist<T>::slinkedlist(const slinkedlist& other) {
	sentinel = new Node<T>();
	root.next = &sentinel;

	Node<T>* current = other.root.next;
	while (current != other.sentinel) {
		push_back(current->data);
		current = current->next;
	}
}


template<typename T>
slinkedlist<T>::~slinkedlist() {
	clear();
}

template<typename T>
slinkedlist<T>& slinkedlist<T>::operator=(const slinkedlist& other) {
	clear();
	Node<T>* current = other.root->next;
	while (current != other.sentinel->next) {
		push_back(current->data);
		current = current->next;
	}
	return *this;
}

template<typename T>
void slinkedlist<T>::push_after_the_root(const T& value) {
	Node<T>* temp = new Node<T>(value);
	temp->next = sentinel->next;
	root->next = temp;
}

template<typename T>
void slinkedlist<T>::push_back(const T& value) {
	if (root->next == sentinel->next) {
		push_after_the_root(value);
	}
	else {
		Node<T>* current = root->next;
		while (current->next != sentinel->next) {
			current = current->next;
		}
		Node<T>* temp = new Node<T>(value);
		temp->next = sentinel->next;
		current->next = temp;
	}
}

template<typename T>
void slinkedlist<T>::push_front(const T& value) {
	if (root->next == sentinel->next) push_after_the_root(value);
	else {
		Node<T>* current = root->next;
		Node<T>* temp = new Node<T>(value);
		temp->next = current;
		root->next = temp;
	}
}

template<typename T>
void slinkedlist<T>::clear() {
	Node<T>* current = root->next;
	while (current != sentinel->next) {
		Node<T>* temp = current;
		current = current->next;
		delete temp;
	}
	root->next = sentinel->next;
}

template<typename T>
void slinkedlist<T>::insert(size_t idx, const T& value) {
	if (idx == 0) {
		perror("index == 0 is root"); exit(0);
	}
	Node<T>* current = root;
	for (int i = 1; i < idx; i++)
	{
		current = current->next;
		if (current == sentinel->next) {
			perror("overflow: no such index in sllist");
			exit(0);
		}
	}
	Node<T>* temp = current->next;
	current->next = new Node<T>(value);
	current->next->next = temp;
}
template<typename T>
void slinkedlist<T>::pop_back() {
	Node<T>* current = root;
	while (current->next->next != sentinel->next)
		current = current->next;
	delete current->next;
	current->next = sentinel->next;
}
template<typename T>
void slinkedlist<T>::pop_front() {
	Node<T>* temp = root->next->next;
	delete root->next;
	root->next = temp;
}
template<typename T>
void slinkedlist<T>::remove_at(size_t idx) {
	Node<T>* current = root;
	if (idx == 0) {
		perror("index == 0 is root"); exit(0);

	}
	for (int i = 1; i < idx; i++) {
		current = current->next;
	}
	Node<T>* temp = current->next->next;
	delete current->next;
	current->next = temp;
}
template<typename T>
T& slinkedlist<T>::operator[](const size_t idx) {
	if (idx == 0) {
		perror("index == 0 is root"); exit(0);
	}
	Node<T>* current = root->next;
	for (int i = 1; i < idx; i++)
	{
		current = current->next;
		if (current == sentinel->next) {
			perror("overflow: no such index in sllist");
			exit(0);
		}
	}
	return current->data;
}
template<typename T>
T const& slinkedlist<T>::operator[](const size_t idx) const {
	if (idx == 0) {
		perror("index == 0 is root"); exit(0);
	}
	Node<T>* current = root->next;
	for (int i = 1; i < idx; i++)
	{
		current = current->next;
		if (current == sentinel->next) {
			perror("overflow: no such index in sllist");
			exit(0);
		}
	}
	return current->data;
}
template<typename T>
size_t slinkedlist<T>::size() const {
	int num = 1;
	Node<T>* current = root;
	while (current->next != sentinel->next) {
		current = current->next;
		++num;
	}
	return num;
}
template<typename T>
T slinkedlist<T>::back() const {
	Node<T>* current = root;
	while (current->next != sentinel->next) current = current->next;
	return current->data;
}