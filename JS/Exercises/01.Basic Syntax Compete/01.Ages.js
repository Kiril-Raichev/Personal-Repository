function result(input) {
    let result = '';
    if (input >= 0 && input < 3) {
        result = 'baby';
    } else if (input >= 3 && input < 14) {
        result = 'child';
    } else if (input >= 14 && input < 20) {
        result = 'teenager';
    } else if (input >= 20 && input < 66) {
        result = 'adult';
    } else if (input >= 66) {
        result = 'elder';
    } else {
        result = 'out of bounds';
    }
    console.log(result);

}

result(20)