function result(arr) {
    let result = [];

    for (let num of arr) {
        if (!result.includes(num)) {
            result.push(num);
        }
    }
    console.log(result.join(' '));
}
result(
    [7, 8, 9, 7, 2, 3, 4, 1, 2]
);