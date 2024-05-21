#include <iostream>
#include <string>
#include <chrono>
#include <fstream>
#include <vector>

size_t naive(const std::string& str, const std::string& sub)
{
    size_t n = str.size(), m = sub.size(), j = 0;
    for (size_t i = 0; i < n - m + 1; i++)
    {
        for (j = 0; j < m; j++)
        {
            if (str[i + j] != sub[j])
                break;
        }
        if (j == m)
            return i;
    }
    return std::string::npos;
}

size_t kmp(const std::string& str, const std::string& sub)
{
    size_t n = str.size();
    size_t m = sub.size();
    if (m == 0) {
        return 0;
    }
    std::vector<size_t> jmp(m, 0);
    for (size_t i = 1, j = 0; i < m; ++i) {
        while (j > 0 && sub[i] != sub[j]) {
            j = jmp[j - 1];
        }
        if (sub[i] == sub[j]) ++j;
        jmp[i] = j;
    }
    size_t i = 0, j = 0;
    while (i < n) {
        if (str[i] == sub[j]) {
            ++i;
            ++j;
            if (j == m) {
                return i - j;
            }
        }
        else {
            if (j != 0) {
                j = jmp[j - 1];
            }
            else {
                ++i;
            }
        }
    }
    return std::string::npos;
}

size_t bm(const std::string& str, const std::string& sub)
{
    int M = str.size();
    int N = sub.size();

    std::vector<int> badChar(256, -1);

    for (int i = 0; i < M; i++) {
        badChar[str[i]] = i;
    }
    int s = 0; 
    while (s <= (N - M)) {
        int j = M - 1;

        while (j >= 0 && str[j] == sub[s + j])
            j--;

        if (j < 0) {
            return s;
            s += (s + M < N) ? M - badChar[sub[s + M]] : 1;
        }
        else {
            s += std::max(1, j - badChar[sub[s + j]]);
        }
    }
    return std::string::npos;
}

int main()
{
    using namespace std;

    string str, sub = "was born in a small town called Sceptre";
    ifstream fin("engwiki_ascii.txt", ios::binary);
    if (!fin.is_open())
    {
        cout << "not open!" << endl;
        return 0;
    }
    str.append((istreambuf_iterator<char>(fin)), istreambuf_iterator<char>());

    size_t n = 1;
    std::vector<size_t> times(n), indx(n);

    cout << "\nstd::find\n";
    for (size_t i = 0; i < n; i++)
    {
        auto time_one = chrono::high_resolution_clock::now();
        auto index = str.find(sub);
        if (index == std::string::npos)
            std::cout << "not found\n";
        else
            indx[i] = index;
        auto time_two = chrono::high_resolution_clock::now();
        times[i] = chrono::duration_cast<chrono::nanoseconds>(time_two - time_one).count();
    }
    for (size_t i = 0; i < n; i++)
    {
        cout << indx[i] << '\t' << times[i] << endl;
    }

    cout << "\nnaive\n";
    for (size_t i = 0; i < n; i++)
    {
        auto time_one = chrono::high_resolution_clock::now();
        auto index = naive(str, sub);
        if (index == std::string::npos)
            std::cout << "not found\n";
        else
            indx[i] = index;
        auto time_two = chrono::high_resolution_clock::now();
        times[i] = chrono::duration_cast<chrono::nanoseconds>(time_two - time_one).count();
    }
    for (size_t i = 0; i < n; i++)
    {
        cout << indx[i] << '\t' << times[i] << endl;
    }

    cout << "\KMP\n";
    for (size_t i = 0; i < n; i++)
    {
        auto time_one = chrono::high_resolution_clock::now();
        auto index = kmp(str, sub);
        if (index == std::string::npos)
            std::cout << "not found\n";
        else
            indx[i] = index;
        auto time_two = chrono::high_resolution_clock::now();
        times[i] = chrono::duration_cast<chrono::nanoseconds>(time_two - time_one).count();
    }
    for (size_t i = 0; i < n; i++)
    {
        cout << indx[i] << '\t' << times[i] << endl;
    }

    cout << "\BM\n";
    for (size_t i = 0; i < n; i++)
    {
        auto time_one = chrono::high_resolution_clock::now();
        auto index = bm(str, sub);
        if (index == std::string::npos)
            std::cout << "";
        else
            indx[i] = index;
        auto time_two = chrono::high_resolution_clock::now();
        times[i] = chrono::duration_cast<chrono::nanoseconds>(time_two - time_one).count();
    }
    for (size_t i = 0; i < n; i++)
    {
        cout << indx[i] << '\t' << times[i] << endl;
    }
}