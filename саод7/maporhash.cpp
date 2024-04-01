#include <iostream>
#include <map>
#include <unordered_map>
#include <cstdlib>
#include <ctime>
#include <chrono>
using namespace std;
const int N = 128;

char* randKey() {
    const int K = 8;
    static char key[K + 1]{ 0 };

    for (int i = 0; i < K; ++i) {
        key[i] = rand() % ('c' - 'a' + 1) + 'a';
    }

    return key;
}

int main() {
    srand(static_cast<unsigned>(time(nullptr)));

    map<string, int> m;
    unordered_map<string, int> u;

    char* randomKey = randKey();
    cout << "Random key: " << randomKey << endl;

    pair<string, int> data[N];
    const int M = 512;
    int found_count = 0;

    auto start_map_search = chrono::steady_clock::now();

    for (int i = 0; i < M; ++i) {
        int key = data[i % N].second;
        if (m.count(to_string(key))) {
            found_count++;
        }
    }

    auto stop_map_search = chrono::steady_clock::now();
    auto dt_map_search = chrono::duration_cast<chrono::microseconds>(stop_map_search - start_map_search).count();

    cout << "For map - N: " << N << ", Time taken for search: " << dt_map_search << " microseconds, Found elements: " << found_count << endl;
    
    found_count = 0;
    start_map_search = chrono::steady_clock::now();

    for (int i = 0; i < M; ++i) {
        int key = data[i % N].second;
        if (u.count(to_string(key)))
            found_count++;
    }

    stop_map_search = chrono::steady_clock::now();
    dt_map_search = chrono::duration_cast<chrono::microseconds>(stop_map_search - start_map_search).count();

    cout << "For unordered map - N: " << N << ", Time taken for search: " << dt_map_search << " microseconds, Found elements: " << found_count << endl;

    /*1.Random key : abbbabca
        Time taken to fill the map : 1088 microseconds
        Time taken to fill the unordered_map : 886 microseconds
    2.Random key : abacacac
        Time taken to fill the map : 551 microseconds
        Time taken to fill the unordered_map : 471 microseconds
    3.Random key: abbaabbc
        Time taken to fill the map: 733 microseconds
        Time taken to fill the unordered_map: 302 microseconds
    4.Random key: cccabccc
        Time taken to fill the map: 639 microseconds
        Time taken to fill the unordered_map: 750 microseconds
    5.Random key: cccabccc
        Time taken to fill the map: 543 microseconds
        Time taken to fill the unordered_map: 323 microseconds

        */

}