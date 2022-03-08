function result(arr) {
    let wagons = arr.shift();
    let wagonsArr = wagons.split(' ');
    let capacity = arr.shift();
    let commands = arr;

    for (let i = 0; i < commands.length; i++) {
        let current = commands[i];
        let newCurrent = current.split(' ');
        if (newCurrent[0] === 'Add') {
            wagonsArr.push(Number(newCurrent[1]));
        } else {
            let add = Number(newCurrent[0]);
            let newArr = wagonsArr.filter((element) => {
                if (Number(element) + Number(add) <= Number(capacity)) {
                    return element;
                }
            });
            for (j = 0; j < wagonsArr.length; j++) {
                if (wagonsArr[j] == newArr[0]) {
                    wagonsArr[j] = Number(wagonsArr[j]) + add;
                    break;
                }
            }
        }
    }
    let result = wagonsArr.join(' ');
   console.log(result);
}
result(['32 54 21 12 4 0 23',
        '75',
        'Add 10',
        'Add 0',
        '30',
        '10',
        '75'
]);