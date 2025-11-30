#include <iostream>
#include <stack>
#include <queue>
#include <vector>
#include <algorithm>
#include <string>
#include <unordered_map>
#include <list>
#include <sstream>
#include <cctype>

double evaluatePostfix(const std::string& expression) {
    std::stack<double> stack;

    auto isOperator = [](char c) {
        return c == '+' || c == '-' || c == '*' || c == '/';
        };

    std::istringstream iss(expression);
    std::string token;

    while (iss >> token) {
        if (isdigit(token[0])) {
            stack.push(std::stod(token));
        }
        else if (isOperator(token[0])) {
            double b = stack.top(); stack.pop();
            double a = stack.top(); stack.pop();

            switch (token[0]) {
            case '+': stack.push(a + b); break;
            case '-': stack.push(a - b); break;
            case '*': stack.push(a * b); break;
            case '/': stack.push(a / b); break;
            }
        }
    }

    return stack.top();
}


bool isBalanced(const std::string& str) {
    std::stack<char> stack;
    std::unordered_map<char, char> pairs = { {')', '('}, {']', '['}, {'}', '{'} };

    for (char c : str) {
        if (pairs.count(c)) {
            if (stack.empty() || stack.top() != pairs[c]) {
                return false;
            }
            stack.pop();
        }
        else if (c == '(' || c == '[' || c == '{') {
            stack.push(c);
        }
    }

    return stack.empty();
}

class LRUCache {
private:
    int capacity;
    std::list<std::pair<int, int>> cache;
    std::unordered_map<int, std::list<std::pair<int, int>>::iterator> map;

public:
    LRUCache(int capacity) : capacity(capacity) {}

    int get(int key) {
        auto it = map.find(key);
        if (it == map.end()) return -1;

        cache.splice(cache.begin(), cache, it->second);
        return it->second->second;
    }

    void put(int key, int value) {
        auto it = map.find(key);
        if (it != map.end()) {
            it->second->second = value;
            cache.splice(cache.begin(), cache, it->second);
            return;
        }

        if (cache.size() == capacity) {
            auto last = cache.back();
            map.erase(last.first);
            cache.pop_back();
        }

        cache.emplace_front(key, value);
        map[key] = cache.begin();
    }
};

std::string reverseSentence(const std::string& sentence) {
    std::vector<std::string> words;
    std::istringstream iss(sentence);
    std::string word;

    while (iss >> word) {
        words.push_back(word);
    }

    std::reverse(words.begin(), words.end());
    std::ostringstream oss;

    for (size_t i = 0; i < words.size(); ++i) {
        if (i != 0) oss << " ";
        oss << words[i];
    }

    return oss.str();
}

double findMedianSortedArrays(const std::vector<int>& nums1, const std::vector<int>& nums2) {
    std::vector<int> merged(nums1.size() + nums2.size());
    std::merge(nums1.begin(), nums1.end(), nums2.begin(), nums2.end(), merged.begin());

    int n = merged.size();
    if (n % 2 == 0) {
        return (merged[n / 2 - 1] + merged[n / 2]) / 2.0;
    }
    else {
        return merged[n / 2];
    }
}

int main() {
    std::cout << "1. Postfix evaluation:\n";
    std::string postfix = "5 1 2 + 4 * + 3 -";
    std::cout << postfix << " = " << evaluatePostfix(postfix) << "\n\n";

    std::cout << "2. Balanced brackets:\n";
    std::vector<std::string> bracketsTests = {
        "{}", "{asdsadad}", "(qeqwe(", "{(}", "{(wewqe)}"
    };

    for (const auto& test : bracketsTests) {
        std::cout << test << " - " << (isBalanced(test) ? "Valid" : "Invalid") << "\n";
    }
    std::cout << "\n";

    std::cout << "3. LRU Cache:\n";
    LRUCache cache(2);
    cache.put(1, 1);
    cache.put(2, 2);
    std::cout << "Get 1: " << cache.get(1) << "\n";
    cache.put(3, 3);
    std::cout << "Get 2: " << cache.get(2) << "\n";
    cache.put(4, 4);
    std::cout << "Get 1: " << cache.get(1) << "\n";
    std::cout << "Get 3: " << cache.get(3) << "\n";
    std::cout << "Get 4: " << cache.get(4) << "\n\n";

    std::cout << "4. Reverse sentence:\n";
    std::string sentence = "Hello world this is a test";
    std::cout << "Original: " << sentence << "\n";
    std::cout << "Reversed: " << reverseSentence(sentence) << "\n\n";

    std::cout << "5. Median of two sorted arrays:\n";
    std::vector<int> nums1 = { 1, 3 };
    std::vector<int> nums2 = { 2 };
    std::cout << "Median: " << findMedianSortedArrays(nums1, nums2) << "\n";

    nums1 = { 1, 2 };
    nums2 = { 3, 4 };
    std::cout << "Median: " << findMedianSortedArrays(nums1, nums2) << "\n";

    return 0;
}