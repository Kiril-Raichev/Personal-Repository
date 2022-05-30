function result(input) {
    let result = '';
    if (input % 10 === 0) {
        result = 'The number is divisible by 10';
    } else if (input % 7 === 0) {
        result = 'The number is divisible by 7';
    } else if (input % 6 === 0) {
        result = 'The number is divisible by 6';
    } else if (input % 3 === 0) {
        result = 'The number is divisible by 3';
    } else if (input % 2 === 0) {
        result = 'The number is divisible by 2';
    } else {
        result = 'Not divisible';
    }
    console.log(result);
}
result(1643)