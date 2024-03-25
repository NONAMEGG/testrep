#include <iostream>

class PF {
public:
    PF();
    PF(const PF& other);
    PF& operator=(const PF& other);
    ~PF();

    void Init(const std::string& s);
    int CmpCount() const;
    int operator[](int i) const; // Для доступа к значению по индексу
    operator int() const; // Для получения длины массива

private:
    int* pv; // Указатель на массив для хранения префикс-функции
    int n; // Длина строки
    int cmpCount; // Счетчик сравнений
};

PF::PF() : pv(nullptr), n(0), cmpCount(0) {}

PF::PF(const PF& other) : n(other.n), cmpCount(other.cmpCount) {
    pv = new int[n];
    std::copy(other.pv, other.pv + n, pv);
}

PF& PF::operator=(const PF& other) {
    if (this != &other) {
        delete[] pv;
        n = other.n;
        cmpCount = other.cmpCount;
        pv = new int[n];
        std::copy(other.pv, other.pv + n, pv);
    }
    return *this;
}

PF::~PF() {
    delete[] pv;
}

void PF::Init(const std::string& s) {
    cmpCount = 0; // Сбрасываем счетчик сравнений
    n = static_cast<int>(s.length());
    pv = new int[n]; // Выделяем память под массив

    pv[0] = 0;
    for (int i = 1; i < n; ++i) {
        int j = pv[i - 1];
        while (j > 0 && s[i] != s[j]) {
            j = pv[j - 1];
            cmpCount++; // Увеличиваем счетчик сравнений
        }
        if (s[i] == s[j]) {
            ++j;
        }
        pv[i] = j;
    }
}

int PF::CmpCount() const {
    return cmpCount;
}

int PF::operator[](int i) const {
    return pv[i];
}

PF::operator int() const {
    return n;
}