#pragma once
#include <string>

class Rector {
private:
    std::string name;

public:
    Rector(const std::string& name);
    ~Rector();

    std::string getName() const;

    Rector(const Rector& other) = default;
    Rector& operator=(const Rector& other) = default;
    Rector(Rector&& other) noexcept = default;
    Rector& operator=(Rector&& other) noexcept = default;
};
