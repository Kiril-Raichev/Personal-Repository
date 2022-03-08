function result(numbers, bomb) {
    let bombNumber = bomb[0];
    let bombPower = bomb[1];

    while (numbers.includes(bombNumber)) {
        let index = numbers.indexOf(bombNumber);
        let remove = bombPower * 2 + 1;
        let start = index - bombPower;

        if (start < 0) {
            remove += start;
            start = 0;
        }
        numbers.splice(start, remove);
    }
    let final = numbers.reduce((a,b)=>{
        return a + b;
    },0);
    console.log(final);
}
result([1, 1, 2, 1, 1, 1, 2, 1, 1, 1],
    [2, 1]
);