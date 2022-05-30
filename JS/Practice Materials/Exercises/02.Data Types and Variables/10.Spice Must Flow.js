function result(yield) {
    let day = 0;
    let total = 0;
    let result = 0;
    if (yield < 100) {
        day = 1;
        total = yield;
    }
    while (yield >= 100) {
        let spice = yield;
        let saved = spice - 26;
        total += saved;
        yield -= 10;
        day++;
    }
    if (total < 26) {
        result = 0;
    } else {
        result = total - 26;
    }
    console.log(day);
    console.log(result);
}
result(450);