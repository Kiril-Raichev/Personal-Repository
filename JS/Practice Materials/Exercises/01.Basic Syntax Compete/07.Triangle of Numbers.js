function result(number) {
    for (let current = 1; current <= number; current++) {
        console.log(`${current} `.repeat(current));
    }
}

result(2)